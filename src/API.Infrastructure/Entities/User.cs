using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class User
    {
        public User()
        {
            UserCampaign = new HashSet<UserCampaign>();
            UserComment = new HashSet<UserComment>();
            UserLikes = new HashSet<UserLikes>();
            UserProduct = new HashSet<UserProduct>();
            UserTeam = new HashSet<UserTeam>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<UserCampaign> UserCampaign { get; set; }
        public virtual ICollection<UserComment> UserComment { get; set; }
        public virtual ICollection<UserLikes> UserLikes { get; set; }
        public virtual ICollection<UserProduct> UserProduct { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
    }
}
