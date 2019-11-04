using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Post
    {
        public Post()
        {
            PostComment = new HashSet<PostComment>();
            PostProduct = new HashSet<PostProduct>();
            UserLikes = new HashSet<UserLikes>();
            UserPost = new HashSet<UserPost>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostType { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual PostType PostTypeNavigation { get; set; }
        public virtual ICollection<PostComment> PostComment { get; set; }
        public virtual ICollection<PostProduct> PostProduct { get; set; }
        public virtual ICollection<UserLikes> UserLikes { get; set; }
        public virtual ICollection<UserPost> UserPost { get; set; }
    }
}
