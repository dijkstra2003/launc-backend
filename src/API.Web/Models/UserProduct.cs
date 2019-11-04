using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class UserProduct
    {
        public int Id { get; set; }
        public int? UserFk { get; set; }
        public int? ProductFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Product ProductFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
