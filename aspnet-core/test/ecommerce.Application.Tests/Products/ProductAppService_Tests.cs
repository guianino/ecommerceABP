using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace ecommerce.Products;

public abstract class ProductAppService_Tests<TStartupModule> : ecommerceApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IProductAppService _productAppService;

    protected ProductAppService_Tests()
    {
        _productAppService = GetRequiredService<IProductAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Products()
    {
        //Act
        var result = await _productAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(b => b.Name == "Teste");
    }
    [Fact]
    public async Task Should_Create_A_Valid_Product()
    {
        //Act
        var result = await _productAppService.CreateAsync(
            new CreateUpdateProductDto
            {
                Name = "New test Product 42",
                Description = "Modelo",
                Price = 10.10,
                Stock = 5,
                Category = ProductCategory.Clothes
            }
        );

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("New test Product 42");
    }

    [Fact]
    public async Task Should_Not_Create_A_Product_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "",
                    Price = 10,
                    Category = ProductCategory.Others
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }


}
