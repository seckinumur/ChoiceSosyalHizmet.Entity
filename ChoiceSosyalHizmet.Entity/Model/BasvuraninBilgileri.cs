using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
  public  class BasvuraninBilgileri
    {
        public int BasvuraninBilgileriID { get; set; }
        public string AdiSoyadi { get; set; }
        public string TC { get; set; }
        public string DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string BasvuruNedeni { get; set; }
        public int YardimAlaninBilgileriID { get; set; }
        public int SEDDosyaBilgileriID { get; set; }

        public virtual YardimAlaninBilgileri YardimAlaninBilgileri { get; set; }
        public virtual SEDDosyaBilgileri SEDDosyaBilgileri { get; set; }

    }
}
