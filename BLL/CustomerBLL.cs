using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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


        //kiểm tra người dùng đã tồn tại chưa (phone, name, address)
        public Customer GetCustomerByPhoneAndNameAndAddred(string Phone, string name, string address)
        => dal.GetCustomerByPhoneAndNameAndAddred(Phone, name, address);


        // thêm khách hàng
        public bool addCustomer(Customer kh)
        {
            return dal.AddCustomer(kh);
        }

    }
}
