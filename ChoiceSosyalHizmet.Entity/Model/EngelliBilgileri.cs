using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
  public  class EngelliBilgileri
    {
        public int EngelliBilgileriID { get; set; }
        public string AdiSoyadi { get; set; }
        public string TC { get; set; }
        public string DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public int BakiciBilgileriID { get; set; }
        public int EBHDosyaBilgileriID { get; set; }

        public virtual BakiciBilgileri BakiciBilgileri { get; set; }
        public virtual EBHDosyaBilgileri EBHDosyaBilgileri { get; set; }

    }
}
