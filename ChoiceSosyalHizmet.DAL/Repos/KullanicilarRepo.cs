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
  public class KullanicilarRepo
    {
        public static string KullaniciEkle(VMKullanicilar kullanici)
        {
            using(DBSosyal db = new DBSosyal())
            {
                Kullanicilar Ekle = new Kullanicilar()
                {
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Sifre = kullanici.Sifre,
                };

                db.Kullanicilar.Add(Ekle);
                db.SaveChanges();
                return "İşlem Başarılı";
            }
        }
        public static string KullaniciDuzenle(VMKullanicilar kullanici)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == kullanici.KullanicilarID);
                Bul.KullaniciAdi = kullanici.KullaniciAdi;
                Bul.Sifre = kullanici.Sifre;
                db.SaveChanges();
                return "İşlem Başarılı";
            }
        }
        public static string KullaniciSil(VMKullanicilar kullanici)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullaniciAdi == kullanici.KullaniciAdi&& p.Sifre== kullanici.Sifre);
                db.Kullanicilar.Remove(Bul);
                db.SaveChanges();
                return "İşlem Başarılı";
            }
        }
        public static List<VMKullanicilar> KullaniciListele()
        {
            using (DBSosyal db = new DBSosyal())
            {
              var bu=  db.Kullanicilar.Select(p => new VMKullanicilar
                {
                    KullaniciAdi = p.KullaniciAdi,
                    Sifre = p.Sifre,
                    KullanicilarID= p.KullanicilarID
                }).ToList();
                return bu;
            }
        }
        public static VMKullanicilar KullaniciBul(string ID)
        {
            int id = int.Parse(ID);
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Kullanicilar.Where(p => p.KullanicilarID == id).Select(n=> new VMKullanicilar
                {
                    KullaniciAdi = n.KullaniciAdi,
                    Sifre = n.Sifre
                }).FirstOrDefault();
                return Bul;
            }
        }
        public static bool SistemeGiris(VMKullanicilar al)
        {
            using (DBSosyal db = new DBSosyal())
            {
                bool pass = db.Kullanicilar.Any(p => p.KullaniciAdi == al.KullaniciAdi && p.Sifre == al.Sifre);
                return pass;
            }
        }
        public static void veritabanisorgulama()
        {
            using (DBSosyal db = new DBSosyal())
            {
                bool pass = db.Kullanicilar.Any();
                if (pass == false)
                {
                    Kullanicilar Ekle = new Kullanicilar()
                    {
                        KullaniciAdi = "Demo",
                        Sifre = "1234",
                    };

                    db.Kullanicilar.Add(Ekle);
                    db.SaveChanges();
                }
            }
        }
    }
}
