using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class User
    {
        public User()
        {
            MessageFromUserFkNavigation = new HashSet<Message>();
            MessageToUserFkNavigation = new HashSet<Message>();
            UserCampaign = new HashSet<UserCampaign>();
            UserComment = new HashSet<UserComment>();
            UserLikes = new HashSet<UserLikes>();
            UserPost = new HashSet<UserPost>();
            UserProduct = new HashSet<UserProduct>();
            UserTeam = new HashSet<UserTeam>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public int UserRole { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Role UserRoleNavigation { get; set; }
        public virtual ICollection<Message> MessageFromUserFkNavigation { get; set; }
        public virtual ICollection<Message> MessageToUserFkNavigation { get; set; }
        public virtual ICollection<UserCampaign> UserCampaign { get; set; }
        public virtual ICollection<UserComment> UserComment { get; set; }
        public virtual ICollection<UserLikes> UserLikes { get; set; }
        public virtual ICollection<UserPost> UserPost { get; set; }
        public virtual ICollection<UserProduct> UserProduct { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
    }
}
