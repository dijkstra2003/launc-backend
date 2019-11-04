using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int ToUserFk { get; set; }
        public int FromUserFk { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual User FromUserFkNavigation { get; set; }
        public virtual User ToUserFkNavigation { get; set; }
    }
}
