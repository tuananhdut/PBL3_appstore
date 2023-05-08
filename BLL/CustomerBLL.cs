using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (_intance == null)
                {
                    new CustomerBLL();
                }
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
        public bool addAndUpdateCustomer(Customer kh) => dal.addAndUpdateCustomer(kh);

        // xóa khách hàng
        public bool removeCustomer(int id) => dal.removeCustomer(id);


    }
}
