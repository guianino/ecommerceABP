using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ecommerce.Costumers
{
    public class GetCostumerListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}