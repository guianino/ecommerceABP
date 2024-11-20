using System;
using Volo.Abp.Application.Dtos;

namespace ecommerce.Costumers
{
    public class CostumerDto : EntityDto<Guid>
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }

    }
}