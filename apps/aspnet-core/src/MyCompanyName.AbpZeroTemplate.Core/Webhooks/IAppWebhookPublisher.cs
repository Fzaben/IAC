using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}