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
   public class EBHRepo
    {
        public static string Kaydet(VMEBH Al)
        {
            using (DBSosyal db = new DBSosyal())
            {
                bool Bak = db.EngelliBilgileri.Any(p => p.TC == Al.TC);
                if (Bak == true)
                {
                    return "Bu Kayıt Daha Önce Kaydedilmiş! Güncellemek İçin Güncelle Butonuna Basınız.";
                }
                else
                {
                    BakiciBilgileri YAB = new BakiciBilgileri()
                    {
                        AdiSoyadi = Al.BakiciBilgileriAdiSoyadi,
                        TC = Al.BakiciBilgileriTC,
                        DogumTarihi = Al.BakiciBilgileriDogumTarihi,
                        YakinlikDurumu = Al.YakinlikDurumu
                    };

                    db.BakiciBilgileri.Add(YAB);
                    db.SaveChanges();

                    EBHDosyaBilgileri SDB = new EBHDosyaBilgileri()
                    {
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
                        Not = Al.Not
                    };

                    db.EBHDosyaBilgileri.Add(SDB);
                    db.SaveChanges();

                    var YABBul = db.BakiciBilgileri.FirstOrDefault(p => p.TC == Al.BakiciBilgileriTC);
                    var SDBBul = db.EBHDosyaBilgileri.FirstOrDefault(p => p.ArsivNo == Al.ArsivNo);

                    EngelliBilgileri BB = new EngelliBilgileri()
                    {
                        AdiSoyadi = Al.AdiSoyadi,
                        Adres = Al.Adres,
                        DogumTarihi = Al.DogumTarihi,
                        BakiciBilgileriID = YABBul.BakiciBilgileriID,
                        TC = Al.TC,
                        EBHDosyaBilgileriID = SDBBul.EBHDosyaBilgileriID,
                        Telefon = Al.Telefon
                    };

                    db.EngelliBilgileri.Add(BB);
                    db.SaveChanges();

                    var BBI = db.EngelliBilgileri.FirstOrDefault(p => p.TC == Al.TC);

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
            using (DBSosyal db = new DBSosyal())
            {
                bool Bak = db.EngelliBilgileri.Any(p => p.EngelliBilgileriID == Al.EngelliBilgileriID);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Önce Sisteme Ekleyin";
                }
                else
                {
                    var Bul = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == Al.EngelliBilgileriID);
                    Bul.BakiciBilgileri.AdiSoyadi = Al.BakiciBilgileriAdiSoyadi;
                    Bul.BakiciBilgileri.DogumTarihi = Al.BakiciBilgileriDogumTarihi;
                    Bul.BakiciBilgileri.TC = Al.BakiciBilgileriTC;
                    Bul.BakiciBilgileri.YakinlikDurumu = Al.YakinlikDurumu;
                    Bul.EBHDosyaBilgileri.ArsivNo = Al.ArsivNo;
                    Bul.EBHDosyaBilgileri.BasvuruTarihi = Al.BasvuruTarihi;
                    Bul.EBHDosyaBilgileri.DosyaTarihi = Al.DosyaTarihi;
                    Bul.EBHDosyaBilgileri.Durum = Al.Durum;
                    Bul.EBHDosyaBilgileri.MahalleKoy = Al.mahalleKoy;
                    Bul.EBHDosyaBilgileri.OdemeBaslangici = Al.OdemeBaslangici;
                    Bul.EBHDosyaBilgileri.BaslangicTarihi = Al.BaslangicTarihi;
                    Bul.EBHDosyaBilgileri.BitisTarihi = Al.BitisTarihi;
                    Bul.EBHDosyaBilgileri.YBSNo = Al.YBSNo;
                    Bul.EBHDosyaBilgileri.RaporSuresi = Al.RaporSuresi;
                    Bul.EBHDosyaBilgileri.RaporTipi = Al.RaporTipi;
                    Bul.EBHDosyaBilgileri.Not = Al.Not;
                    Bul.AdiSoyadi = Al.AdiSoyadi;
                    Bul.Adres = Al.Adres;
                    Bul.DogumTarihi = Al.DogumTarihi;
                    Bul.TC = Al.TC;
                    Bul.Telefon = Al.Telefon;

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
            using (DBSosyal db = new DBSosyal())
            {
                bool Bak = db.EngelliBilgileri.Any(p => p.EngelliBilgileriID == id);
                if (Bak == false)
                {
                    return "Bu Kayıt Sistemde Bulunamadı! Sistemde Kayıtlı Olmayan Silinemez!";
                }
                else
                {
                    var Bul = db.EngelliBilgileri.FirstOrDefault(p => p.EngelliBilgileriID == id);
                    var Bul2 = db.EBHDosyaBilgileri.FirstOrDefault(p => p.EBHDosyaBilgileriID == Bul.EBHDosyaBilgileriID);
                    var Bul3 = db.BakiciBilgileri.FirstOrDefault(p => p.BakiciBilgileriID == Bul.BakiciBilgileriID);

                    db.EBHDosyaBilgileri.Remove(Bul2);
                    db.BakiciBilgileri.Remove(Bul3);

                    var BBI = db.EBHDosyaTakip.Where(p => p.EngelliBilgileriID == Bul.EngelliBilgileriID).ToList();

                    foreach (var item in BBI)
                    {
                        db.EBHDosyaTakip.Remove(item);
                    }
                    try
                    {
                        var EZ = db.EvrakZimmetEBH.FirstOrDefault(p => p.EngelliBilgileriID == Bul.EBHDosyaBilgileriID);
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
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.EngelliBilgileri.Select(a => new VMEBHRapor
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
                    ID=a.EngelliBilgileriID,
                    Durum=a.EBHDosyaBilgileri.Durum,
                    mahalleKöy=a.EBHDosyaBilgileri.MahalleKoy,
                    ÖdemeBaşlangıcı=a.EBHDosyaBilgileri.OdemeBaslangici,
                    RaporSüresi=a.EBHDosyaBilgileri.RaporSuresi,
                    RaporTipi=a.EBHDosyaBilgileri.RaporTipi,
                    EngelliTC=a.TC,
                    EngelliTelefon=a.Telefon,
                    YakınlıkDurumu=a.BakiciBilgileri.YakinlikDurumu,
                    YBSNo=a.EBHDosyaBilgileri.YBSNo,
                    DosyaKayıtTarihi=a.EBHDosyaBilgileri.DosyaTarihi,
                    Not = a.EBHDosyaBilgileri.Not
                }).ToList();
                return Bul;
            }
        }
        public static List<VMEBH> TumRaporListe()
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.EngelliBilgileri.Select(a => new VMEBH
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.EBHDosyaBilgileri.ArsivNo,
                    BakiciBilgileriAdiSoyadi = a.BakiciBilgileri.AdiSoyadi,
                    BakiciBilgileriDogumTarihi = a.BakiciBilgileri.DogumTarihi,
                    BakiciBilgileriID = a.BakiciBilgileriID,
                    BakiciBilgileriTC = a.BakiciBilgileri.TC,
                    BaslangicTarihi = a.EBHDosyaBilgileri.BaslangicTarihi,
                    BasvuruTarihi = a.EBHDosyaBilgileri.BasvuruTarihi,
                    BitisTarihi = a.EBHDosyaBilgileri.BitisTarihi,
                    DogumTarihi = a.DogumTarihi,
                    DosyaTarihi = a.EBHDosyaBilgileri.DosyaTarihi,
                    Durum = a.EBHDosyaBilgileri.Durum,
                    EBHDosyaBilgileriID = a.EBHDosyaBilgileriID,
                    EngelliBilgileriID = a.EngelliBilgileriID,
                    mahalleKoy = a.EBHDosyaBilgileri.MahalleKoy,
                    OdemeBaslangici = a.EBHDosyaBilgileri.OdemeBaslangici,
                    RaporSuresi = a.EBHDosyaBilgileri.RaporSuresi,
                    RaporTipi = a.EBHDosyaBilgileri.RaporTipi,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    YakinlikDurumu = a.BakiciBilgileri.YakinlikDurumu,
                    Not= a.EBHDosyaBilgileri.Not,
                    YBSNo = a.EBHDosyaBilgileri.YBSNo
                }).ToList();
                return Bul;
            }
        }
        public static List<VMEBHRapor> RaporTarih(string al1, string al2)
        {
            DateTime ilktarih = Convert.ToDateTime(al1);
            DateTime sontarih = Convert.ToDateTime(al2);
            List<VMEBHRapor> Yeni = new List<VMEBHRapor>();
            using (DBSosyal db = new DBSosyal())
            {
                for (int i = 0; i <= (sontarih - ilktarih).Days; i++)
                {
                    string tarih = ilktarih.AddDays(i).ToShortDateString();
                    try
                    {
                        var a = db.EngelliBilgileri.Where(p => p.EBHDosyaBilgileri.BasvuruTarihi == tarih).FirstOrDefault();

                        VMEBHRapor eklemece = new VMEBHRapor()
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
                            Not=a.EBHDosyaBilgileri.Not
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
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.EngelliBilgileri.Where(p => p.EngelliBilgileriID == id).Select(a => new VMEBH
                {
                    AdiSoyadi = a.AdiSoyadi,
                    Adres = a.Adres,
                    ArsivNo = a.EBHDosyaBilgileri.ArsivNo,
                    BakiciBilgileriAdiSoyadi = a.BakiciBilgileri.AdiSoyadi,
                    BakiciBilgileriDogumTarihi = a.BakiciBilgileri.DogumTarihi,
                    BakiciBilgileriID = a.BakiciBilgileriID,
                    BakiciBilgileriTC = a.BakiciBilgileri.TC,
                    BaslangicTarihi = a.EBHDosyaBilgileri.BaslangicTarihi,
                    BasvuruTarihi = a.EBHDosyaBilgileri.BasvuruTarihi,
                    BitisTarihi = a.EBHDosyaBilgileri.BitisTarihi,
                    DogumTarihi = a.DogumTarihi,
                    DosyaTarihi = a.EBHDosyaBilgileri.DosyaTarihi,
                    Durum = a.EBHDosyaBilgileri.Durum,
                    EBHDosyaBilgileriID = a.EBHDosyaBilgileriID,
                    EngelliBilgileriID = a.EngelliBilgileriID,
                    mahalleKoy = a.EBHDosyaBilgileri.MahalleKoy,
                    OdemeBaslangici = a.EBHDosyaBilgileri.OdemeBaslangici,
                    RaporSuresi = a.EBHDosyaBilgileri.RaporSuresi,
                    RaporTipi = a.EBHDosyaBilgileri.RaporTipi,
                    TC = a.TC,
                    Telefon = a.Telefon,
                    Not=a.EBHDosyaBilgileri.Not,
                    YakinlikDurumu = a.BakiciBilgileri.YakinlikDurumu,
                    YBSNo = a.EBHDosyaBilgileri.YBSNo
                }).FirstOrDefault();
                return Bul;
            }
        }
        public static List<VMDosyaTakip> DosyaTakipBul(string Id)
        {
            int id = int.Parse(Id);
            using (DBSosyal db = new DBSosyal())
            {
                var bul = db.EBHDosyaTakip.Where(p => p.EngelliBilgileriID == id).Select(a => new VMDosyaTakip
                {
                    Durum = a.Durum,
                    ID = a.EBHDosyaTakipID,
                    Tarih = a.Tarih
                }).ToList();
                return bul;
            }
        }
    }
}
