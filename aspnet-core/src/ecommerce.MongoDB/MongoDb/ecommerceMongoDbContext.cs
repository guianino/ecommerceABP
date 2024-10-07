using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using ecommerce.Products;

namespace ecommerce.MongoDB;

[ConnectionStringName("Default")]
public class ecommerceMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    public IMongoCollection<Product> Products => Collection<Product>(); 

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
