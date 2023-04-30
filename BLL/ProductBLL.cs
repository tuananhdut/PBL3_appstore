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
       public Product GetProductBLL()
       {
            return new Product();
       }
       public List<Product> GetListProduct()
        {
            List<Product> list = new List<Product>();
            list = ProductDAL.Intance.getProducts();
            return list;
        }   
    }
}
