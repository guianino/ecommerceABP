namespace ecommerce.Permissions;

public static class ecommercePermissions
{
    public const string GroupName = "ecommerce";

    public static class Products
    {
        public const string Default = GroupName + ".Products";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";

    }

    public static class Costumers
    {
        public const string Default = GroupName + ".Costumers";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

}
