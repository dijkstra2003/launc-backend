using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
