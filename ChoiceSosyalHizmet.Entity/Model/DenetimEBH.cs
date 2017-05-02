using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
   public class DenetimEBH
    {
        public int DenetimEBHID { get; set; }
        public int EngelliBilgileriID { get; set; }
        public string DenetimTarihi { get; set; }

        public virtual EngelliBilgileri EngelliBilgileri { get; set; }
    }
}
