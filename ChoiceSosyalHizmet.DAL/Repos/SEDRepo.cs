using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.DB;
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
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                bool Bak = db.BasvuraninBilgileri.Any(p => p.TC == Al.TC);
                if (Bak == true)
                {
                    return "Bu Kayıt Daha Önce Kaydedilmiş!";
                }
                else
                {
                    BasvuraninBilgileri BB = new BasvuraninBilgileri()
                    {
                        AdiSoyadi = Al.AdiSoyadi,
                        BasvuruNedeni = Al.BasvuruNedeni,
                        Adres = Al.Adres,
                        DogumTarihi = Al.DogumTarihi,
                        TC = Al.TC,
                        Telefon = Al.Telefon,
                        YardimAlaninAdiSoyadi = Al.YardimAlaninAdiSoyadi,
                        YardimAlaninTC = Al.YardimAlaninTC,
                        YardimAlaninDogumTarihi = Al.YardimAlaninDogumTarihi,
                        YardimAlaninYakinlikDurumu = Al.YakinlikDurumu,
                        ArsivNo = Al.ArsivNo,
                        BasvuruTarihi = Al.BasvuruTarihi,
                        DosyaTarihi = Al.DosyaTarihi,
                        Durum = Al.Durum,
                        MahalleKoy = Al.mahalleKoy,
                        OdemeBaslangici = Al.OdemeBaslangici,
                        OdemeBitisi = Al.OdemeBitisi,
                        OdemeSuresi = Al.OdemeSuresi,
                        YBSNo = Al.YBSNo,
                        Not = Al.not,
                        DenetimTarihi= DateTime.Now.ToShortDateString()
                    };
                    
                    bool varmi = db.MahalleKoy.Any(p => p.Isim == Al.mahalleKoy);
                    if (varmi != true)
                    {
                        MahalleKoy Ekle = new MahalleKoy()
                        {
                            Isim = Al.mahalleKoy
                        };

                        db.MahalleKoy.Add(Ekle);
                        db.SaveChanges();
                    }
                    
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
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                bool Bak = db.BasvuraninBilgileri.Any(p => p.BasvuraninBilgileriID == Al.BasvuraninBilgileriID);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Önce Sisteme Ekleyin";
                }
                else
                {
                    var Bul = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == Al.BasvuraninBilgileriID);
                    Bul.YardimAlaninAdiSoyadi = Al.YardimAlaninAdiSoyadi;
                    Bul.YardimAlaninDogumTarihi = Al.YardimAlaninDogumTarihi;
                    Bul.YardimAlaninTC = Al.YardimAlaninTC;
                    Bul.YardimAlaninYakinlikDurumu = Al.YakinlikDurumu;
                    Bul.ArsivNo = Al.ArsivNo;
                    Bul.BasvuruTarihi = Al.BasvuruTarihi;
                    Bul.DosyaTarihi = Al.DosyaTarihi;
                    Bul.Durum = Al.Durum;
                    Bul.MahalleKoy = Al.mahalleKoy;
                    Bul.OdemeBaslangici = Al.OdemeBaslangici;
                    Bul.OdemeBitisi = Al.OdemeBitisi;
                    Bul.OdemeSuresi = Al.OdemeSuresi;
                    Bul.YBSNo = Al.YBSNo;
                    Bul.AdiSoyadi = Al.AdiSoyadi;
                    Bul.Adres = Al.Adres;
                    Bul.BasvuruNedeni = Al.BasvuruNedeni;
                    Bul.DogumTarihi = Al.DogumTarihi;
                    Bul.TC = Al.TC;
                    Bul.Telefon = Al.Telefon;
                    Bul.Not = Al.not;
                    Bul.DenetimTarihi = Al.OdemeBaslangici;
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
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                bool Bak = db.BasvuraninBilgileri.Any(p => p.BasvuraninBilgileriID == id);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Sistemde Kayıtlı Olmayan Silinemez!";
                }
                else
                {
                    var Bul = db.BasvuraninBilgileri.FirstOrDefault(p => p.BasvuraninBilgileriID == id);
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
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.BasvuraninBilgileri.Select(a => new VMSED
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.ArsivNo,
                    BasvuraninBilgileriID = a.BasvuraninBilgileriID,
                    BasvuruNedeni = a.BasvuruNedeni,
                    BasvuruTarihi = a.BasvuruTarihi,
                    DogumTarihi = a.DogumTarihi,
                    DosyaTarihi = a.DosyaTarihi,
                    Durum = a.Durum,
                    mahalleKoy = a.MahalleKoy,
                    OdemeBaslangici = a.OdemeBaslangici,
                    OdemeBitisi = a.OdemeBitisi,
                    OdemeSuresi = a.OdemeSuresi,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.YardimAlaninYakinlikDurumu,
                    YardimAlaninAdiSoyadi = a.YardimAlaninAdiSoyadi,
                    YardimAlaninDogumTarihi = a.YardimAlaninDogumTarihi,
                    YardimAlaninTC = a.YardimAlaninTC,
                    YBSNo = a.YBSNo,
                    not = a.Not
                }).ToList();
                return Bul;
            }
        }
        public static List<VMSEDRapor> RaporListe()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.BasvuraninBilgileri.Select(a => new VMSEDRapor
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
                }).ToList();
                return Bul;
            }
        }
        public static List<VMSEDRapor> RaporTarih(string al1, string al2)
        {
            DateTime ilktarih = Convert.ToDateTime(al1);
            DateTime sontarih = Convert.ToDateTime(al2);
            List<VMSEDRapor> Yeni = new List<VMSEDRapor>();
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                for (int i = 0; i <= (sontarih - ilktarih).Days; i++)
                {
                    string tarih = ilktarih.AddDays(i).ToShortDateString();
                    try
                    {
                        var a = db.BasvuraninBilgileri.Where(p => p.BasvuruTarihi == tarih).FirstOrDefault();

                        VMSEDRapor eklemece = new VMSEDRapor()
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
                        Yeni.Add(eklemece);
                    }
                    catch
                    {
                    }

                }
                return Yeni;
            }
        }

        public static VMSED SEDBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.BasvuraninBilgileri.Where(p => p.BasvuraninBilgileriID == id).Select(a => new VMSED
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.ArsivNo,
                    BasvuraninBilgileriID = a.BasvuraninBilgileriID,
                    BasvuruNedeni = a.BasvuruNedeni,
                    BasvuruTarihi = a.BasvuruTarihi,
                    DogumTarihi = a.DogumTarihi,
                    DosyaTarihi = a.DosyaTarihi,
                    Durum = a.Durum,
                    mahalleKoy = a.MahalleKoy,
                    OdemeBaslangici = a.OdemeBaslangici,
                    OdemeBitisi = a.OdemeBitisi,
                    OdemeSuresi = a.OdemeSuresi,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.YardimAlaninYakinlikDurumu,
                    YardimAlaninAdiSoyadi = a.YardimAlaninAdiSoyadi,
                    YardimAlaninDogumTarihi = a.YardimAlaninDogumTarihi,
                    YardimAlaninTC = a.YardimAlaninTC,
                    YBSNo = a.YBSNo,
                    not = a.Not
                }).FirstOrDefault();
                return Bul;
            }
        }
        public static List<VMDosyaTakip> DosyaTakipBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.SEDDosyaTakip.Where(p => p.BasvuraninBilgileriID == id).Select(a => new VMDosyaTakip
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
