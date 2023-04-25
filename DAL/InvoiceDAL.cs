using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceDAL
    {
        AppStore db;
        public static InvoiceDAL _intance;
        public static InvoiceDAL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new InvoiceDAL();
                }
                return _intance;
            }
            private set { }
        }

        //contructer
        public InvoiceDAL()
        {
            db = new AppStore();
        }

        // add invoice
        public bool addInvoice(Invoice hd)
        {
            try
            {
                db.Invoices.AddOrUpdate(hd);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
