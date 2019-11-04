using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Comment
    {
        public Comment()
        {
            PostComment = new HashSet<PostComment>();
            UserComment = new HashSet<UserComment>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<PostComment> PostComment { get; set; }
        public virtual ICollection<UserComment> UserComment { get; set; }
    }
}
