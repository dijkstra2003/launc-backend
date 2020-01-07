using System.Collections.Generic;
using System.Threading.Tasks;
using API.Core.Entities;

namespace API.Web.Services
{
    public enum PaymentMethod 
    {
        IDEAL,
        PAYPAL
    }

    public interface IPaymentService<T> where T : Payment
    {
        Task<T> CreatePayment(decimal amount, User user, Goal goal, SubGoal subgoal, PaymentMethod method);
        Task<T> FetchPayment(int id);
        Task<List<T>> ListPaymentsFromUser(User user);
        Task<T> ListPaymentFromUser(User user, int id);
        bool IsPaid(T payment);
    }

}