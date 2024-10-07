using Microsoft.Extensions.Localization;
using ecommerce.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ecommerce;

[Dependency(ReplaceServices = true)]
public class ecommerceBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ecommerceResource> _localizer;

    public ecommerceBrandingProvider(IStringLocalizer<ecommerceResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
