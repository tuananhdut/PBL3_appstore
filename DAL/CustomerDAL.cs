using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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
                Customer kh = db.Customers.Find(id);
                db.Customers.Remove(kh);
                db.SaveChanges();
                return true;
            } catch(Exception)
            {
                return false;
            }
            
        }
        public Customer getCustomerByID(int? id)
        {
            return db.Customers.Where(p=>p.CustomerID==id).FirstOrDefault();
        }

        public List<Customer> getCustomersByNameOrAddressOrPhone(string str)
        {
            return db.Customers.Where(p => p.Address.Contains(str) || p.PhoneNumber.Contains(str)|| p.FullName.Contains(str)).ToList();
        }
        public List<Customer> searchCustomer(int? id, string name = null, string address = null, string phone = null)
        {
            List<Customer> li = new List<Customer>();
            li = db.Customers.ToList();
            if (id!=null)
            {
                li = li.Where(p => p.CustomerID == id).ToList();
            } 
            if (name != null)
            {
                li = li.Where(p => p.FullName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            } 
            if (address!= null)
            {
                li = li.Where(p => p.Address.IndexOf(address, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            } 
            if (phone != null)
            {
                li = li.Where(p => p.PhoneNumber==phone).ToList();
            }
            return li;
        }
    }
}
