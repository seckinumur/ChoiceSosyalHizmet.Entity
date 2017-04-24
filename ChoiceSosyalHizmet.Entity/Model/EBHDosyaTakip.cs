using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
  public  class EBHDosyaTakip
    {
        public int EBHDosyaTakipID { get; set; }
        public int EngelliBilgileriID { get; set; }
        public string Tarih { get; set; }
        public string Durum { get; set; }

        public virtual EngelliBilgileri EngelliBilgileri { get; set; }
    }
}
