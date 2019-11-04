using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class SubGoal
    {
        public SubGoal()
        {
            GoalSubGoal = new HashSet<GoalSubGoal>();
        }

        public int Id { get; set; }
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MaxAmount { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<GoalSubGoal> GoalSubGoal { get; set; }
    }
}
