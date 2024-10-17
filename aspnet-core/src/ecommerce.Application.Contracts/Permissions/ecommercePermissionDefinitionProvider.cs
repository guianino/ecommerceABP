using ecommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ecommerce.Permissions;

public class ecommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var ecommerceGroup = context.AddGroup(ecommercePermissions.GroupName, L("Permission:ecommerce"));

        var ProductsPermission = ecommerceGroup.AddPermission(ecommercePermissions.Products.Default, L("Permission:Products"));
        ProductsPermission.AddChild(ecommercePermissions.Products.Create, L("Permission:Products.Create"));
        ProductsPermission.AddChild(ecommercePermissions.Products.Edit, L("Permission:Products.Edit"));
        ProductsPermission.AddChild(ecommercePermissions.Products.Delete, L("Permission:Products.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ecommerceResource>(name);
    }
}
