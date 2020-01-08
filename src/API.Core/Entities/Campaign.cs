using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public class Campaign : BaseEntity
    {

        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }

        public virtual List<CampaignGoal> CampaignGoal { get; set; }
        public virtual List<TeamCampaign> TeamCampaign { get; set; }
        public virtual List<UserCampaign> UserCampaign { get; set; }
        public virtual List<UserLikes> UserLikes { get; set; }
    }
}
