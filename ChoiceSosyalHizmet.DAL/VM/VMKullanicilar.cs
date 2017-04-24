using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
  public class VMKullanicilar
    {
        public int KullanicilarID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool Admin { get; set; }
    }
}
