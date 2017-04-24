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
        public static void KullaniciEkle(VMKullanicilar kullanici)
        {
            using(DBSosyal db = new DBSosyal())
            {
                Kullanicilar Ekle = new Kullanicilar()
                {
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Sifre = kullanici.Sifre,
                    Admin = kullanici.Admin
                };

                db.Kullanicilar.Add(Ekle);
                db.SaveChanges();
            }
        }
        public static void KullaniciDuzenle(VMKullanicilar kullanici)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == kullanici.KullanicilarID);
                Bul.KullaniciAdi = kullanici.KullaniciAdi;
                Bul.Sifre = kullanici.Sifre;
                Bul.Admin = kullanici.Admin;
                db.SaveChanges();
            }
        }
        public static void KullaniciSil(VMKullanicilar kullanici)
        {
            using (DBSosyal db = new DBSosyal())
            {
                var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == kullanici.KullanicilarID);
                db.Kullanicilar.Remove(Bul);
                db.SaveChanges();
            }
        }
    }
}
