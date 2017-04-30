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
    public class SEDRepo
    {
        public static string Kaydet(VMSED Al)
        {
            using (DBSosyal db = new DBSosyal())
            {
                bool Bak = db.BasvuraninBilgileri.Any(p => p.TC == Al.TC);
                if (Bak == true)
                {
                    return "Bu Kayıt Daha Önce Kaydedilmiş! Güncellemek İçin Güncelle Butonuna Basınız.";
                }
                else
                {
                    YardimAlaninBilgileri YAB = new YardimAlaninBilgileri()
                    {
                        AdiSoyadi = Al.YardimAlaninAdiSoyadi,
                        TC = Al.YardimAlaninTC,
                        DogumTarihi = Al.YardimAlaninDogumTarihi,
                        YakinlikDurumu = Al.YakinlikDurumu
                    };

                    db.YardimAlaninBilgileri.Add(YAB);
                    db.SaveChanges();

                    SEDDosyaBilgileri SDB = new SEDDosyaBilgileri()
                    {
                        ArsivNo = Al.ArsivNo,
                        BasvuruTarihi = Al.BasvuruTarihi,
                        DosyaTarihi = Al.DosyaTarihi,
                        Durum = Al.Durum,
                        MahalleKoy = Al.mahalleKoy,
                        OdemeBaslangici = Al.OdemeBaslangici,
                        OdemeBitisi = Al.OdemeBitisi,
                        OdemeSuresi = Al.OdemeSuresi,
                        YBSNo = Al.YBSNo,
                        Not = Al.not
                    };

                    db.SEDDosyaBilgileri.Add(SDB);
                    db.SaveChanges();

                    var YABBul = db.YardimAlaninBilgileri.FirstOrDefault(p => p.TC == Al.YardimAlaninTC);
                    var SDBBul = db.SEDDosyaBilgileri.FirstOrDefault(p => p.ArsivNo == Al.ArsivNo);

                    BasvuraninBilgileri BB = new BasvuraninBilgileri()
                    {
                        AdiSoyadi = Al.AdiSoyadi,
                        BasvuruNedeni = Al.BasvuruNedeni,
                        Adres = Al.Adres,
                        DogumTarihi = Al.DogumTarihi,
                        SEDDosyaBilgileriID = SDBBul.SEDDosyaBilgileriID,
                        TC = Al.TC,
                        YardimAlaninBilgileriID = YABBul.YardimAlaninBilgileriID,
                        Telefon = Al.Telefon
                    };

                    db.BasvuraninBilgileri.Add(BB);
                    db.SaveChanges();

                    var BBI = db.BasvuraninBilgileri.FirstOrDefault(p => p.TC == Al.TC);

                    SEDDosyaTakip SDT = new SEDDosyaTakip()
                    {
                        BasvuraninBilgileriID = BBI.BasvuraninBilgileriID,
                        Durum = Al.Durum,
                        Tarih = Al.Tarih
                    };

                    db.SEDDosyaTakip.Add(SDT);
                    db.SaveChanges();
                    return "Kayıt Başarıyla Kaydedildi!";
                }
            }
        }
        public static string Guncelle(VMSED Al)
        {
            using (DBSosyal db = new DBSosyal())
            {
                bool Bak = db.BasvuraninBilgileri.Any(p => p.BasvuraninBilgileriID == Al.BasvuraninBilgileriID);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Önce Sisteme Ekleyin";
                }
                else
                {
                    var Bul = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == Al.BasvuraninBilgileriID);
                    Bul.YardimAlaninBilgileri.AdiSoyadi = Al.YardimAlaninAdiSoyadi;
                    Bul.YardimAlaninBilgileri.DogumTarihi = Al.YardimAlaninDogumTarihi;
                    Bul.YardimAlaninBilgileri.TC = Al.YardimAlaninTC;
                    Bul.YardimAlaninBilgileri.YakinlikDurumu = Al.YakinlikDurumu;
                    Bul.SEDDosyaBilgileri.ArsivNo = Al.ArsivNo;
                    Bul.SEDDosyaBilgileri.BasvuruTarihi = Al.BasvuruTarihi;
                    Bul.SEDDosyaBilgileri.DosyaTarihi = Al.DosyaTarihi;
                    Bul.SEDDosyaBilgileri.Durum = Al.Durum;
                    Bul.SEDDosyaBilgileri.MahalleKoy = Al.mahalleKoy;
                    Bul.SEDDosyaBilgileri.OdemeBaslangici = Al.OdemeBaslangici;
                    Bul.SEDDosyaBilgileri.OdemeBitisi = Al.OdemeBitisi;
                    Bul.SEDDosyaBilgileri.OdemeSuresi = Al.OdemeSuresi;
                    Bul.SEDDosyaBilgileri.YBSNo = Al.YBSNo;
                    Bul.AdiSoyadi = Al.AdiSoyadi;
                    Bul.Adres = Al.Adres;
                    Bul.BasvuruNedeni = Al.BasvuruNedeni;
                    Bul.DogumTarihi = Al.DogumTarihi;
                    Bul.TC = Al.TC;
                    Bul.Telefon = Al.Telefon;
                    Bul.SEDDosyaBilgileri.Not = Al.not;
                    SEDDosyaTakip SDT = new SEDDosyaTakip()
                    {
                        BasvuraninBilgileriID = Bul.BasvuraninBilgileriID,
                        Durum = Al.Durum,
                        Tarih = Al.Tarih
                    };

                    db.SEDDosyaTakip.Add(SDT);
                    db.SaveChanges();
                    return "Kayıt Başarıyla Güncellendi!";
                }
            }
        }
        public static string Sil(string Al)
        {
            int id = int.Parse(Al);
            using (DBSosyal db = new DBSosyal())
            {
                bool Bak = db.BasvuraninBilgileri.Any(p => p.BasvuraninBilgileriID == id);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Sistemde Kayıtlı Olmayan Silinemez!";
                }
                else
                {
                    var Bul = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
                    var Bul2 = db.SEDDosyaBilgileri.FirstOrDefault(p => p.SEDDosyaBilgileriID == Bul.SEDDosyaBilgileriID);
                    var Bul3 = db.YardimAlaninBilgileri.FirstOrDefault(p => p.YardimAlaninBilgileriID == Bul.YardimAlaninBilgileriID);

                    db.SEDDosyaBilgileri.Remove(Bul2);
                    db.YardimAlaninBilgileri.Remove(Bul3);

                    var BBI = db.SEDDosyaTakip.Where(p => p.BasvuraninBilgileriID == Bul.BasvuraninBilgileriID).ToList();

                    foreach (var item in BBI)
                    {
                        db.SEDDosyaTakip.Remove(item);
                    }
                    try
                    {
                        var EZ = db.EvrakZimmetSED.FirstOrDefault(p => p.BasvuraninBilgileriID == Bul.BasvuraninBilgileriID);
                        db.EvrakZimmetSED.Remove(EZ);
                    }
                    catch
                    {
                    }
                    db.BasvuraninBilgileri.Remove(Bul);
                    db.SaveChanges();
                    return "Kayıt Başarıyla Silindi!";
                }
            }
        }
        public static List<VMSED> TumRaporListe()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.BasvuraninBilgileri.Select(a => new VMSED
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.SEDDosyaBilgileri.ArsivNo,
                    BasvuraninBilgileriID = a.BasvuraninBilgileriID,
                    BasvuruNedeni = a.BasvuruNedeni,
                    BasvuruTarihi = a.SEDDosyaBilgileri.BasvuruTarihi,
                    DogumTarihi = a.DogumTarihi,
                    DosyaTarihi = a.SEDDosyaBilgileri.DosyaTarihi,
                    Durum = a.SEDDosyaBilgileri.Durum,
                    mahalleKoy = a.SEDDosyaBilgileri.MahalleKoy,
                    OdemeBaslangici = a.SEDDosyaBilgileri.OdemeBaslangici,
                    OdemeBitisi = a.SEDDosyaBilgileri.OdemeBitisi,
                    OdemeSuresi = a.SEDDosyaBilgileri.OdemeSuresi,
                    SEDDosyaBilgileriID = a.SEDDosyaBilgileriID,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.YardimAlaninBilgileri.YakinlikDurumu,
                    YardimAlaninAdiSoyadi = a.YardimAlaninBilgileri.AdiSoyadi,
                    YardimAlaninBilgileriID = a.YardimAlaninBilgileriID,
                    YardimAlaninDogumTarihi = a.YardimAlaninBilgileri.DogumTarihi,
                    YardimAlaninTC = a.YardimAlaninBilgileri.TC,
                    YBSNo = a.SEDDosyaBilgileri.YBSNo,
                    not= a.SEDDosyaBilgileri.Not
                }).ToList();
                return Bul;
            }
        }
        public static List<VMSEDRapor> RaporListe()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.BasvuraninBilgileri.Select(a => new VMSEDRapor
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
                    Not=a.SEDDosyaBilgileri.Not
                }).ToList();
                return Bul;
            }
        }
        public static VMSED SEDBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.BasvuraninBilgileri.Where(p => p.BasvuraninBilgileriID == id).Select(a => new VMSED
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.SEDDosyaBilgileri.ArsivNo,
                    BasvuraninBilgileriID = a.BasvuraninBilgileriID,
                    BasvuruNedeni = a.BasvuruNedeni,
                    BasvuruTarihi = a.SEDDosyaBilgileri.BasvuruTarihi,
                    DogumTarihi = a.DogumTarihi,
                    DosyaTarihi = a.SEDDosyaBilgileri.DosyaTarihi,
                    Durum = a.SEDDosyaBilgileri.Durum,
                    mahalleKoy = a.SEDDosyaBilgileri.MahalleKoy,
                    OdemeBaslangici = a.SEDDosyaBilgileri.OdemeBaslangici,
                    OdemeBitisi = a.SEDDosyaBilgileri.OdemeBitisi,
                    OdemeSuresi = a.SEDDosyaBilgileri.OdemeSuresi,
                    SEDDosyaBilgileriID = a.SEDDosyaBilgileriID,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.YardimAlaninBilgileri.YakinlikDurumu,
                    YardimAlaninAdiSoyadi = a.YardimAlaninBilgileri.AdiSoyadi,
                    YardimAlaninBilgileriID = a.YardimAlaninBilgileriID,
                    YardimAlaninDogumTarihi = a.YardimAlaninBilgileri.DogumTarihi,
                    YardimAlaninTC = a.YardimAlaninBilgileri.TC,
                    YBSNo = a.SEDDosyaBilgileri.YBSNo,
                    not=a.SEDDosyaBilgileri.Not
                }).FirstOrDefault();
                return Bul;
            }
        }
        public static List<VMDosyaTakip> DosyaTakipBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBSosyal db = new DBSosyal())
            {
              var bul=  db.SEDDosyaTakip.Where(p => p.BasvuraninBilgileriID == id).Select(a => new VMDosyaTakip
                {
                    Durum = a.Durum,
                    ID = a.SEDDosyaTakipID,
                    Tarih = a.Tarih
                }).ToList();
                return bul;
            }
        }
    }
}
