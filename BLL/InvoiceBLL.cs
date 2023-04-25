using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InvoiceBLL
    {
        private InvoiceDAL dal;
        public static InvoiceBLL _intance;
        public static InvoiceBLL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new InvoiceBLL();
                }
                return _intance;
            }
            private set { }
        }
        public InvoiceBLL()
        {
            dal = new InvoiceDAL();
        }

        // add invoice
        public bool addInvoice(Invoice hd) => dal.addInvoice(hd);
    }
}
