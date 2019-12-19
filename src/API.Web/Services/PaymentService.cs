using System.Threading.Tasks;
using API.Core.Entities;
using API.Infrastructure.Data;
using API.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using static API.Web.Helpers.Environment;

namespace API.Web.Services
{
    public enum PaymentMethod 
    {
        IDEAL,
        PAYPAL
    }

    public interface IPaymentService
    {
        Task<Payment> CreatePayment(decimal amount, Goal goal, SubGoal subgoal, PaymentMethod method);
    }

    public class MolliePaymentService : IPaymentService
    {
        private readonly string MOLLIE_KEY;
        private readonly string MOLLIE_REDIRECT_URL;
        private readonly string MOLLIE_WEBHOOK_URL;

        private readonly DataContext _ctx;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IPaymentClient _client;


        public MolliePaymentService(
            DataContext ctx,
            IConfiguration configuration,
            ILogger<MolliePaymentService> logger
        ) {
            _ctx = ctx;
            _configuration = configuration;
            _logger = logger;

            this.MOLLIE_KEY = GetEnvOrConfig("Key", EnvVariable.MollieKey);
            this.MOLLIE_REDIRECT_URL = GetEnvOrConfig("RedirectURL", EnvVariable.MollieRedirectURL);
            this.MOLLIE_WEBHOOK_URL = GetEnvOrConfig("WebhookURL", EnvVariable.MollieWebhookUrl);

            _client = this.SetupPaymentClient();
        }
        

        private string GetEnvOrConfig(string configkey, EnvVariable envVariable)
        {
            string configValue = GetConfigValue(configkey);

            return Environment.EnvironmentValueOrDefault(
                envVariable,
                configValue
            );
        }

        private PaymentClient SetupPaymentClient()
        {
            return new PaymentClient(MOLLIE_KEY);
        }

        public async Task<Payment> CreatePayment(decimal amount, Goal goal, SubGoal subgoal, PaymentMethod method)
        {
            var payment = new Payment();
            payment.Amount = amount;
            payment.Goal = goal;

            var response = await CreateMolliePayment(amount, "Launc space pledge", method);

            payment.MollieId = response.Id;

            return payment;
        }

        public async Task<PaymentResponse> CreateMolliePayment(decimal amount, string description, PaymentMethod method)
        {
            var paymentMethod = PaymentMethodToMolliePaymentMethod(method);

            var paymentRequest = new PaymentRequest() {
                Amount = new Amount(Currency.EUR, "100.00"),
                Description = "Launc space pledge",
                RedirectUrl = this.MOLLIE_REDIRECT_URL,
                WebhookUrl = this.MOLLIE_WEBHOOK_URL,
                Method = paymentMethod
            };

            return await _client.CreatePaymentAsync(paymentRequest);
        }

        private Mollie.Api.Models.Payment.PaymentMethod PaymentMethodToMolliePaymentMethod(PaymentMethod method) {
            switch (method) {
                case PaymentMethod.IDEAL:
                    return Mollie.Api.Models.Payment.PaymentMethod.Ideal;
                case PaymentMethod.PAYPAL:
                    return Mollie.Api.Models.Payment.PaymentMethod.PayPal;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private string GetConfigValue(string key) {
            return _configuration
                .GetSection("AppSettings")
                .GetSection("Mollie")[key];
        }
    }
}