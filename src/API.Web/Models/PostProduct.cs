using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class PostProduct
    {
        public int Id { get; set; }
        public int? ProductFk { get; set; }
        public int? PostFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Post PostFkNavigation { get; set; }
        public virtual Product ProductFkNavigation { get; set; }
    }
}
