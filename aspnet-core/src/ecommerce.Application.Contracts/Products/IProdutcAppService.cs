using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ecommerce.Products;

public interface IProductAppService :
    ICrudAppService< //Defines CRUD methods
        ProductDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductDto> //Used to create/update a book
{

}
