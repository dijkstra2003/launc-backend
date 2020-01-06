using API.Core.Entities;
using MolliePayment = Mollie.Api.Models.Payment;

namespace API.Web.Helpers
{
    public static class MollieConverter
    {
        [System.Serializable]
        public class UnsupportedConverstionException : System.Exception
        {
            public UnsupportedConverstionException() { }
            public UnsupportedConverstionException(string message) : base(message) { }
            public UnsupportedConverstionException(string message, System.Exception inner) : base(message, inner) { }
            protected UnsupportedConverstionException(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public static Payment.PaymentStatus FromMolliePaymentStatus(MolliePayment.PaymentStatus status)
        {
            switch (status) {
                case MolliePayment.PaymentStatus.Authorized:
                    return Payment.PaymentStatus.AUTHORIZED;
                
                case MolliePayment.PaymentStatus.Canceled:
                    return Payment.PaymentStatus.CANCELED;
                
                case MolliePayment.PaymentStatus.Expired:
                    return Payment.PaymentStatus.EXPIRED;
                
                case MolliePayment.PaymentStatus.Failed:
                    return Payment.PaymentStatus.FAILED;

                case MolliePayment.PaymentStatus.Open:
                    return Payment.PaymentStatus.OPEN;

                case MolliePayment.PaymentStatus.Paid:
                    return Payment.PaymentStatus.PAID;

                case MolliePayment.PaymentStatus.Pending:
                    return Payment.PaymentStatus.PENDING;

                default:
                    throw new UnsupportedConverstionException();
            }
        }

    }
}