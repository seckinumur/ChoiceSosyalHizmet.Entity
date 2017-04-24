using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
   public class EBHDosyaBilgileri
    {
        public int EBHDosyaBilgileriID { get; set; }
        public string Durum { get; set; }
        public string MahalleKoy { get; set; }
        public string BasvuruTarihi { get; set; }
        public string RaporTipi { get; set; }
        public string OdemeBaslangici { get; set; }
        public string RaporSuresi { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public string YBSNo { get; set; }
        public string ArsivNo { get; set; }
        public string DosyaTarihi { get; set; }
    }
}
