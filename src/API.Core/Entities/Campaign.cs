using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignGoal = new HashSet<CampaignGoal>();
            TeamCampaign = new HashSet<TeamCampaign>();
            UserCampaign = new HashSet<UserCampaign>();
            UserLikes = new HashSet<UserLikes>();
        }

        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public int? CampaignType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual CampaignType CampaignTypeNavigation { get; set; }
        public virtual ICollection<CampaignGoal> CampaignGoal { get; set; }
        public virtual ICollection<TeamCampaign> TeamCampaign { get; set; }
        public virtual ICollection<UserCampaign> UserCampaign { get; set; }
        public virtual ICollection<UserLikes> UserLikes { get; set; }
    }
}
