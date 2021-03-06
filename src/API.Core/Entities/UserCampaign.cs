﻿using API.Core.Entities;
using System;
using System.Collections.Generic;

namespace API.Core.Entities
{
    public partial class UserCampaign
    {
        public int Id { get; set; }
        public int? UserFk { get; set; }
        public int? CampaignFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Campaign CampaignFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
