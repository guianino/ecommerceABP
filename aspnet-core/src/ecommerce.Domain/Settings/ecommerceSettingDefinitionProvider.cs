using Volo.Abp.Settings;

namespace ecommerce.Settings;

public class ecommerceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ecommerceSettings.MySetting1));
        context.Add(
            new SettingDefinition(ecommerceSettings.AllowPaymentWithPix)
        );
    }
}



// public class PaymentService
// {
//     private readonly ISettingProvider _settingProvider;

//     public PaymentService(ISettingProvider settingProvider)
//     {
//         _settingProvider = settingProvider;
//     }

//     public async Task<bool> IsPixEnabledAsync()
//     {
//         return await _settingProvider.GetAsync<bool>(ecommerceSettings.AllowPaymentWithPix);
//     }

//     public async Task ProcessPaymentAsync(string paymentMethod)
//     {
//         if (paymentMethod == "Pix")
//         {
//             if (!await IsPixEnabledAsync())
//             {
//                 throw new Exception("Payment with Pix is currently disabled.");
//             }

//         }
//     }
// }