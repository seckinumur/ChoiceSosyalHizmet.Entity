using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
    public class ZimmetSEDRepo
    {
        public static string ZimmeteEkle(int perid, int id)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var perbul = db.Personel.FirstOrDefault(p => p.PersonelID == perid);
                var bul = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
                EvrakZimmetSED ekle = new EvrakZimmetSED()
                {
                    BasvuraninBilgileriID = bul.BasvuraninBilgileriID,
                    PersonelID = perbul.PersonelID,
                    ZimmeteAlisTarihi = DateTime.Now.ToShortDateString(),
                    Zimmettemi = "Evet"
                };
                db.EvrakZimmetSED.Add(ekle);
                db.SaveChanges();
                return perbul.AdiSoyadi;
            }
        }
        public static void ZimmetKaldır(string AS)
        {
            int perid = int.Parse(AS);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var ekle = db.EvrakZimmetSED.FirstOrDefault(p => p.EvrakZimmetSEDID == perid);
                ekle.ZimmettenCikisTarihi = DateTime.Now.ToShortDateString();
                ekle.Zimmettemi = "Hayır";
                db.SaveChanges();
            }
        }
        public static VMZimmetList ZimmetBul(long id)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.EvrakZimmetSED.FirstOrDefault(p => p.BasvuraninBilgileriID == id && p.Zimmettemi == "Evet");
                var pers = db.Personel.FirstOrDefault(p => p.PersonelID == bul.PersonelID);
                var kisi = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
                VMZimmetList bul1 = new VMZimmetList()
                {
                    DosyaAdı = kisi.AdiSoyadi,
                    DosyaSahibiMahalleKöy = kisi.MahalleKoy,
                    DosyaSahibiTC = kisi.TC,
                    PersonelAdı = pers.AdiSoyadi,
                    ID = bul.EvrakZimmetSEDID,
                    ZimmeteAlişTarihi = bul.ZimmeteAlisTarihi,
                    Zimmettemi = bul.Zimmettemi,
                    ZimmettenÇıkışTarihi = bul.ZimmettenCikisTarihi,
                    PersonelID = pers.PersonelID
                };
                return bul1;
            }
        }
        public static List<VMZimmetList> ZimmetListele()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                List<VMZimmetList> bul11 = new List<VMZimmetList>();
                var item = db.EvrakZimmetSED.ToList();
                foreach (var bul in item)
                {
                    var pers = db.Personel.FirstOrDefault(p => p.PersonelID == bul.PersonelID);
                    var kisi = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == bul.BasvuraninBilgileriID);
                    VMZimmetList bul1 = new VMZimmetList()
                    {
                        DosyaAdı = kisi.AdiSoyadi,
                        DosyaSahibiMahalleKöy = kisi.MahalleKoy,
                        DosyaSahibiTC = kisi.TC,
                        PersonelAdı = pers.AdiSoyadi,
                        ID = bul.BasvuraninBilgileriID,
                        ZimmeteAlişTarihi = bul.ZimmeteAlisTarihi,
                        Zimmettemi = bul.Zimmettemi,
                        ZimmettenÇıkışTarihi = bul.ZimmettenCikisTarihi,
                        PersonelID = pers.PersonelID
                    };
                    bul11.Add(bul1);
                }

                return bul11;
            }
        }
    }
}
