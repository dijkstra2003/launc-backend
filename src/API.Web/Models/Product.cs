using System;
using System.Collections.Generic;

namespace API.Web.Models
{
    public partial class Product
    {
        public Product()
        {
            JobProduct = new HashSet<JobProduct>();
            PostProduct = new HashSet<PostProduct>();
            ProductGoal = new HashSet<ProductGoal>();
            ProductType = new HashSet<ProductType>();
            UserProduct = new HashSet<UserProduct>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<JobProduct> JobProduct { get; set; }
        public virtual ICollection<PostProduct> PostProduct { get; set; }
        public virtual ICollection<ProductGoal> ProductGoal { get; set; }
        public virtual ICollection<ProductType> ProductType { get; set; }
        public virtual ICollection<UserProduct> UserProduct { get; set; }
    }
}
