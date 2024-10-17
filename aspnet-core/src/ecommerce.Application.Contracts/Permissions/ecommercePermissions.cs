namespace ecommerce.Permissions;

public static class ecommercePermissions
{
    public const string GroupName = "ecommerce";
    
    // other permissions...
    // other permissions...

 	// *** ADDED a NEW NESTED CLASS ***
    public static class Products
    {
        public const string Default = GroupName + ".Products";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
