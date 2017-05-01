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
    public class DenetimRepo
    {
        public static void DenetimSEDAI()
        {
            using (DBSosyal db = new DBSosyal())
            {
                DateTime tarih = DateTime.Now.Date;

                var ara = db.BasvuraninBilgileri.Where(p => p.SEDDosyaBilgileri.OdemeSuresi != "Tek Seferlik").ToList();
                foreach (var item in ara)
                {
                    bool bak = db.DenetimSED.Any(p => p.BasvuraninBilgileriID == item.BasvuraninBilgileriID);
                    DateTime karsila = Convert.ToDateTime(item.SEDDosyaBilgileri.OdemeBaslangici).AddMonths(6);
                    if (karsila >= tarih && bak == false)
                    {
                        DenetimSED yap = new DenetimSED()
                        {
                            BasvuraninBilgileriID = item.BasvuraninBilgileriID,
                            DenetimeGidildimi = false,
                            DenetimTarihi = item.SEDDosyaBilgileri.OdemeBaslangici
                        };
                        db.DenetimSED.Add(yap);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void DenetimEBHAI()
        {
            using (DBSosyal db = new DBSosyal())
            {
                DateTime tarih = DateTime.Now.Date;

                var ara = db.EngelliBilgileri.ToList();
                foreach (var item in ara)
                {
                    bool bak = db.DenetimEBH.Any(p => p.EngelliBilgileriID == item.EngelliBilgileriID);
                    DateTime karsila = Convert.ToDateTime(item.EBHDosyaBilgileri.OdemeBaslangici).AddMonths(6);
                    if (karsila >= tarih && bak == false)
                    {
                        DenetimEBH yap = new DenetimEBH()
                        {
                            EngelliBilgileriID = item.EngelliBilgileriID,
                            DenetimeGidildimi = false,
                            DenetimTarihi = item.EBHDosyaBilgileri.OdemeBaslangici
                        };
                        db.DenetimEBH.Add(yap);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static bool DenetimKontrolSED(string ID)
        {
            DateTime tarih = DateTime.Now.Date;
            int id = int.Parse(ID);
            using (DBSosyal db = new DBSosyal())
            {
                var varsa = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
                bool bul = db.DenetimSED.Any(p => p.BasvuraninBilgileriID == id && p.DenetimeGidildimi == false);
                DateTime karsila = Convert.ToDateTime(varsa.SEDDosyaBilgileri.OdemeBaslangici).AddMonths(6);
                if (karsila >= tarih && bul == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool DenetimKontrolEBH(string ID)
        {
            DateTime tarih = DateTime.Now.Date;
            int id = int.Parse(ID);
            using (DBSosyal db = new DBSosyal())
            {
                var varsa = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                bool bul = db.DenetimEBH.Any(p => p.EngelliBilgileriID == id && p.DenetimeGidildimi == false);
                DateTime karsila = Convert.ToDateTime(varsa.EBHDosyaBilgileri.OdemeBaslangici).AddMonths(6);
                if (karsila >= tarih && bul == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static List<VMSEDRapor> DenetimGidilmemisSED()
        {
            DateTime tarih = DateTime.Now.Date;
            List<VMSEDRapor> liste = new List<VMSEDRapor>();
            using (DBSosyal db = new DBSosyal())
            {

                var bul = db.DenetimSED.ToList();
                foreach (var item in bul)
                {
                    DateTime karsila = Convert.ToDateTime(item.DenetimTarihi).AddMonths(6);
                    var a = db.BasvuraninBilgileri.Where(p => p.BasvuraninBilgileriID == item.BasvuraninBilgileriID).FirstOrDefault();
                    if (karsila >= tarih)
                    {
                        VMSEDRapor albakim = new VMSEDRapor()
                        {
                            DosyaKayıtTarihi = a.SEDDosyaBilgileri.DosyaTarihi,
                            ID = a.BasvuraninBilgileriID,
                            BaşvuranınAdıSoyadı = a.AdiSoyadi,
                            BaşvuranınAdres = a.Adres,
                            ArşivNo = a.SEDDosyaBilgileri.ArsivNo,
                            BaşvuruNedeni = a.BasvuruNedeni,
                            BaşvuruTarihi = a.SEDDosyaBilgileri.BasvuruTarihi,
                            BaşvuranınDoğumTarihi = a.DogumTarihi,
                            Durum = a.SEDDosyaBilgileri.Durum,
                            mahalleKöy = a.SEDDosyaBilgileri.MahalleKoy,
                            ÖdemeBaşlangıcı = a.SEDDosyaBilgileri.OdemeBaslangici,
                            ÖdemeBitişi = a.SEDDosyaBilgileri.OdemeBitisi,
                            ÖdemeSüresi = a.SEDDosyaBilgileri.OdemeSuresi,
                            BaşvuranınTC = a.TC,
                            BaşvuranınTelefon = a.Telefon,
                            YakınlıkDurumu = a.YardimAlaninBilgileri.YakinlikDurumu,
                            YardımAlanınAdıSoyadı = a.YardimAlaninBilgileri.AdiSoyadi,
                            YardımAlanınDoğumTarihi = a.YardimAlaninBilgileri.DogumTarihi,
                            YardımAlanınTC = a.YardimAlaninBilgileri.TC,
                            YBSNo = a.SEDDosyaBilgileri.YBSNo,
                            Not = a.SEDDosyaBilgileri.Not
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
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.DenetimEBH.ToList();
                foreach (var item in bul)
                {
                    DateTime karsila = Convert.ToDateTime(item.DenetimTarihi).AddMonths(6);
                    var a = db.EngelliBilgileri.Where(p => p.EngelliBilgileriID == item.EngelliBilgileriID).FirstOrDefault();
                    if (karsila >= tarih)
                    {
                        VMEBHRapor albakim = new VMEBHRapor()
                        {
                            EngelliAdıSoyadı = a.AdiSoyadi,
                            EngelliAdres = a.Adres,
                            ArşivNo = a.EBHDosyaBilgileri.ArsivNo,
                            BakıcıBilgileriAdıSoyadı = a.BakiciBilgileri.AdiSoyadi,
                            BakıcıBilgileriDoğumTarihi = a.BakiciBilgileri.DogumTarihi,
                            BakıcıBilgileriTC = a.BakiciBilgileri.TC,
                            BaşlangıcTarihi = a.EBHDosyaBilgileri.BaslangicTarihi,
                            BaşvuruTarihi = a.EBHDosyaBilgileri.BasvuruTarihi,
                            BitişTarihi = a.EBHDosyaBilgileri.BitisTarihi,
                            EngelliDoğumTarihi = a.DogumTarihi,
                            ID = a.EngelliBilgileriID,
                            Durum = a.EBHDosyaBilgileri.Durum,
                            mahalleKöy = a.EBHDosyaBilgileri.MahalleKoy,
                            ÖdemeBaşlangıcı = a.EBHDosyaBilgileri.OdemeBaslangici,
                            RaporSüresi = a.EBHDosyaBilgileri.RaporSuresi,
                            RaporTipi = a.EBHDosyaBilgileri.RaporTipi,
                            EngelliTC = a.TC,
                            EngelliTelefon = a.Telefon,
                            YakınlıkDurumu = a.BakiciBilgileri.YakinlikDurumu,
                            YBSNo = a.EBHDosyaBilgileri.YBSNo,
                            DosyaKayıtTarihi = a.EBHDosyaBilgileri.DosyaTarihi,
                            Not = a.EBHDosyaBilgileri.Not
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
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.DenetimSED.Where(p => p.BasvuraninBilgileriID == id && p.DenetimeGidildimi == false).FirstOrDefault();
                bul.DenetimTarihi = tarih.ToShortDateString();
                bul.DenetimeGidildimi = true;
                db.SaveChanges();
            }
        }
        public static void DenetimYapEBH(string ID)
        {
            DateTime tarih = DateTime.Now.Date;
            int id = int.Parse(ID);
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.DenetimEBH.Where(p => p.EngelliBilgileriID == id && p.DenetimeGidildimi == false).FirstOrDefault();
                bul.DenetimTarihi = tarih.ToShortDateString();
                bul.DenetimeGidildimi = true;
                db.SaveChanges();
            }
        }
        public static List<VMSEDRapor> BitisTarihiSED()
        {
            DateTime tarih = DateTime.Now.Date;
            List<VMSEDRapor> liste = new List<VMSEDRapor>();
            using (DBSosyal db = new DBSosyal())
            {

                var abul = db.BasvuraninBilgileri.ToList();
                foreach (var a in abul)
                {
                    DateTime karsila = Convert.ToDateTime(a.SEDDosyaBilgileri.OdemeBitisi).AddMonths(-1);
                    if (karsila == tarih)
                    {
                        VMSEDRapor albakim = new VMSEDRapor()
                        {
                            DosyaKayıtTarihi = a.SEDDosyaBilgileri.DosyaTarihi,
                            ID = a.BasvuraninBilgileriID,
                            BaşvuranınAdıSoyadı = a.AdiSoyadi,
                            BaşvuranınAdres = a.Adres,
                            ArşivNo = a.SEDDosyaBilgileri.ArsivNo,
                            BaşvuruNedeni = a.BasvuruNedeni,
                            BaşvuruTarihi = a.SEDDosyaBilgileri.BasvuruTarihi,
                            BaşvuranınDoğumTarihi = a.DogumTarihi,
                            Durum = a.SEDDosyaBilgileri.Durum,
                            mahalleKöy = a.SEDDosyaBilgileri.MahalleKoy,
                            ÖdemeBaşlangıcı = a.SEDDosyaBilgileri.OdemeBaslangici,
                            ÖdemeBitişi = a.SEDDosyaBilgileri.OdemeBitisi,
                            ÖdemeSüresi = a.SEDDosyaBilgileri.OdemeSuresi,
                            BaşvuranınTC = a.TC,
                            BaşvuranınTelefon = a.Telefon,
                            YakınlıkDurumu = a.YardimAlaninBilgileri.YakinlikDurumu,
                            YardımAlanınAdıSoyadı = a.YardimAlaninBilgileri.AdiSoyadi,
                            YardımAlanınDoğumTarihi = a.YardimAlaninBilgileri.DogumTarihi,
                            YardımAlanınTC = a.YardimAlaninBilgileri.TC,
                            YBSNo = a.SEDDosyaBilgileri.YBSNo,
                            Not = a.SEDDosyaBilgileri.Not
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
            using (DBSosyal db = new DBSosyal())
            {
                var abul = db.EngelliBilgileri.ToList();
                foreach (var a in abul)
                {
                    DateTime karsila = Convert.ToDateTime(a.EBHDosyaBilgileri.BitisTarihi).AddMonths(-3);
                    if (karsila == tarih)
                    {
                        VMEBHRapor albakim = new VMEBHRapor()
                        {
                            EngelliAdıSoyadı = a.AdiSoyadi,
                            EngelliAdres = a.Adres,
                            ArşivNo = a.EBHDosyaBilgileri.ArsivNo,
                            BakıcıBilgileriAdıSoyadı = a.BakiciBilgileri.AdiSoyadi,
                            BakıcıBilgileriDoğumTarihi = a.BakiciBilgileri.DogumTarihi,
                            BakıcıBilgileriTC = a.BakiciBilgileri.TC,
                            BaşlangıcTarihi = a.EBHDosyaBilgileri.BaslangicTarihi,
                            BaşvuruTarihi = a.EBHDosyaBilgileri.BasvuruTarihi,
                            BitişTarihi = a.EBHDosyaBilgileri.BitisTarihi,
                            EngelliDoğumTarihi = a.DogumTarihi,
                            ID = a.EngelliBilgileriID,
                            Durum = a.EBHDosyaBilgileri.Durum,
                            mahalleKöy = a.EBHDosyaBilgileri.MahalleKoy,
                            ÖdemeBaşlangıcı = a.EBHDosyaBilgileri.OdemeBaslangici,
                            RaporSüresi = a.EBHDosyaBilgileri.RaporSuresi,
                            RaporTipi = a.EBHDosyaBilgileri.RaporTipi,
                            EngelliTC = a.TC,
                            EngelliTelefon = a.Telefon,
                            YakınlıkDurumu = a.BakiciBilgileri.YakinlikDurumu,
                            YBSNo = a.EBHDosyaBilgileri.YBSNo,
                            DosyaKayıtTarihi = a.EBHDosyaBilgileri.DosyaTarihi,
                            Not = a.EBHDosyaBilgileri.Not
                        };
                        liste.Add(albakim);
                    }

                }

            }
            return liste;
        }
    }
}
