using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class Team
    {
        public Team()
        {
            TeamCampaign = new HashSet<TeamCampaign>();
            UserTeam = new HashSet<UserTeam>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<TeamCampaign> TeamCampaign { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
    }
}
