using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class Goal : BaseEntity
    {
        public Goal()
        {
            CampaignGoal = new HashSet<CampaignGoal>();
            GoalSubGoal = new HashSet<GoalSubGoal>();
        }

        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MinAmount { get; set; }

        public virtual ICollection<CampaignGoal> CampaignGoal { get; set; }
        public virtual ICollection<GoalSubGoal> GoalSubGoal { get; set; }
    }
}
