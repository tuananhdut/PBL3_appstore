using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoDien.Utils
{
    public  class PriceBeforeDiscount
    {
       public static double tinhTienGiamGia(int price,int discount, int soluong)
        {

            return soluong*price*discount*0.01;
        }
    
    }
}
