using System;
using System.Collections.Generic;
using System.Text;
using ecommerce.Localization;
using Volo.Abp.Application.Services;

namespace ecommerce;

/* Inherit your application services from this class.
 */
public abstract class ecommerceAppService : ApplicationService
{
    protected ecommerceAppService()
    {
        LocalizationResource = typeof(ecommerceResource);
    }
}
