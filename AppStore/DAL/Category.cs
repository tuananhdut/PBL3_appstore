﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int CategoryID { get; set; }
        public bool Flag { get; set; } = true;
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
