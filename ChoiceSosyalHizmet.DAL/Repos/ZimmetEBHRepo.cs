using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
   public class ZimmetEBHRepo
    {
        public static string ZimmeteEkle(int perid, int id)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var perbul = db.Personel.FirstOrDefault(p => p.PersonelID == perid);
                var bul = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                EvrakZimmetEBH ekle = new EvrakZimmetEBH()
                {
                    EngelliBilgileriID = bul.EngelliBilgileriID,
                    PersonelID = perbul.PersonelID,
                    ZimmeteAlisTarihi = DateTime.Now.ToShortDateString(),
                    Zimmettemi = "true"
                };
                db.EvrakZimmetEBH.Add(ekle);
                db.SaveChanges();
                return perbul.AdiSoyadi;
            }
        }
        public static void ZimmetKaldır(string AS)
        {
            int perid = int.Parse(AS);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var perbul = db.Personel.FirstOrDefault(p => p.PersonelID == perid);

                var ekle = db.EvrakZimmetEBH.FirstOrDefault(p => p.EvrakZimmetEBHID == perid);
                ekle.ZimmettenCikisTarihi = DateTime.Now.ToShortDateString();
                ekle.Zimmettemi = "false";
                db.SaveChanges();
            }
        }
        public static VMZimmetList ZimmetBul(long id)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.EvrakZimmetEBH.FirstOrDefault(p => p.EngelliBilgileriID == id && p.Zimmettemi == "true");
                var pers = db.Personel.FirstOrDefault(p => p.PersonelID == bul.PersonelID);
                var kisi = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                VMZimmetList bul1= new VMZimmetList()
                {
                    DosyaAdı = kisi.AdiSoyadi,
                    DosyaSahibiMahalleKöy = kisi.MahalleKoy,
                    DosyaSahibiTC = kisi.TC,
                    PersonelAdı = pers.AdiSoyadi,
                    ID = bul.EvrakZimmetEBHID,
                    ZimmeteAlişTarihi = bul.ZimmeteAlisTarihi,
                    Zimmettemi =bul.Zimmettemi,
                    ZimmettenÇıkışTarihi = bul.ZimmettenCikisTarihi,
                    PersonelID=pers.PersonelID
                };
                return bul1;
            }
        }
        public static List<VMZimmetList> ZimmetListele()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                List<VMZimmetList> bul11 = new List<VMZimmetList>();
                var item = db.EvrakZimmetEBH.ToList();
                foreach (var bul in item)
                {
                    var pers = db.Personel.FirstOrDefault(p => p.PersonelID == bul.PersonelID);
                    var kisi = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == bul.EngelliBilgileriID);
                    VMZimmetList bul1 = new VMZimmetList()
                    {
                        DosyaAdı = kisi.AdiSoyadi,
                        DosyaSahibiMahalleKöy = kisi.MahalleKoy,
                        DosyaSahibiTC = kisi.TC,
                        PersonelAdı = pers.AdiSoyadi,
                        ID = bul.EvrakZimmetEBHID,
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
