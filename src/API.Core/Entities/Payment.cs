using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mollie.Api.Models.Payment.Response;

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

    public class MollieResponse : BaseEntity {

        public decimal AmountRemaining { get; set; }
        public string AmountRemainingCurrency { get; set; }
        public string RedirectUrl { get; set; }
        public string WebhookUrl { get; set; }
        [NotMapped]
        public string CheckoutUrl { get; set; }
        public string Locale { get; set; }
        public string CountryCode { get; set; }
        public string SubscriptionId { get; set; }
        public string OrderId { get; set; }
        public string Description { get; set; }
        public decimal AmountCaptured { get; set; }
        public string AmountCapturedCurrency { get; set; }
        public decimal AmountRefunded { get; set; }
        public string AmountRefundedCurrency { get; set; }
        public string Resource { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsCancelable { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public DateTime? FailedAt { get; set; }
        public decimal Amount { get; set; }
        public string AmountCurrency { get; set; }
        public DateTime? AuthorizedAt { get; set; }

        public static MollieResponse FromMolliePaymentResponse(PaymentResponse response) {
            
            var mollieResponse = new MollieResponse();

            if (response.AmountRemaining != null && Decimal.TryParse(response.AmountRemaining.Value, out decimal amountRemaining)) {
                mollieResponse.AmountRemaining = amountRemaining;
                mollieResponse.AmountRemainingCurrency = response.AmountRemaining.Currency;
            }

            mollieResponse.RedirectUrl = response.RedirectUrl;
            mollieResponse.WebhookUrl = response.WebhookUrl;

            mollieResponse.Locale = response.Locale;
            mollieResponse.CountryCode = response.CountryCode;

            mollieResponse.SubscriptionId = response.SubscriptionId;
            mollieResponse.OrderId = response.OrderId;

            mollieResponse.Description = response.Description;

            if (response.AmountCaptured != null && Decimal.TryParse(response.AmountCaptured.Value, out decimal amountCaptured)) {
                mollieResponse.AmountCaptured = amountCaptured;
                mollieResponse.AmountCapturedCurrency = response.AmountCaptured.Currency;
            }

            if (response.AmountRefunded != null && Decimal.TryParse(response.AmountRefunded.Value, out decimal amountRefuned)) {
                mollieResponse.AmountRefunded = amountRefuned;
                mollieResponse.AmountRefundedCurrency = response.AmountRefunded.Currency;
            }

            mollieResponse.Resource = response.Resource;

            mollieResponse.IsCancelable = response.IsCancelable;

            mollieResponse.Amount = Decimal.Parse(response.Amount.Value);
            mollieResponse.AmountCurrency = response.Amount.Currency;

            if (
                response.Links != null &&
                response.Links.Checkout != null
            ) {
                mollieResponse.CheckoutUrl = response.Links.Checkout.Href;
            }

            mollieResponse.CreatedAt = response.CreatedAt;
            mollieResponse.PaidAt = response.PaidAt;
            mollieResponse.CanceledAt = response.CanceledAt;
            mollieResponse.ExpiresAt = response.ExpiresAt;
            mollieResponse.ExpiredAt = response.ExpiredAt;
            mollieResponse.FailedAt = response.FailedAt;
            mollieResponse.AuthorizedAt = response.AuthorizedAt;

            return mollieResponse;
        }
    }
}
