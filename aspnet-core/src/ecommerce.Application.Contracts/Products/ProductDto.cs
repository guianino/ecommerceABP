using System;
using Volo.Abp.Application.Dtos;

namespace ecommerce.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public string Name { get; }
    public string Description { get;  }
    public double Price { get;  }
    public int Stock  { get;  }
    public ProductCategory Category { get; }
}