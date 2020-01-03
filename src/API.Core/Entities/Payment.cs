
namespace API.Core.Entities
{
    public abstract class Payment : BaseEntity
    {
        public enum PaymentStatus {
            OPEN,
            CANCELED,
            PENDING,
            AUTHORIZED,
            EXPIRED,
            FAILED,
            PAID
        }

        public virtual User User { get; set; }
        public virtual Goal Goal { get; set; }
        public virtual SubGoal SubGoal { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; } = Payment.PaymentStatus.OPEN;
    }

    public class MolliePayment : Payment {
        public virtual MollieResponse Response { get; set; }
    }

    public class MollieResponse : Mollie.Api.Models.Payment.Response.PaymentResponse {}
}