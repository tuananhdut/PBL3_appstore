using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        AppStore db;
        public static CustomerDAL _intance;
        public static CustomerDAL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new CustomerDAL();
                }
                return _intance;
            }
            private set { }
        }
        public CustomerDAL()
        {
            db = new AppStore();
        }
        //tạo mới khách hàng
        public bool addAndUpdateCustomer(Customer KH)
        {
           
            db.Customers.AddOrUpdate(KH);
            db.SaveChanges();
            return true;
          
        }

        //lấy all khách hàng
        public List<Customer> getALLCustomer() => db.Customers.ToList();

       //xóa khách hàng theo id
        public bool removeCustomer(int id)
        {
            try
            {
                Customer kh = db.Customers.Where(p => p.CustomerID == id).FirstOrDefault();
                db.Customers.Remove(kh);
                db.SaveChanges();
                return true;
            } catch(Exception)
            {
                return false;
            }
            
        }
    }
}
