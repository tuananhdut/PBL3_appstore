using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InvoiceDetailBLL
    {
        private InvoiceDetailDAL dal;
        public static InvoiceDetailBLL _intance;
        public static InvoiceDetailBLL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new InvoiceDetailBLL();
                }
                return _intance;
            }
            private set { }
        }
        public InvoiceDetailBLL()
        {
            dal = new InvoiceDetailDAL();
        }

        // add  invoiceDetail
        public bool AddInvoiceDetail(InvoiceDetail ct) => dal.addInvoiceDetail(ct);

        //
        public List<InvoiceDetail> getListInvoiceDetailByInvoiceID(int id)
        {
            return dal.getListInvoiceDetailByInvoiceID(id);
        }


    }
}
