using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        AppStore db;
        private static ProductDAL _intance;
        public static ProductDAL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new ProductDAL();
                }
                return _intance;
            }
            private set { }
        }
        public ProductDAL()
        {
            db = new AppStore();
        }

        
        public Product getProductByID(int id)
        {
               return db.Products.Where(p => p.ProductID == id).FirstOrDefault();
        }
        public List<Product> getProducts() 
        {
            List<Product> result = new List<Product>();
            result = db.Products.ToList();
            return result;
        }
        public void updateAndAddProduct(Product p)
        {
            db.Products.AddOrUpdate(p);
            db.SaveChanges();
        }
        public void deleteProduct(Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
        }
        
    }
}
