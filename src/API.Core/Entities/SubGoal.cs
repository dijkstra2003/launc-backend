using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class SubGoal
    {
        public SubGoal()
        {
            GoalSubGoal = new List<GoalSubGoal>();
        }

        public int Id { get; set; }
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MinAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public int Progress { get => CalculateProgress(); }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual List<GoalSubGoal> GoalSubGoal { get; set; }

        private int CalculateProgress()
        {
            Decimal progress = CurrentAmount / MinAmount;
            return (int) Math.Floor(progress * 100);
        }
    }
}
