using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        [Required]
        public int InvoiceDetailID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int InvoiceID { get; set; }
        public int Quantity { get; set; }
        public int SalePrice { get; set; }
        [ForeignKey("InvoiceID")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
