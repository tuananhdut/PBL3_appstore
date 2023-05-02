using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL dal;
        public static ProductBLL _intance;
        public static ProductBLL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new ProductBLL();
                }
                return _intance;
            }
            private set { }
        }
        public ProductBLL()
        {
            dal = new ProductDAL();
        }

        public List<Product> getALLProduct() => dal.getALLProduct();
    }
}
