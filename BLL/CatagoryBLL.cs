using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CatagoryBLL
    {
        public List<Category> GetCategoriesBLL()

        {
            List<Category> list = new List<Category>();
            list = CatagoryDAL.Intance.getALLCatagory();
            return list;
        }
        public CBBItem getCBBCatagory(Category a)
        {
            return new CBBItem()
            {
                ID = a.CategoryID,
                Text = a.CategoryName
            };
        }
        public List<CBBItem> getAllCBBCatagory()
        {
            List<CBBItem> res = new List<CBBItem>();
            foreach (Category i in GetCategoriesBLL())
            {
                res.Add(getCBBCatagory(i));
            }
            return res;
        }
        public Category getCategoryBLL(int ID)
        {
            return CatagoryDAL.Intance.GetCategory(ID);
        }
    }
}
