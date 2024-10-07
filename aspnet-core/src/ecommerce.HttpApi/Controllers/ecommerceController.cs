using ecommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ecommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ecommerceController : AbpControllerBase
{
    protected ecommerceController()
    {
        LocalizationResource = typeof(ecommerceResource);
    }
}
