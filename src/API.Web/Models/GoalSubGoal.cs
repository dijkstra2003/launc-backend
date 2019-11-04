using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class GoalSubGoal
    {
        public int Id { get; set; }
        public int? GoalFk { get; set; }
        public int? SubGoalFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Goal GoalFkNavigation { get; set; }
        public virtual SubGoal SubGoalFkNavigation { get; set; }
    }
}
