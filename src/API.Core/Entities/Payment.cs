namespace API.Core.Entities
{
    public class Payment : BaseEntity
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
        public string MollieId { get; set; }
    }
}