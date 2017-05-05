using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
   public class VMEBH
    {
        public long EngelliBilgileriID { get; set; }
        public string AdiSoyadi { get; set; }
        public string TC { get; set; }
        public string DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string BakiciBilgileriAdiSoyadi { get; set; }
        public string BakiciBilgileriTC { get; set; }
        public string BakiciBilgileriDogumTarihi { get; set; }
        public string YakinlikDurumu { get; set; }
        public string Durum { get; set; }
        public string mahalleKoy { get; set; }
        public string BasvuruTarihi { get; set; }
        public string RaporTipi { get; set; }
        public string OdemeBaslangici { get; set; }
        public string RaporSuresi { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public string YBSNo { get; set; }
        public string ArsivNo { get; set; }
        public string DosyaTarihi { get; set; }
        public string Not { get; set; }
        public string Tarih { get; set; }
    }
}
