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