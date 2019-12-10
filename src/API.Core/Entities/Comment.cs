using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            UserComment = new HashSet<UserComment>();
        }

        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<UserComment> UserComment { get; set; }
    }
}
