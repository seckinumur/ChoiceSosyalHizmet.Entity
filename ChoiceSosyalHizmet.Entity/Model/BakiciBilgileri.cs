using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
   public class BakiciBilgileri
    {
        public int BakiciBilgileriID { get; set; }
        public string AdiSoyadi { get; set; }
        public string TC { get; set; }
        public string DogumTarihi { get; set; }
        public string YakinlikDurumu { get; set; }
    }
}
