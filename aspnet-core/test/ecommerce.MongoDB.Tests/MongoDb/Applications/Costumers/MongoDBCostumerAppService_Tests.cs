using ecommerce.MongoDB;
using ecommerce.Costumers;
using Xunit;

namespace ecommerce.MongoDb.Applications.Costumers;

[Collection(ecommerceTestConsts.CollectionDefinitionName)]
public class MongoDBCostumerAppService_Tests : CostumerAppService_Tests<ecommerceMongoDbTestModule>
{

}
