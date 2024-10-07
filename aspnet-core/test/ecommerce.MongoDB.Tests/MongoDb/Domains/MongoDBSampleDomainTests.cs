using ecommerce.Samples;
using Xunit;

namespace ecommerce.MongoDB.Domains;

[Collection(ecommerceTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<ecommerceMongoDbTestModule>
{

}
