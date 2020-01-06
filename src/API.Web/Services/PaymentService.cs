using System.Threading.Tasks;
using API.Core.Entities;

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

}