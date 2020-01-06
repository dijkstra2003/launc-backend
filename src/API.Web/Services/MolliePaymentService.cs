using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Entities;
using API.Infrastructure.Data;
using API.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using static API.Web.Helpers.Environment;
using Amount = Mollie.Api.Models.Amount;

namespace API.Web.Services
{
public class MolliePaymentService : IPaymentService
    {
        private readonly string MOLLIE_KEY;
        private readonly string MOLLIE_REDIRECT_URL;
        private readonly string MOLLIE_WEBHOOK_URL;

        private readonly DataContext _ctx;
        private readonly ILogger _logger;
        private readonly IPaymentClient _client;

        public MolliePaymentService(
            DataContext ctx,
            IConfiguration configuration,
            ILogger<MolliePaymentService> logger,
            Helpers.Environment environment
        ) {
            _ctx = ctx;
            _logger = logger;

            this.MOLLIE_KEY = environment.GetEnvOrConfig("Mollie", "Key", EnvVariable.MollieKey);
            this.MOLLIE_REDIRECT_URL = environment.GetEnvOrConfig("Mollie", "RedirectURL", EnvVariable.MollieRedirectURL);
            this.MOLLIE_WEBHOOK_URL = environment.GetEnvOrConfig("Mollie", "WebhookURL", EnvVariable.MollieWebhookUrl);

            _client = this.SetupPaymentClient();
        }
        
        private PaymentClient SetupPaymentClient()
        {
            return new PaymentClient(MOLLIE_KEY);
        }

        public async Task<Payment> CreatePayment(decimal amount, Goal goal, SubGoal subgoal, PaymentMethod method)
        {
            var payment = new MolliePayment {
                Amount = amount,
                Goal = goal,
            };

            var response = await CreateMolliePayment(amount, "Launc space pledge", method);

            payment.Response = MollieResponse.FromMolliePaymentResponse(response, payment);

            _ctx.MolliePayment.Add(payment);
            
            await _ctx.SaveChangesAsync();
            _logger.LogInformation("Created payment with id: " + payment.Response.MollieId);

            return payment;
        }

        private async Task UpdatePayment(MolliePayment payment) {
            _ctx.MolliePayment.Update(payment);
            await _ctx.SaveChangesAsync();
        }

        private async Task<MolliePayment> FetchPaymentByPaymentId(string paymentId)
        {
            var response = await _ctx.MollieResponse
                .Include(x => x.Payment)
                .Where(x => x.MollieId == paymentId)
                .SingleOrDefaultAsync();
            
            return response.Payment;
        }

        public async Task<PaymentResponse> FetchMolliePayment(string paymentId)
        {
            return await _client.GetPaymentAsync(paymentId);
        }

        public async Task<PaymentResponse> CreateMolliePayment(decimal amount, string description, PaymentMethod method)
        {
            var paymentMethod = PaymentMethodToMolliePaymentMethod(method);
            var amountFormatted = amount.ToString(CultureInfo.InvariantCulture);

            var paymentRequest = new PaymentRequest() {
                Amount = new Amount(Currency.EUR, amountFormatted),
                Description = description,
                RedirectUrl = this.MOLLIE_REDIRECT_URL,
                WebhookUrl = this.MOLLIE_WEBHOOK_URL,
                Method = paymentMethod
            };

            return await _client.CreatePaymentAsync(paymentRequest);
        }

        public async Task UpdatePaymentStatus(string paymentId) {
            var localPayment = await FetchPaymentByPaymentId(paymentId);
            var molliePayment = await FetchMolliePayment(paymentId);

            try {
                var paymentStatus = molliePayment.Status ?? throw new NullReferenceException();
                localPayment.Status = MollieConverter.FromMolliePaymentStatus(paymentStatus);

                await UpdatePayment(localPayment);

            } catch(Exception e) {
                _logger.LogError("Error while updating the payment status: " + e.Message);
            }
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
    }
}