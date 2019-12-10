using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductGoal = new HashSet<ProductGoal>();
            ProductType = new HashSet<ProductType>();
            UserProduct = new HashSet<UserProduct>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<ProductGoal> ProductGoal { get; set; }
        public virtual ICollection<ProductType> ProductType { get; set; }
        public virtual ICollection<UserProduct> UserProduct { get; set; }
    }
}
