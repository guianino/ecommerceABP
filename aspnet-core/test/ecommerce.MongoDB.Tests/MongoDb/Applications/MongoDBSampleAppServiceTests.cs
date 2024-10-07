using ecommerce.MongoDB;
using ecommerce.Samples;
using Xunit;

namespace ecommerce.MongoDb.Applications;

[Collection(ecommerceTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<ecommerceMongoDbTestModule>
{

}
