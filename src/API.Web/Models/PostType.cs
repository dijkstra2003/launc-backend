using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class PostType
    {
        public PostType()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
