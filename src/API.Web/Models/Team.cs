using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Team
    {
        public Team()
        {
            TeamCampaign = new HashSet<TeamCampaign>();
            TeamJob = new HashSet<TeamJob>();
            UserTeam = new HashSet<UserTeam>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<TeamCampaign> TeamCampaign { get; set; }
        public virtual ICollection<TeamJob> TeamJob { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
    }
}
