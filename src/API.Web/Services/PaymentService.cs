using System.Threading.Tasks;
using API.Core.Entities;
using API.Infrastructure.Data;
using API.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;

namespace API.Web.Services
{
    public interface IPaymentService
    {
        Task<Payment> CreatePayment(decimal amount, Goal goal, SubGoal subgoal);
    }

    public class MolliePaymentService : IPaymentService
    {
        private readonly DataContext _ctx;
        private readonly IConfiguration _configuration;
        private readonly IPaymentClient _client;

        public MolliePaymentService(DataContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            _configuration = configuration;
            _client = this.CreatePaymentClient();
        }

        private IPaymentClient CreatePaymentClient()
        {
            string configKey = _configuration.GetSection("AppSettings")["MollieKey"];

            string key = Environment.EnvironmentValueOrDefault(
                Environment.EnvVariable.MollieKey,
                configKey
            );

            var request = new PaymentRequest() {
                
            };

            return new PaymentClient(key);
        }

        public async Task<Payment> CreatePayment(decimal amount, Goal goal, SubGoal subgoal)
        {
            var payment = new Payment();
            payment.Amount = amount;
            payment.Goal = goal;

            throw new System.NotImplementedException();
        }
    }
}