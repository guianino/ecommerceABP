using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ecommerce.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        
    }
}