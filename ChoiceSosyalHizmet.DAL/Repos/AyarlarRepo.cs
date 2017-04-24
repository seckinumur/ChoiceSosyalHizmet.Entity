using ChoiceSosyalHizmet.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
  public class AyarlarRepo
    {
        public static void Ayarla (int EBHRBU,int EBHDU, int SEDDU, int SEDOBU)
        {
            using(DBSosyal db = new DBSosyal())
            {
                var ayarla = db.Ayarlar.FirstOrDefault(p => p.AyarlarID == 1);
                ayarla.EBHRaporBitisUyarisi = EBHRBU.ToString();
                ayarla.EBHDenetimiUyarisi = EBHDU.ToString();
                ayarla.SEDDenetimUyarisi = SEDDU.ToString();
                ayarla.SEDOdemeBitisUyarisi = SEDOBU.ToString();
                db.SaveChanges();
            }
        }
    }
}
