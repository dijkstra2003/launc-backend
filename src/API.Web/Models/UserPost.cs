using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class UserPost
    {
        public int Id { get; set; }
        public int? UserFk { get; set; }
        public int? PostFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Post PostFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
