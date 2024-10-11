using ecommerce.MongoDB;
using ecommerce.Products;
using Xunit;

namespace ecommerce.MongoDb.Applications.Product;

[Collection(ecommerceTestConsts.CollectionDefinitionName)]
public class MongoDBBookAppService_Tests : ProductAppService_Tests<ecommerceMongoDbTestModule>
{

}
