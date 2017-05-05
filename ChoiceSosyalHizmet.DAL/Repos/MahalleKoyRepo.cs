using ChoiceSosyalHizmet.DAL.VM;
using ChoiceSosyalHizmet.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.Repos
{
   public class MahalleKoyRepo
    {
        public static string MahalleKoyEkle(VMMahalleKoy mkoy)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                bool varmi = db.MahalleKoy.Any(p => p.MahalleKoyID == mkoy.MahalleKoyID);
                if (varmi == true)
                {
                    return "Bu Mahalle Köy Daha Önceden Kaydedilmiş!";
                }
                else
                {
                    MahalleKoy Ekle = new MahalleKoy()
                    {
                       Isim= mkoy.Isim
                    };

                    db.MahalleKoy.Add(Ekle);
                    db.SaveChanges();
                    return "Başarıyla Kaydedildi";
                }
            }
        }
        public static string MahalleKoyGuncelle(VMMahalleKoy mkoy)
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                try
                {
                    var Bul = db.MahalleKoy.FirstOrDefault(p => p.MahalleKoyID == mkoy.MahalleKoyID);
                    Bul.Isim = mkoy.Isim;
                    db.SaveChanges();
                    return "Başarıyla Güncelleştirildi!";
                }
                catch
                {
                    return "Bu Mahalle Köy Daha Önceden Kaydedilmiş!";
                }

            }
        }
        public static string MahalleKoySil(string ID)
        {
            int id = int.Parse(ID);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                try
                {
                    var Bul = db.MahalleKoy.FirstOrDefault(p => p.MahalleKoyID == id);
                    db.MahalleKoy.Remove(Bul);
                    db.SaveChanges();
                    return "Başarıyla Silindi!";
                }
                catch
                {
                    return "Silme Başarısız!";
                }
            }
        }
        public static List<VMMahalleKoy> MaahalleKoyRaporla()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.MahalleKoy.Select(p => new VMMahalleKoy
                {
                    Isim= p.Isim,
                    MahalleKoyID= p.MahalleKoyID
                }).ToList();
                return Bul;
            }
        }
        public static VMMahalleKoy MahalleKoyBul(string ID)
        {
            int id = int.Parse(ID);
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.MahalleKoy.Where(p => p.MahalleKoyID == id).Select(a => new VMMahalleKoy
                {
                    Isim= a.Isim,
                    MahalleKoyID= a.MahalleKoyID
                }).FirstOrDefault();
                return Bul;
            }
        }
        public static List<string> MahalleKarsila()
        {
            using (DBChoiceEntities db = new DBChoiceEntities())
            {
                var Bul = db.MahalleKoy.Select(p=> p.Isim).ToList();
                return Bul;
            }
        }
    }
}
