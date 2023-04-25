using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Invoice")]
    public class Invoice
    {
        public Invoice()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        public int InvoiceID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public int TotalAmount { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Account Account { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
