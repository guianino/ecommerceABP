using Volo.Abp.Modularity;

namespace ecommerce;

public abstract class ecommerceApplicationTestBase<TStartupModule> : ecommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
