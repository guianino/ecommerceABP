using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace ecommerce.Costumers
{
    public abstract class CostumerAppService_Tests<TStartupModule> : ecommerceApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
    {
        private readonly ICostumerAppService _costumerAppService;

        protected CostumerAppService_Tests()
        {
            _costumerAppService = GetRequiredService<ICostumerAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Authors_Without_Any_Filter()
        {
            var result = await _costumerAppService.GetListAsync(new GetCostumerListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(costumer => costumer.Name == "Fulano Silva");
            result.Items.ShouldContain(costumer => costumer.Name == "Ciclano Oliveira");
        }

        [Fact]
        public async Task Should_Create_A_New_Costumer()
        {
            var costumerDto = await _costumerAppService.CreateAsync(
                new CreateCostumerDto
                {
                    Name = "Guilherme Ianino",
                    BirthDate = new DateTime(1993, 11, 25),
                    Document = "78910"
                }
            );

            costumerDto.Id.ShouldNotBe(Guid.Empty);
            costumerDto.Name.ShouldBe("Guilherme Ianino");
        }

    }
}