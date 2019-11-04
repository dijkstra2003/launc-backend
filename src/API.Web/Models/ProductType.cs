using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            InverseProductTypeFkNavigation = new HashSet<ProductType>();
        }

        public int Id { get; set; }
        public int? ProductFk { get; set; }
        public int? ProductTypeFk { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Product ProductFkNavigation { get; set; }
        public virtual ProductType ProductTypeFkNavigation { get; set; }
        public virtual ICollection<ProductType> InverseProductTypeFkNavigation { get; set; }
    }
}
