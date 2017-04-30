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
    public class ZimmetSEDRepo
    {
        public static string ZimmeteEkle(int perid, int id)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var perbul = db.Personel.FirstOrDefault(p => p.PersonelID == perid);
                var bul = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
                EvrakZimmetSED ekle = new EvrakZimmetSED()
                {
                    BasvuraninBilgileriID = bul.BasvuraninBilgileriID,
                    PersonelID = perbul.PersonelID,
                    ZimmeteAlisTarihi = DateTime.Now.ToShortDateString(),
                    Zimmettemi = true
                };
                db.EvrakZimmetSED.Add(ekle);
                db.SaveChanges();
                return perbul.AdiSoyadi;
            }
        }
        public static void ZimmetKaldır(string AS)
        {
            int perid = int.Parse(AS);
            using (DBSosyal db = new DBSosyal())
            {
                var perbul = db.Personel.FirstOrDefault(p => p.PersonelID == perid);

                var ekle = db.EvrakZimmetSED.FirstOrDefault(p => p.EvrakZimmetSEDID == perid);
                ekle.ZimmettenCikisTarihi = DateTime.Now.ToShortDateString();
                ekle.Zimmettemi = false;
                db.SaveChanges();
            }
        }
        public static VMZimmetList ZimmetBul(int id)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.EvrakZimmetSED.Where(p => p.BasvuraninBilgileriID == id && p.Zimmettemi == true).Select(a => new VMZimmetList
                {
                    DosyaAdı = a.BasvuraninBilgileri.AdiSoyadi,
                    DosyaSahibiMahalleKöy = a.BasvuraninBilgileri.SEDDosyaBilgileri.MahalleKoy,
                    DosyaSahibiTC = a.BasvuraninBilgileri.TC,
                    PersonelAdı = a.Personel.AdiSoyadi,
                    ID = a.EvrakZimmetSEDID,
                    ZimmeteAlişTarihi = a.ZimmeteAlisTarihi,
                    Zimmettemi = a.Zimmettemi,
                    ZimmettenÇıkışTarihi = a.ZimmettenCikisTarihi,
                    PersonelID = a.PersonelID
                }).FirstOrDefault();
                return bul;
            }
        }
        public static List<VMZimmetList> ZimmetListele()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.EvrakZimmetSED.Select(a => new VMZimmetList
                {
                    DosyaAdı = a.BasvuraninBilgileri.AdiSoyadi,
                    DosyaSahibiMahalleKöy = a.BasvuraninBilgileri.SEDDosyaBilgileri.MahalleKoy,
                    DosyaSahibiTC = a.BasvuraninBilgileri.TC,
                    PersonelAdı = a.Personel.AdiSoyadi,
                    ID = a.EvrakZimmetSEDID,
                    ZimmeteAlişTarihi = a.ZimmeteAlisTarihi,
                    Zimmettemi = a.Zimmettemi,
                    ZimmettenÇıkışTarihi = a.ZimmettenCikisTarihi
                }).ToList();
                return bul;
            }
        }
    }
}
