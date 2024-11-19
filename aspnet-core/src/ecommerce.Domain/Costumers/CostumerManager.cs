using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.BlobStoring;



namespace ecommerce.Costumers
{
    public class CostumerManager : DomainService
    {
        private readonly ICostumerRepository _costumerRepository;

        private readonly IDistributedCache<CostumerCacheItem, Guid> _costumerCache;
        private readonly IBlobContainer<DocumentContainer> _documentContainer;

        public CostumerManager(ICostumerRepository costumerRepository, IDistributedCache<CostumerCacheItem, Guid> costumerCache, IBlobContainer<DocumentContainer> documentContainer)
        {
            _costumerRepository = costumerRepository;
            _costumerCache = costumerCache;
            _documentContainer = documentContainer;
        }

        public async Task<Costumer> CreateAsync(string name, DateTime birthDate, string document, string fileDocument)
        {
            var existingCostumer = await _costumerRepository.FindByNameAsync(name);
            if (existingCostumer != null)
            {
                throw new CostumerExistsException(name);
            }

            return new Costumer(
                GuidGenerator.Create(),
                name,
                birthDate,
                document,
                fileDocument
            );

        }

        public async Task UpdateNameAsync(Costumer costumer, string newName)
        {
            Check.NotNull(costumer, nameof(costumer));
            var existingCostumer = await _costumerRepository.FindByNameAsync(newName);
            if (existingCostumer != null && existingCostumer.Id != costumer.Id)
            {
                throw new CostumerExistsException(newName);
            }

            costumer.SetName(newName);
        }

        public async Task<CostumerCacheItem> GetCostumerFromCache(Guid id)
        {
            var cacheItem = await _costumerCache.GetOrAddAsync(
                id, //cache key
                async () =>
                {
                var costumer = await _costumerRepository.FindAsync(id);
                var costumerCacheItem = new CostumerCacheItem
                {
                    id = costumer.Id,
                    Name = costumer.Name,
                    BirthDate = costumer.BirthDate,
                    Document = costumer.Document
                };
                return costumerCacheItem;
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6)
                }
            );
            return cacheItem;
        }
    }
}