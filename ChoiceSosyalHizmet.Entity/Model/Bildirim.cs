using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
   public class Bildirim
    {
        public int BildirimID { get; set; }
        public string Mesaj { get; set; }
        public string Tarih { get; set; }
    }
}
