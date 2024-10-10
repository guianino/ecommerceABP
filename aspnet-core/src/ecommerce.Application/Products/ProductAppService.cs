using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ecommerce.Products;

public class ProductAppService :
    CrudAppService<
        Product, //The Product entity
        ProductDto, //Used to show Products
        Guid, //Primary key of the Product entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductDto>, //Used to create/update a Product
    IProductAppService //implement the IProductAppService
{
    public ProductAppService(IRepository<Product, Guid> repository)
        : base(repository)
    {

    }
}
