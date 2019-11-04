using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class TeamJob
    {
        public int Id { get; set; }
        public int? TeamFk { get; set; }
        public int? JobFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Job JobFkNavigation { get; set; }
        public virtual Team TeamFkNavigation { get; set; }
    }
}
