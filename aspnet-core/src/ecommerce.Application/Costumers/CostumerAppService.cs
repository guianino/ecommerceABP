using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerce.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;


namespace ecommerce.Costumers
{
    [Authorize(ecommercePermissions.Costumers.Default)]
    public class CostumerAppService : ecommerceAppService, ICostumerAppService
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly CostumerManager _costumerManager;

        public CostumerAppService(ICostumerRepository costumerRepository, CostumerManager costumerManager)
        {
            _costumerRepository = costumerRepository;
            _costumerManager = costumerManager;
        }

        public async Task<CostumerDto> GetAsync(Guid id)
        {
            var costumer = await _costumerManager.GetCostumerFromCache(id);
            return ObjectMapper.Map<CostumerCacheItem, CostumerDto>(costumer);
        }

        public async Task<PagedResultDto<CostumerDto>> GetListAsync(GetCostumerListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Costumer.Name);
            }

            var costumers = await _costumerRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _costumerRepository.CountAsync()
                : await _costumerRepository.CountAsync(
                    costumer => costumer.Name.Contains(input.Filter));

            return new PagedResultDto<CostumerDto>(
                totalCount,
                ObjectMapper.Map<List<Costumer>, List<CostumerDto>>(costumers)
            );
        }

        [Authorize(ecommercePermissions.Costumers.Create)]
        public async Task<CostumerDto> CreateAsync(CreateCostumerDto input)
        {
            var costumer = await _costumerManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.Document,
                input.FileDocument
            );

            await _costumerRepository.InsertAsync(costumer);

            return ObjectMapper.Map<Costumer, CostumerDto>(costumer);
        }

        [Authorize(ecommercePermissions.Costumers.Edit)]
        public async Task UpdateAsync(Guid id, UpdateCostumerDto input)
        {
            var costumer = await _costumerRepository.GetAsync(id);

            if (costumer.Name != input.Name)
            {
                await _costumerManager.UpdateNameAsync(costumer, input.Name);
            }

            costumer.BirthDate = input.BirthDate;
            costumer.Document = input.Document;

            await _costumerRepository.UpdateAsync(costumer);
        }

        [Authorize(ecommercePermissions.Costumers.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _costumerRepository.DeleteAsync(id);
        }

        public async Task GetDocumentFileAsync(Guid id)
        {
            await _costumerManager.GetDocumentAsync(id);
        }

        public async Task SaveDocumentFileAsync(Guid id, byte[] documentFile)
        {
            await _costumerManager.SaveFileDocumentAsync(id, documentFile);
        }
    }
}