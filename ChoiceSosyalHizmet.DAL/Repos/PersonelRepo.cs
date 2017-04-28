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
        public static string PersonelEkle (VMPersonel personel)
        {
            using(DBSosyal db = new DBSosyal())
            {
                bool varmi = db.Personel.Any(p => p.TC == personel.TC);
                if(varmi== true)
                {
                    return "Bu Personel Daha Önce Kaydedilmiş";
                }
                else
                {
                    Personel Ekle = new Personel()
                    {
                        AdiSoyadi = personel.AdiSoyadi,
                        TC = personel.TC
                    };

                    db.Personel.Add(Ekle);
                    db.SaveChanges();
                    return "Bu Personel Başarıyla Kaydedildi";
                }
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
        public static List<VMPersonel> PersonelRaporla()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Personel.Select(p=> new VMPersonel
                {
                    AdiSoyadi = p.AdiSoyadi,
                    TC = p.TC,
                    PersonelID = p.PersonelID
                }).ToList();
                return Bul;
            }
        }
    }
}
