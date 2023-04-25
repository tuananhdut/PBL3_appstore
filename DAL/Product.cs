using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
        }
        [Key]
        public int ProductID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int ManufacturerID { get; set; }
        public string ProductName { get; set; }
        public int CostPrice { get; set; }
        public int SalePrice { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        [ForeignKey("ManufacturerID")]
        public virtual Manufacturer Manufacturer { get; set; }

        public override string ToString()
        {
            return ProductID.ToString();
        }
    }
}
