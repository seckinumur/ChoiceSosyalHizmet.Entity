using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
    public class DenetimRepo
    {
        
        public static bool DenetimKontrolSED(string ID)
        {
            try
            {
                DateTime tarih = DateTime.Now.Date;
                int id = int.Parse(ID);
                using (DBChoiceEntities db = new DBChoiceEntities())
                {
                    var varsa = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
                    DateTime karsila = Convert.ToDateTime(varsa.DenetimTarihi).AddMonths(6);
                    if (tarih >= karsila)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
           
        }
        public static bool DenetimKontrolEBH(string ID)
        {
            try
            {
                DateTime tarih = DateTime.Now.Date;
                int id = int.Parse(ID);
                using (DBChoiceEntities db = new DBChoiceEntities())
                {
                    var varsa = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                    DateTime karsila = Convert.ToDateTime(varsa.DenetimTarihi).AddMonths(6);
                    if (tarih >= karsila)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
           
        }
        public static List<VMSEDRapor> DenetimGidilmemisSED()
        {
            DateTime tarih = DateTime.Now.Date;
            List<VMSEDRapor> liste = new List<VMSEDRapor>();
            using (DBChoiceEntities db = new DBChoiceEntities())
            {

                var bul = db.BasvuraninBilgileri.ToList();
                foreach (var item in bul)
                {
                    DateTime karsila = Convert.ToDateTime(item.DenetimTarihi).AddMonths(6);
                    var a = db.BasvuraninBilgileri.Where(p => p.BasvuraninBilgileriID == item.BasvuraninBilgileriID).FirstOrDefault();
                    if (tarih >= karsila)
                    {
                        VMSEDRapor albakim = new VMSEDRapor()
                        {
                            DosyaKayıtTarihi = a.DosyaTarihi,
                            ID = a.BasvuraninBilgileriID,
                            BaşvuranınAdıSoyadı = a.AdiSoyadi,
                            BaşvuranınAdres = a.Adres,
                            ArşivNo = a.ArsivNo,
                            BaşvuruNedeni = a.BasvuruNedeni,
                            BaşvuruTarihi = a.BasvuruTarihi,
                            BaşvuranınDoğumTarihi = a.DogumTarihi,
                            Durum = a.Durum,
                            mahalleKöy = a.MahalleKoy,
                            ÖdemeBaşlangıcı = a.OdemeBaslangici,
                            ÖdemeBitişi = a.OdemeBitisi,
                            ÖdemeSüresi = a.OdemeSuresi,
                            BaşvuranınTC = a.TC,
                            BaşvuranınTelefon = a.Telefon,
                            YakınlıkDurumu = a.YardimAlaninYakinlikDurumu,
                            YardımAlanınAdıSoyadı = a.YardimAlaninAdiSoyadi,
                            YardımAlanınDoğumTarihi = a.YardimAlaninDogumTarihi,
                            YardımAlanınTC = a.YardimAlaninTC,
                            YBSNo = a.YBSNo,
                            Not = a.Not
                        };
                        liste.Add(albakim);
                    }

                }

            }
            return liste;
        }
        public static List<VMEBHRapor> DenetimGidilmemisEBH()
        {
            DateTime tarih = DateTime.Now.Date;
            List<VMEBHRapor> liste = new List<VMEBHRapor>();
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.EngelliBilgileri.ToList();
                foreach (var item in bul)
                {
                    DateTime karsila = Convert.ToDateTime(item.DenetimTarihi).AddMonths(6);
                    var a = db.EngelliBilgileri.Where(p => p.EngelliBilgileriID == item.EngelliBilgileriID).FirstOrDefault();
                    if (tarih >= karsila)
                    {
                        VMEBHRapor albakim = new VMEBHRapor()
                        {
                            EngelliAdıSoyadı = a.AdiSoyadi,
                            EngelliAdres = a.Adres,
                            ArşivNo = a.ArsivNo,
                            BakıcıBilgileriAdıSoyadı = a.BakiciBilgileriAdiSoyadi,
                            BakıcıBilgileriDoğumTarihi = a.BakiciBilgileriDogumTarihi,
                            BakıcıBilgileriTC = a.BakiciBilgileriTC,
                            BaşlangıcTarihi = a.BaslangicTarihi,
                            BaşvuruTarihi = a.BasvuruTarihi,
                            BitişTarihi = a.BitisTarihi,
                            EngelliDoğumTarihi = a.DogumTarihi,
                            ID = a.EngelliBilgileriID,
                            Durum = a.Durum,
                            mahalleKöy = a.MahalleKoy,
                            ÖdemeBaşlangıcı = a.OdemeBaslangici,
                            RaporSüresi = a.RaporSuresi,
                            RaporTipi = a.RaporTipi,
                            EngelliTC = a.TC,
                            EngelliTelefon = a.Telefon,
                            YakınlıkDurumu = a.BakiciBilgileriYakinlikDurumu,
                            YBSNo = a.YBSNo,
                            DosyaKayıtTarihi = a.DosyaTarihi,
                            Not = a.Not
                        };
                        liste.Add(albakim);
                    }

                }

            }
            return liste;
        }
        public static void DenetimYapSED(string ID)
        {
            DateTime tarih = DateTime.Now.Date;
            int id = int.Parse(ID);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.BasvuraninBilgileri.Where(p => p.BasvuraninBilgileriID == id ).FirstOrDefault();
                bul.DenetimTarihi = tarih.ToShortDateString();
                db.SaveChanges();
            }
        }
        public static void DenetimYapEBH(string ID)
        {
            DateTime tarih = DateTime.Now.Date;
            int id = int.Parse(ID);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.EngelliBilgileri.Where(p => p.EngelliBilgileriID == id ).FirstOrDefault();
                bul.DenetimTarihi = tarih.ToShortDateString();
                db.SaveChanges();
            }
        }
        public static List<VMSEDRapor> BitisTarihiSED()
        {
            DateTime tarih = DateTime.Now.Date;
            List<VMSEDRapor> liste = new List<VMSEDRapor>();
            using (DBChoiceEntities db = new DBChoiceEntities())
            {

                var abul = db.BasvuraninBilgileri.Where(p=> p.OdemeSuresi != "Tek Seferlik").ToList();
                foreach (var a in abul)
                {
                    DateTime karsila = Convert.ToDateTime(a.OdemeBitisi).AddMonths(-1);
                    if (karsila == tarih)
                    {
                        VMSEDRapor albakim = new VMSEDRapor()
                        {
                            DosyaKayıtTarihi = a.DosyaTarihi,
                            ID = a.BasvuraninBilgileriID,
                            BaşvuranınAdıSoyadı = a.AdiSoyadi,
                            BaşvuranınAdres = a.Adres,
                            ArşivNo = a.ArsivNo,
                            BaşvuruNedeni = a.BasvuruNedeni,
                            BaşvuruTarihi = a.BasvuruTarihi,
                            BaşvuranınDoğumTarihi = a.DogumTarihi,
                            Durum = a.Durum,
                            mahalleKöy = a.MahalleKoy,
                            ÖdemeBaşlangıcı = a.OdemeBaslangici,
                            ÖdemeBitişi = a.OdemeBitisi,
                            ÖdemeSüresi = a.OdemeSuresi,
                            BaşvuranınTC = a.TC,
                            BaşvuranınTelefon = a.Telefon,
                            YakınlıkDurumu = a.YardimAlaninYakinlikDurumu,
                            YardımAlanınAdıSoyadı = a.YardimAlaninAdiSoyadi,
                            YardımAlanınDoğumTarihi = a.YardimAlaninDogumTarihi,
                            YardımAlanınTC = a.YardimAlaninTC,
                            YBSNo = a.YBSNo,
                            Not = a.Not
                        };
                        liste.Add(albakim);
                    }

                }

            }
            return liste;
        }
        public static List<VMEBHRapor> BitisTarihiEBH()
        {
            DateTime tarih = DateTime.Now.Date;
            List<VMEBHRapor> liste = new List<VMEBHRapor>();
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var abul = db.EngelliBilgileri.Where(p=> p.RaporTipi !="Sürekli").ToList();
                foreach (var a in abul)
                {
                    DateTime karsila = Convert.ToDateTime(a.BitisTarihi).AddMonths(-3);
                    if (karsila == tarih)
                    {
                        VMEBHRapor albakim = new VMEBHRapor()
                        {
                            EngelliAdıSoyadı = a.AdiSoyadi,
                            EngelliAdres = a.Adres,
                            ArşivNo = a.ArsivNo,
                            BakıcıBilgileriAdıSoyadı = a.BakiciBilgileriAdiSoyadi,
                            BakıcıBilgileriDoğumTarihi = a.BakiciBilgileriDogumTarihi,
                            BakıcıBilgileriTC = a.BakiciBilgileriTC,
                            BaşlangıcTarihi = a.BaslangicTarihi,
                            BaşvuruTarihi = a.BasvuruTarihi,
                            BitişTarihi = a.BitisTarihi,
                            EngelliDoğumTarihi = a.DogumTarihi,
                            ID = a.EngelliBilgileriID,
                            Durum = a.Durum,
                            mahalleKöy = a.MahalleKoy,
                            ÖdemeBaşlangıcı = a.OdemeBaslangici,
                            RaporSüresi = a.RaporSuresi,
                            RaporTipi = a.RaporTipi,
                            EngelliTC = a.TC,
                            EngelliTelefon = a.Telefon,
                            YakınlıkDurumu = a.BakiciBilgileriYakinlikDurumu,
                            YBSNo = a.YBSNo,
                            DosyaKayıtTarihi = a.DosyaTarihi,
                            Not = a.Not
                        };
                        liste.Add(albakim);
                    }

                }

            }
            return liste;
        }
    }
}
