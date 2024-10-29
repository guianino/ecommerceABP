using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace ecommerce.Costumers
{
    public class CostumerExistsException : BusinessException
    {
        public CostumerExistsException(string name) : base(ecommerceDomainErrorCodes.CostumerExistsException)
        {
            WithData("name", name);
        }
    }
}