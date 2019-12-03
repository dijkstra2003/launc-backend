﻿using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
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
        public int MinAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<GoalSubGoal> GoalSubGoal { get; set; }
    }
}