using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class JobType
    {
        public JobType()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Job> Job { get; set; }
    }
}
