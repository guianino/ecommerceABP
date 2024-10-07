using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ecommerce.MongoDB;

[DependsOn(
    typeof(ecommerceApplicationTestModule),
    typeof(ecommerceMongoDbModule)
)]
public class ecommerceMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = ecommerceMongoDbFixture.GetRandomConnectionString();
        });
    }
}
