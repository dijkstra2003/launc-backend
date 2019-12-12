using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class CampaignGoal : BaseEntity
    {
        public int? CampaignFk { get; set; }
        public int? GoalFk { get; set; }
        public virtual Campaign CampaignFkNavigation { get; set; }
        public virtual Goal GoalFkNavigation { get; set; }
    }
}
