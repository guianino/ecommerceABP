using System;
using System.Threading.Tasks;
using ecommerce.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using ecommerce.Costumers;

namespace ecommerce;

public class ProductStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly ICostumerRepository _costumerRepository;
    private readonly CostumerManager _costumerManager;

    public ProductStoreDataSeederContributor(IRepository<Product, Guid> ProductRepository, ICostumerRepository CostumerRepository, CostumerManager CostumerManager)
    {
        _productRepository = ProductRepository;
        _costumerRepository = CostumerRepository;
        _costumerManager = CostumerManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _productRepository.GetCountAsync() <= 0)
        {
            await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Moletom Supreme",
                    Description = "Roupa de frio estilo moletom",
                    Price = 99.99,
                    Category = ProductCategory.Clothes
                },
                autoSave: true
            );

            await _productRepository.InsertAsync(
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
        if( await _costumerRepository.GetCountAsync() <= 0)
        {
            await _costumerRepository.InsertAsync(
                await _costumerManager.CreateAsync(
                    "Fulano Silva",
                    new DateTime(1995, 06, 18),
                    "0156445678"
                )
            );

            await _costumerRepository.InsertAsync(
                await _costumerManager.CreateAsync(
                    "Ciclano Oliveira",
                    new DateTime(1999, 09, 21),
                    "878644621"
                )
            );

            

        }
    }
}
