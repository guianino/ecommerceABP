using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ecommerce.Costumers
{
    public class CostumerManager : DomainService
    {
        private readonly ICostumerRepository CostumerRepository;

        public CostumerManager(ICostumerRepository costumerRepository)
        {
            CostumerRepository = costumerRepository;
        }

        public async Task<Costumer> CreateAsync(string name, DateTime birthDate, string document)
        {
            var existingCostumer = await CostumerRepository.FindByNameAsync(name);
            if (existingCostumer != null)
            {
                throw new CostumerExistsException(name);
            }

            return new Costumer(
                GuidGenerator.Create(),
                name,
                birthDate,
                document
            );

        }

        public async Task UpdateNameAsync(Costumer costumer, string newName)
        {
            Check.NotNull(costumer, nameof(costumer));
            var existingCostumer = await CostumerRepository.FindByNameAsync(newName);
            if (existingCostumer != null && existingCostumer.Id != costumer.Id)
            {
                throw new CostumerExistsException(newName);
            }

            costumer.SetName(newName);
        }
    }
}