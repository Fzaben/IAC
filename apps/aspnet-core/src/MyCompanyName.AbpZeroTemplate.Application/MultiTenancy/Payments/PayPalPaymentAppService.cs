using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.Paypal;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.PayPal;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.PayPal.Dto;

namespace MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments
{
    public class PayPalPaymentAppService : AbpZeroTemplateAppServiceBase, IPayPalPaymentAppService
    {
        private readonly PayPalGatewayManager _payPalGatewayManager;
        private readonly PayPalPaymentGatewayConfiguration _payPalPaymentGatewayConfiguration;
        private readonly ISubscriptionPaymentRepository _subscriptionPaymentRepository;

        public PayPalPaymentAppService(
            PayPalGatewayManager payPalGatewayManager,
            ISubscriptionPaymentRepository subscriptionPaymentRepository,
            PayPalPaymentGatewayConfiguration payPalPaymentGatewayConfiguration)
        {
            _payPalGatewayManager = payPalGatewayManager;
            _subscriptionPaymentRepository = subscriptionPaymentRepository;
            _payPalPaymentGatewayConfiguration = payPalPaymentGatewayConfiguration;
        }

        public async Task ConfirmPayment(long paymentId, string paypalOrderId)
        {
            var payment = await _subscriptionPaymentRepository.GetAsync(paymentId);

            await _payPalGatewayManager.CaptureOrderAsync(
                new PayPalCaptureOrderRequestInput(paypalOrderId)
            );

            payment.Gateway = SubscriptionPaymentGatewayType.Paypal;
            payment.ExternalPaymentId = paypalOrderId;
            payment.SetAsPaid();
        }

        public PayPalConfigurationDto GetConfiguration()
        {
            return new PayPalConfigurationDto
            {
                ClientId = _payPalPaymentGatewayConfiguration.ClientId,
                DemoUsername = _payPalPaymentGatewayConfiguration.DemoUsername,
                DemoPassword = _payPalPaymentGatewayConfiguration.DemoPassword
            };
        }
    }
}