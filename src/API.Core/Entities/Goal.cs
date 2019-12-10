using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class Goal
    {
        public Goal()
        {
            CampaignGoal = new HashSet<CampaignGoal>();
            GoalSubGoal = new HashSet<GoalSubGoal>();
        }

        public int Id { get; set; }
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MinAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<CampaignGoal> CampaignGoal { get; set; }
        public virtual ICollection<GoalSubGoal> GoalSubGoal { get; set; }
    }
}
