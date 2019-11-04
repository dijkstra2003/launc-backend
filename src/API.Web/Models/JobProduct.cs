using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class JobProduct
    {
        public int Id { get; set; }
        public int? JobFk { get; set; }
        public int? ProductFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Job JobFkNavigation { get; set; }
        public virtual Product ProductFkNavigation { get; set; }
    }
}
