using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmetTest
{
    class Program
    {
        public static void MerhabaDunya()
        {
            Console.WriteLine("Gir: ");
            string al = Console.ReadLine();

           Console.WriteLine( Hesapla.BurayaGelAnam(23, 98,al));

            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            MerhabaDunya();
        }
    }
}
