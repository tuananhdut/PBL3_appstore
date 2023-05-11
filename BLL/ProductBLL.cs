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
        public Product GetProductBLL(int ID)
        {
            Product results = new Product();
            results = ProductDAL.Intance.getProductByID(ID);
            return results;
        }
        public List<Product> GetProductsBLL()
        {
            List<Product> list = new List<Product>();
            list = ProductDAL.Intance.getProducts();
            return list;
        }
        public void AddOrUpdateBLL(Product p)
        {
            ProductDAL.Intance.updateAndAddProduct(p);
        }
        public void DeleteBLL(int del)
        {
            Product p = ProductDAL.Intance.getProductByID(del);
            ProductDAL.Intance.deleteProduct(p);
        }
        
    }
}
