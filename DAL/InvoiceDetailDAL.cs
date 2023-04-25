using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceDetailDAL
    {
        AppStore db;
        public static InvoiceDetailDAL _intance;
        public static InvoiceDetailDAL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new InvoiceDetailDAL();
                }
                return _intance;
            }
            private set { }
        }

        //contructer
        public InvoiceDetailDAL()
        {
            db = new AppStore();
        }

        // add InvoiceDetail
        public bool addInvoiceDetail(InvoiceDetail ct)
        {
            try
            {
                db.InvoiceDetails.Add(ct);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // trả về danh sách InvoiceDetail theo invoiceID
        public List<InvoiceDetail> getListInvoiceDetailByInvoiceID(int id)
        {
            return db.InvoiceDetails.Where(p => p.InvoiceID == id).ToList();
        }
    }
}
