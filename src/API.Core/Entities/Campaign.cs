using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public class Campaign : BaseEntity
    {

        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public string CampaignUrl { get; set; }
        public virtual Goal Goal { get; set; }
    }
}
