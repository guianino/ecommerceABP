using ecommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ecommerce.Permissions;

public class ecommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var ecommerceGroup = context.AddGroup(ecommercePermissions.GroupName, L("Permission:Ecommerce"));

        var productsPermission = ecommerceGroup.AddPermission(ecommercePermissions.Products.Default, L("Permission:Products"));
        productsPermission.AddChild(ecommercePermissions.Products.Create, L("Permission:Products.Create"));
        productsPermission.AddChild(ecommercePermissions.Products.Edit, L("Permission:Products.Edit"));
        productsPermission.AddChild(ecommercePermissions.Products.Delete, L("Permission:Products.Delete"));

        var authorsPermission = ecommerceGroup.AddPermission(ecommercePermissions.Costumers.Default, L("Permission:Costumers"));
        authorsPermission.AddChild(ecommercePermissions.Costumers.Create, L("Permission:Costumers.Create"));
        authorsPermission.AddChild(ecommercePermissions.Costumers.Edit, L("Permission:Costumers.Edit"));
        authorsPermission.AddChild(ecommercePermissions.Costumers.Delete, L("Permission:Costumers.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ecommerceResource>(name);
    }
}
