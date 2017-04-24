using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.Context;
using ChoiceSosyalHizmet.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
   public class PersonelRepo
    {
        public static void PersonelEkle (VMPersonel personel)
        {
            using(DBSosyal db = new DBSosyal())
            {
                Personel Ekle = new Personel()
                {
                    AdiSoyadi = personel.AdiSoyadi,
                    TC = personel.TC
                };

                db.Personel.Add(Ekle);
                db.SaveChanges();
            }
        }
        public static void PersonelGuncelle(VMPersonel personel)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Personel.FirstOrDefault(p => p.PersonelID == personel.PersonelID);
                Bul.AdiSoyadi = personel.AdiSoyadi;
                Bul.TC = personel.TC;
                db.SaveChanges();
            }
        }
        public static void PersonelSil(VMPersonel personel)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Personel.FirstOrDefault(p => p.PersonelID == personel.PersonelID);
                db.Personel.Remove(Bul);
                db.SaveChanges();
            }
        }
    }
}
