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
        public static string PersonelEkle(VMPersonel personel)
        {
            using (DBSosyal db = new DBSosyal())
            {
                bool varmi = db.Personel.Any(p => p.TC == personel.TC);
                if (varmi == true)
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
        public static string PersonelGuncelle(VMPersonel personel)
        {
            using (DBSosyal db = new DBSosyal())
            {
                try
                {
                    var Bul = db.Personel.FirstOrDefault(p => p.PersonelID == personel.PersonelID);
                    Bul.AdiSoyadi = personel.AdiSoyadi;
                    Bul.TC = personel.TC;
                    db.SaveChanges();
                    return "Bu Personel Başarıyla Güncelleştirildi!";
                }
                catch
                {
                    return "Önce Personeli Kaydetmelisiniz!";
                }

            }
        }
        public static string PersonelSil(string ID)
        {
            int id = int.Parse(ID);
            using (DBSosyal db = new DBSosyal())
            {
                try
                {
                    var Bul = db.Personel.FirstOrDefault(p => p.PersonelID == id);
                    db.Personel.Remove(Bul);
                    db.SaveChanges();
                    return "Başarıyla Silindi!";
                }
                catch
                {
                    return "Silme Başarısız!";
                }
            }
        }
        public static List<VMPersonel> PersonelRaporla()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Personel.Select(p => new VMPersonel
                {
                    AdiSoyadi = p.AdiSoyadi,
                    TC = p.TC,
                    PersonelID = p.PersonelID
                }).ToList();
                return Bul;
            }
        }
        public static VMPersonel PersonelBul(string ID)
        {
            int id = int.Parse(ID);
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Personel.Where(p => p.PersonelID == id).Select(a => new VMPersonel
                {
                    AdiSoyadi = a.AdiSoyadi,
                    PersonelID = a.PersonelID,
                    TC = a.TC
                }).FirstOrDefault();
                return Bul;
            }
        }
    }
}

