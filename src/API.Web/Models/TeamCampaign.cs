using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class TeamCampaign
    {
        public int Id { get; set; }
        public int? TeamFk { get; set; }
        public int? CampaignFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Campaign CampaignFkNavigation { get; set; }
        public virtual Team TeamFkNavigation { get; set; }
    }
}
