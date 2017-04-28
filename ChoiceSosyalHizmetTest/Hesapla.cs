using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmetTest
{
  public class Hesapla
    {
        public Hesapla(int a, int b)
        {
            
        }
        private static int Topla(int a, int b)
        {
            int sonuc;
          return  sonuc = a + b;

        }
        public static int BurayaGelAnam(int d,int b,string Al)
        {
            if (Al == "+")
            {
               return Topla(d, b);
            }
            else
            {
                return 0;
            }
        }
    }
}
