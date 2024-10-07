using ecommerce.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ecommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ecommerceMongoDbModule),
    typeof(ecommerceApplicationContractsModule)
    )]
public class ecommerceDbMigratorModule : AbpModule
{
}
