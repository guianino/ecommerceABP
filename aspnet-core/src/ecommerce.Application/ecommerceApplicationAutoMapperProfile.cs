using AutoMapper;
using ecommerce.Costumers;
using ecommerce.Products;

namespace ecommerce;

public class ecommerceApplicationAutoMapperProfile : Profile
{
    public ecommerceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

         CreateMap<Product, ProductDto>();
         CreateMap<CreateUpdateProductDto, Product>();
         CreateMap<Costumer, CostumerDto>();
         CreateMap<CostumerCacheItem, CostumerDto>();
    }
}
