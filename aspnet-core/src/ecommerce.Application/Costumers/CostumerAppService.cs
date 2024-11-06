using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Caching;

namespace ecommerce.Costumers
{
    [Authorize(ecommercePermissions.Costumers.Default)]
    public class CostumerAppService : ecommerceAppService, ICostumerAppService
    {
        private readonly ICostumerRepository CostumerRepository;
        private readonly CostumerManager CostumerManager;
        private readonly IDistributedCache<CostumerCacheItem, Guid> _costumerCache;

        public CostumerAppService(IDistributedCache<CostumerCacheItem, Guid> costumerCache)
        {
            _costumerCache = costumerCache;
        }

        public CostumerAppService(ICostumerRepository costumerRepository, CostumerManager costumerManager)
        {
            CostumerRepository = costumerRepository;
            CostumerManager = costumerManager;
        }

        public async Task<CostumerDto> GetAsync(Guid id)
        {
            var costumer = await CostumerRepository.GetAsync(id);
            return ObjectMapper.Map<Costumer, CostumerDto>(costumer);
        }

        public async Task<PagedResultDto<CostumerDto>> GetListAsync(GetCostumerListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Costumer.Name);
            }

            var costumers = await CostumerRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await CostumerRepository.CountAsync()
                : await CostumerRepository.CountAsync(
                    costumer => costumer.Name.Contains(input.Filter));

            return new PagedResultDto<CostumerDto>(
                totalCount,
                ObjectMapper.Map<List<Costumer>, List<CostumerDto>>(costumers)
            );
        }

        [Authorize(ecommercePermissions.Costumers.Create)]
        public async Task<CostumerDto> CreateAsync(CreateCostumerDto input)
        {
            var costumer = await CostumerManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.Document
            );

            await CostumerRepository.InsertAsync(costumer);

            return ObjectMapper.Map<Costumer, CostumerDto>(costumer);
        }

        [Authorize(ecommercePermissions.Costumers.Edit)]
        public async Task UpdateAsync(Guid id, UpdateCostumerDto input)
        {
            var costumer = await CostumerRepository.GetAsync(id);

            if (costumer.Name != input.Name)
            {
                await CostumerManager.UpdateNameAsync(costumer, input.Name);
            }

            costumer.BirthDate = input.BirthDate;
            costumer.Document = input.Document;

            await CostumerRepository.UpdateAsync(costumer);
        }

        [Authorize(ecommercePermissions.Costumers.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await CostumerRepository.DeleteAsync(id);
        }





    }
}