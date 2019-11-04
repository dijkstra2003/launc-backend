﻿using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class CampaignGoal
    {
        public int Id { get; set; }
        public int? CampaignFk { get; set; }
        public int? GoalFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Campaign CampaignFkNavigation { get; set; }
        public virtual Goal GoalFkNavigation { get; set; }
    }
}
