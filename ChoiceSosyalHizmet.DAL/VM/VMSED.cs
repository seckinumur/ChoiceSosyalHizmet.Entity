using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
   public class VMSED
    {
        public int BasvuraninBilgileriID { get; set; }
        public string AdiSoyadi { get; set; }
        public string TC { get; set; }
        public string DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string BasvuruNedeni { get; set; }

        public int YardimAlaninBilgileriID { get; set; }
        public string YardimAlaninAdiSoyadi { get; set; }
        public string YardimAlaninTC { get; set; }
        public string YardimAlaninDogumTarihi { get; set; }
        public string YakinlikDurumu { get; set; }

        public int SEDDosyaBilgileriID { get; set; }
        public string Durum { get; set; }
        public string mahalleKoy { get; set; }
        public string BasvuruTarihi { get; set; }
        public string OdemeSuresi { get; set; }
        public string OdemeBaslangici { get; set; }
        public string OdemeBitisi { get; set; }
        public string YBSNo { get; set; }
        public string ArsivNo { get; set; }
        public string DosyaTarihi { get; set; }
        public string not { get; set; }

        public int SEDDosyaTakipID { get; set; }
        public string Tarih { get; set; }
    }
}
