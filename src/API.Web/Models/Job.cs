using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Job
    {
        public Job()
        {
            JobProduct = new HashSet<JobProduct>();
            TeamJob = new HashSet<TeamJob>();
        }

        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public int JobType { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual JobType JobTypeNavigation { get; set; }
        public virtual ICollection<JobProduct> JobProduct { get; set; }
        public virtual ICollection<TeamJob> TeamJob { get; set; }
    }
}
