using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CatagoryDAL
    {
        AppStore db;
        private static CatagoryDAL _intance;
        public static CatagoryDAL Intance
        {
            get
            {
                if(_intance==null) 
                {
                    _intance = new CatagoryDAL();
                    
                }
                return _intance;
            }
            private set { }
        }
        private CatagoryDAL()
        {
            db= new AppStore();
        }
        public List<Category> getALLCatagory()
        {
            return db.Categories.ToList();
        }
        public Category GetCategory(int ID)
        {
            return db.Categories.Find(ID);
        }
    }
}
