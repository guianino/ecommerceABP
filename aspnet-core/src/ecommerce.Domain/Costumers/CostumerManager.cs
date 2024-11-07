using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;



namespace ecommerce.Costumers
{
    public class CostumerManager : DomainService
    {
        private readonly ICostumerRepository CostumerRepository;

        private readonly IDistributedCache<CostumerCacheItem, Guid> _costumerCache;

        public CostumerManager(ICostumerRepository costumerRepository)
        {
            CostumerRepository = costumerRepository;
        }

        public async Task<Costumer> CreateAsync(string name, DateTime birthDate, string document)
        {
            var existingCostumer = await CostumerRepository.FindByNameAsync(name);
            if (existingCostumer != null)
            {
                throw new CostumerExistsException(name);
            }

            return new Costumer(
                GuidGenerator.Create(),
                name,
                birthDate,
                document
            );

        }

        public async Task UpdateNameAsync(Costumer costumer, string newName)
        {
            Check.NotNull(costumer, nameof(costumer));
            var existingCostumer = await CostumerRepository.FindByNameAsync(newName);
            if (existingCostumer != null && existingCostumer.Id != costumer.Id)
            {
                throw new CostumerExistsException(newName);
            }

            costumer.SetName(newName);
        }

        public async Task<CostumerCacheItem> GetCostumerFromCache(Guid id)
        {
            return await _costumerCache.GetOrAddAsync(
            id, //cache key
            async () => await GetCostumerFromDb(id),
            () => new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6)
            }
        ); 
        }

        public async Task<CostumerCacheItem> GetCostumerFromDb(Guid id)
        {
            var costumer = await CostumerRepository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            var costumerCacheItem = new CostumerCacheItem
            {
                id = costumer.Id,
                Name = costumer.Name,
                BirthDate = costumer.BirthDate,
                Document =  costumer.Document
            };
            return costumerCacheItem;
        }
    }
}