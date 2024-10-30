using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Dynamic.Core;


namespace ecommerce.Costumers
{
    public class MongoDbCostumerRepository : MongoDbRepository<ecommerceMongoDbContext, Costumer, Guid>, ICostumerRepository
    {
        public MongoDbCostumerRepository(IMongoDbContextProvider<ecommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<Costumer> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(costumer => costumer.Name == name);
        }

        public async Task<List<Costumer>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Costumer, IMongoQueryable<Costumer>>(
                    !filter.IsNullOrWhiteSpace(),
                    costumer => costumer.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Costumer>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}