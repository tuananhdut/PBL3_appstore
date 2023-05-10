using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL dal;
        public static CustomerBLL _intance;
        public static CustomerBLL Intance
        {
            get
            {
                if (_intance == null) new CustomerBLL();
                return _intance;
            }
            private set { }
        }
        public CustomerBLL()
        {
            dal = new CustomerDAL();
        }

        // lấy danh sách customer 
        public List<Customer> getALLCustomer() => dal.getALLCustomer();

        // thêm khách hàng
        public bool addAndUpdateCustomer(Customer kh)
        {
            return dal.addAndUpdateCustomer(kh);
        }

        // xóa khách hàng
        public bool removeCustomer(int id) => dal.removeCustomer(id);

        public Customer getCustomerByID(int id) => dal.getCustomerByID(id);

        public List<Customer> searchCustomer(int? id, string name = null, string address = null,string phone = null)
        => dal.searchCustomer(id, name, address, phone);
    }
}
