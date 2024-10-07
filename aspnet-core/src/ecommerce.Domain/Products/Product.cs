using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ecommerce.Products;

public class Product : AuditedAggregateRoot<Guid> 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock  { get; set; }
    public ProductCategory Category { get; set; }
}