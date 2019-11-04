﻿using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class UserTeam
    {
        public int Id { get; set; }
        public int? UserFk { get; set; }
        public int? TeamFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Team TeamFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
