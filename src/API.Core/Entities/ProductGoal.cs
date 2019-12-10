using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class ProductGoal
    {
        public int Id { get; set; }
        public int? ProductFk { get; set; }
        public int? GoalFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Goal GoalFkNavigation { get; set; }
        public virtual Product ProductFkNavigation { get; set; }
    }
}
