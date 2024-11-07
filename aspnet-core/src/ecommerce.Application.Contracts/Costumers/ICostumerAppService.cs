using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ecommerce.Costumers
{
    public interface ICostumerAppService : IApplicationService
    {
        Task<CostumerDto> GetAsync(Guid id);

        Task<PagedResultDto<CostumerDto>> GetListAsync(GetCostumerListDto input);

        Task<CostumerDto> CreateAsync(CreateCostumerDto input);

        Task UpdateAsync(Guid id, UpdateCostumerDto input);

        Task DeleteAsync(Guid id);
    }
}