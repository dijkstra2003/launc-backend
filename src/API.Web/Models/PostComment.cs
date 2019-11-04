using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int? CommentFk { get; set; }
        public int? PostFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Comment CommentFkNavigation { get; set; }
        public virtual Post PostFkNavigation { get; set; }
    }
}
