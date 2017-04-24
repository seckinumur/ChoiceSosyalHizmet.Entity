using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
   public class SEDDosyaTakip
    {
        public int SEDDosyaTakipID { get; set; }
        public int BasvuraninBilgileriID { get; set; }
        public string Tarih { get; set; }
        public string Durum { get; set; }

        public virtual BasvuraninBilgileri BasvuraninBilgileri { get; set; }
    }
}
