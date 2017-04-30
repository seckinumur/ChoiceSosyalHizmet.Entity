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
   public class ZimmetEBHRepo
    {
        public static string ZimmeteEkle(int perid, int id)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var perbul = db.Personel.FirstOrDefault(p => p.PersonelID == perid);
                var bul = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                EvrakZimmetEBH ekle = new EvrakZimmetEBH()
                {
                    EngelliBilgileriID = bul.EngelliBilgileriID,
                    PersonelID = perbul.PersonelID,
                    ZimmeteAlisTarihi = DateTime.Now.ToShortDateString(),
                    Zimmettemi = true
                };
                db.EvrakZimmetEBH.Add(ekle);
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

                var ekle = db.EvrakZimmetEBH.FirstOrDefault(p => p.EvrakZimmetEBHID == perid);
                ekle.ZimmettenCikisTarihi = DateTime.Now.ToShortDateString();
                ekle.Zimmettemi = false;
                db.SaveChanges();
            }
        }
        public static VMZimmetList ZimmetBul(int id)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.EvrakZimmetEBH.Where(p => p.EngelliBilgileriID == id && p.Zimmettemi==true).Select(a => new VMZimmetList
                {
                    DosyaAdı = a.EngelliBilgileri.AdiSoyadi,
                    DosyaSahibiMahalleKöy = a.EngelliBilgileri.EBHDosyaBilgileri.MahalleKoy,
                    DosyaSahibiTC = a.EngelliBilgileri.TC,
                    PersonelAdı = a.Personel.AdiSoyadi,
                    ID = a.EvrakZimmetEBHID,
                    ZimmeteAlişTarihi = a.ZimmeteAlisTarihi,
                    Zimmettemi = a.Zimmettemi,
                    ZimmettenÇıkışTarihi = a.ZimmettenCikisTarihi,
                    PersonelID=a.EvrakZimmetEBHID
                }).FirstOrDefault();
                return bul;
            }
        }
        public static List<VMZimmetList> ZimmetListele()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.EvrakZimmetEBH.Select(a => new VMZimmetList
                {
                    DosyaAdı = a.EngelliBilgileri.AdiSoyadi,
                    DosyaSahibiMahalleKöy = a.EngelliBilgileri.EBHDosyaBilgileri.MahalleKoy,
                    DosyaSahibiTC = a.EngelliBilgileri.TC,
                    PersonelAdı = a.Personel.AdiSoyadi,
                    ID = a.EvrakZimmetEBHID,
                    ZimmeteAlişTarihi = a.ZimmeteAlisTarihi,
                    Zimmettemi = a.Zimmettemi,
                    ZimmettenÇıkışTarihi = a.ZimmettenCikisTarihi
                }).ToList();
                return bul;
            }
        }
    }
}
