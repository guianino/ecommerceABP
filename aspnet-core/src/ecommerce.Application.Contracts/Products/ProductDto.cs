using System;
using Volo.Abp.Application.Dtos;

namespace ecommerce.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public string Name { get; set;}
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock  { get; set; }
    public ProductCategory Category { get; set;}
}