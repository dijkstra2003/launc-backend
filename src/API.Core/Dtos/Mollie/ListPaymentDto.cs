using API.Core.Entities;
using static API.Core.Entities.Payment;

namespace API.Core.Dtos.Mollie
{
    public class ListPaymentDto
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public int? SubGoalId { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
    }
}