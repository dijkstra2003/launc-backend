using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class CampaignType
    {
        public CampaignType()
        {
            Campaign = new HashSet<Campaign>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
    }
}
