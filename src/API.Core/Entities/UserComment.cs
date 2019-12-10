using API.Core.Entities;
using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class UserComment
    {
        public int Id { get; set; }
        public int? UserFk { get; set; }
        public int? CommentFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Comment CommentFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
