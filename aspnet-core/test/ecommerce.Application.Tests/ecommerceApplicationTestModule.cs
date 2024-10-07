using Volo.Abp.Modularity;

namespace ecommerce;

[DependsOn(
    typeof(ecommerceApplicationModule),
    typeof(ecommerceDomainTestModule)
)]
public class ecommerceApplicationTestModule : AbpModule
{

}
