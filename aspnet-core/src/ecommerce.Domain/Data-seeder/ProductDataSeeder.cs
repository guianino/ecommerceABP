using System;
using System.Threading.Tasks;
using ecommerce.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ecommerce;

public class ProductStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Product, Guid> _ProductRepository;

    public ProductStoreDataSeederContributor(IRepository<Product, Guid> ProductRepository)
    {
        _ProductRepository = ProductRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _ProductRepository.GetCountAsync() <= 0)
        {
            await _ProductRepository.InsertAsync(
                new Product
                {
                    Name = "Moletom Supreme",
                    Description = "Roupa de frio estilo moletom",
                    Price = 99.99,
                    Category = ProductCategory.Clothes
                },
                autoSave: true
            );

            await _ProductRepository.InsertAsync(
                new Product
                {
                    Name = "Moletom Nike",
                    Description = "Roupa de frio estilo moletom",
                    Price = 99.99,
                    Category = ProductCategory.Clothes
                },
                autoSave: true
            );
        }
    }
}
