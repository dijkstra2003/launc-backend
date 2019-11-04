using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Goal
    {
        public Goal()
        {
            CampaignGoal = new HashSet<CampaignGoal>();
            GoalSubGoal = new HashSet<GoalSubGoal>();
            ProductGoal = new HashSet<ProductGoal>();
        }

        public int Id { get; set; }
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MaxAmount { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<CampaignGoal> CampaignGoal { get; set; }
        public virtual ICollection<GoalSubGoal> GoalSubGoal { get; set; }
        public virtual ICollection<ProductGoal> ProductGoal { get; set; }
    }
}
