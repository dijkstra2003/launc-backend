using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public class Campaign : BaseEntity
    {
        public Campaign()
        {
            CampaignGoal = new HashSet<CampaignGoal>();
            TeamCampaign = new HashSet<TeamCampaign>();
            UserCampaign = new HashSet<UserCampaign>();
            UserLikes = new HashSet<UserLikes>();
        }

        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }

        public virtual ICollection<CampaignGoal> CampaignGoal { get; set; }
        public virtual ICollection<TeamCampaign> TeamCampaign { get; set; }
        public virtual ICollection<UserCampaign> UserCampaign { get; set; }
        public virtual ICollection<UserLikes> UserLikes { get; set; }
    }
}
