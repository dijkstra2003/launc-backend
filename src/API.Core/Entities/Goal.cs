using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class Goal : BaseEntity
    {
        public Goal()
        {
            CampaignGoal = new List<CampaignGoal>();
            GoalSubGoal = new List<GoalSubGoal>();
        }

        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MinAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public int Progress { get => CalculateProgress(); }
        public virtual List<CampaignGoal> CampaignGoal { get; set; }
        public virtual List<GoalSubGoal> GoalSubGoal { get; set; }

        private int CalculateProgress()
        {
            Decimal progress = CurrentAmount / MinAmount;
            return (int) Math.Floor(progress * 100);
        }
    }
}
