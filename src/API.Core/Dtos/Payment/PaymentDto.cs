using System.ComponentModel.DataAnnotations;
using API.Core.Validators;

namespace API.Core.Dtos.Payment
{
    public class PaymentDto
    {
        [Required]
        public int GoalId { get; set; }
        public int SubGoalId { get; set; }
        [PledgeAmount]
        public decimal Amount { get; set; }
    }
}