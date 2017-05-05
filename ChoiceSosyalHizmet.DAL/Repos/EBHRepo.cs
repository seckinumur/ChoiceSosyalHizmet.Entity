using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
   public class EBHRepo
    {
        public static string Kaydet(VMEBH Al)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                bool Bak = db.EngelliBilgileri.Any(p => p.TC == Al.TC);
                if (Bak == true)
                {
                    return "Bu Kayıt Daha Önce Kaydedilmiş! Güncellemek İçin Güncelle Butonuna Basınız.";
                }
                else
                {
                    EngelliBilgileri BB = new EngelliBilgileri()
                    {
                        AdiSoyadi = Al.AdiSoyadi,
                        Adres = Al.Adres,
                        DogumTarihi = Al.DogumTarihi,
                        TC = Al.TC,
                        Telefon = Al.Telefon,
                        BakiciBilgileriAdiSoyadi = Al.BakiciBilgileriAdiSoyadi,
                        BakiciBilgileriTC = Al.BakiciBilgileriTC,
                        BakiciBilgileriDogumTarihi = Al.BakiciBilgileriDogumTarihi,
                        BakiciBilgileriYakinlikDurumu = Al.YakinlikDurumu,
                        ArsivNo = Al.ArsivNo,
                        BasvuruTarihi = Al.BasvuruTarihi,
                        DosyaTarihi = Al.DosyaTarihi,
                        Durum = Al.Durum,
                        MahalleKoy = Al.mahalleKoy,
                        OdemeBaslangici = Al.OdemeBaslangici,
                        BaslangicTarihi = Al.BaslangicTarihi,
                        BitisTarihi = Al.BitisTarihi,
                        RaporSuresi = Al.RaporSuresi,
                        RaporTipi = Al.RaporTipi,
                        YBSNo = Al.YBSNo,
                        Not = Al.Not,
                        DenetimTarihi=DateTime.Now.ToShortDateString()
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
                    db.EngelliBilgileri.Add(BB);
                    db.SaveChanges();

                    var BBI = db.EngelliBilgileri.FirstOrDefault(P => P.TC == Al.TC);
                    EBHDosyaTakip SDT = new EBHDosyaTakip()
                    {
                        EngelliBilgileriID = BBI.EngelliBilgileriID,
                        Durum = Al.Durum,
                        Tarih = Al.Tarih
                    };
                    db.EBHDosyaTakip.Add(SDT);
                    db.SaveChanges();
                    return "Kayıt Başarıyla Kaydedildi!";
                }    
            }
        }
        public static string Guncelle(VMEBH Al)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                bool Bak = db.EngelliBilgileri.Any(p => p.EngelliBilgileriID == Al.EngelliBilgileriID);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Önce Sisteme Ekleyin";
                }
                else
                {
                    var Bul = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == Al.EngelliBilgileriID);
                    Bul.AdiSoyadi = Al.AdiSoyadi;
                    Bul.Adres = Al.Adres;
                    Bul.DogumTarihi = Al.DogumTarihi;
                    Bul. TC = Al.TC;
                    Bul.Telefon = Al.Telefon;
                    Bul.BakiciBilgileriAdiSoyadi = Al.BakiciBilgileriAdiSoyadi;
                    Bul.BakiciBilgileriTC = Al.BakiciBilgileriTC;
                    Bul.BakiciBilgileriDogumTarihi = Al.BakiciBilgileriDogumTarihi;
                    Bul.BakiciBilgileriYakinlikDurumu = Al.YakinlikDurumu;
                    Bul.ArsivNo = Al.ArsivNo;
                    Bul.BasvuruTarihi = Al.BasvuruTarihi;
                    Bul.DosyaTarihi = Al.DosyaTarihi;
                    Bul.Durum = Al.Durum;
                    Bul.MahalleKoy = Al.mahalleKoy;
                    Bul.OdemeBaslangici = Al.OdemeBaslangici;
                    Bul.BaslangicTarihi = Al.BaslangicTarihi;
                    Bul.BitisTarihi = Al.BitisTarihi;
                    Bul.RaporSuresi = Al.RaporSuresi;
                    Bul.RaporTipi = Al.RaporTipi;
                    Bul.YBSNo = Al.YBSNo;
                    Bul.Not = Al.Not;
                    Bul.DenetimTarihi = Al.OdemeBaslangici;
                    EBHDosyaTakip SDT = new EBHDosyaTakip()
                    {
                        EngelliBilgileriID = Bul.EngelliBilgileriID,
                        Durum = Al.Durum,
                        Tarih = Al.Tarih
                    };
                    db.EBHDosyaTakip.Add(SDT);
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
                bool Bak = db.EngelliBilgileri.Any(p => p.EngelliBilgileriID == id);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Sistemde Kayıtlı Olmayan Silinemez!";
                }
                else
                {
                    var Bul = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                    var BBI = db.EBHDosyaTakip.Where(p => p.EngelliBilgileriID == Bul.EngelliBilgileriID).ToList();

                    foreach (var item in BBI)
                    {
                        db.EBHDosyaTakip.Remove(item);
                    }
                    try
                    {
                        var EZ = db.EvrakZimmetEBH.FirstOrDefault(p => p.EngelliBilgileriID == Bul.EngelliBilgileriID);
                        db.EvrakZimmetEBH.Remove(EZ);
                    }
                    catch
                    {
                    }
                    db.EngelliBilgileri.Remove(Bul);
                    db.SaveChanges();
                    return "Kayıt Başarıyla Silindi!";
                }
            }
        }
        public static List<VMEBHRapor> RaporListe()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.EngelliBilgileri.Select(a => new VMEBHRapor
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
                }).ToList();
                return Bul;
            }
        }
        public static List<VMEBH> TumRaporListe()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.EngelliBilgileri.Select(a => new VMEBH
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.ArsivNo,
                    BakiciBilgileriAdiSoyadi = a.BakiciBilgileriAdiSoyadi,
                    BakiciBilgileriDogumTarihi = a.BakiciBilgileriDogumTarihi,
                    BakiciBilgileriTC = a.BakiciBilgileriTC,
                    BaslangicTarihi = a.BaslangicTarihi,
                    BasvuruTarihi = a.BasvuruTarihi,
                    BitisTarihi = a.BitisTarihi,
                    DogumTarihi = a.DogumTarihi,
                    Durum = a.Durum,
                    mahalleKoy = a.MahalleKoy,
                    OdemeBaslangici = a.OdemeBaslangici,
                    RaporSuresi = a.RaporSuresi,
                    RaporTipi = a.RaporTipi,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.BakiciBilgileriYakinlikDurumu,
                    YBSNo = a.YBSNo,
                    DosyaTarihi = a.DosyaTarihi,
                    Not = a.Not,
                }).ToList();
                return Bul;
            }
        }
        public static List<VMEBHRapor> RaporTarih(string al1, string al2)
        {
            DateTime ilktarih = Convert.ToDateTime(al1);
            DateTime sontarih = Convert.ToDateTime(al2);
            List<VMEBHRapor> Yeni = new List<VMEBHRapor>();
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                for (int i = 0; i <= (sontarih - ilktarih).Days; i++)
                {
                    string tarih = ilktarih.AddDays(i).ToShortDateString();
                    try
                    {
                        var a = db.EngelliBilgileri.Where(p => p.DosyaTarihi == tarih).FirstOrDefault();

                        VMEBHRapor eklemece = new VMEBHRapor()
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
                        Yeni.Add(eklemece);
                    }
                    catch
                    {
                    }

                }
                return Yeni;
            }
        }
        public static VMEBH EBHBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.EngelliBilgileri.Where(p => p.EngelliBilgileriID == id).Select(a => new VMEBH
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.ArsivNo,
                    BakiciBilgileriAdiSoyadi = a.BakiciBilgileriAdiSoyadi,
                    BakiciBilgileriDogumTarihi = a.BakiciBilgileriDogumTarihi,
                    BakiciBilgileriTC = a.BakiciBilgileriTC,
                    BaslangicTarihi = a.BaslangicTarihi,
                    BasvuruTarihi = a.BasvuruTarihi,
                    BitisTarihi = a.BitisTarihi,
                    DogumTarihi = a.DogumTarihi,
                    Durum = a.Durum,
                    mahalleKoy = a.MahalleKoy,
                    OdemeBaslangici = a.OdemeBaslangici,
                    RaporSuresi = a.RaporSuresi,
                    RaporTipi = a.RaporTipi,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.BakiciBilgileriYakinlikDurumu,
                    YBSNo = a.YBSNo,
                    DosyaTarihi = a.DosyaTarihi,
                    Not = a.Not,
                    EngelliBilgileriID=a.EngelliBilgileriID
                }).FirstOrDefault();
                return Bul;
            }
        }
        public static List<VMDosyaTakip> DosyaTakipBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var bul = db.EBHDosyaTakip.Where(p => p.EngelliBilgileriID == id).Select(a => new VMDosyaTakip
                {
                    Durum = a.Durum,
                    ID = a.EngelliBilgileriID,
                    Tarih = a.Tarih
                }).ToList();
                return bul;
            }
        }
    }
}
