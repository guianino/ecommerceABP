using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ecommerce.Costumers;

    public interface ICostumerRepository : IRepository<Costumer, Guid>
    {
       Task<Costumer> FindByNameAsync(string name);

       Task<List<Costumer>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null); 
    }