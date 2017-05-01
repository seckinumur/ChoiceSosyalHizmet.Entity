using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
   public class DenetimSED
    {
        public int DenetimSEDID { get; set; }
        public int BasvuraninBilgileriID { get; set; }
        public string DenetimTarihi { get; set; }
        public bool DenetimeGidildimi { get; set; }

        public virtual BasvuraninBilgileri BasvuraninBilgileri { get; set; }
    }
}
