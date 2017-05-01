namespace ChoiceSosyalHizmet.Entity.Context
{
    using ChoiceSosyalHizmet.Entity.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBSosyal : DbContext
    {
        public DBSosyal()
            : base("name=DBSosyal")
        {
        }
        public virtual DbSet<YardimAlaninBilgileri> YardimAlaninBilgileri { get; set; }
        public virtual DbSet<BasvuraninBilgileri> BasvuraninBilgileri { get; set; }
        public virtual DbSet<SEDDosyaBilgileri> SEDDosyaBilgileri { get; set; }
        public virtual DbSet<EngelliBilgileri> EngelliBilgileri { get; set; }
        public virtual DbSet<BakiciBilgileri> BakiciBilgileri { get; set; }
        public virtual DbSet<EBHDosyaBilgileri> EBHDosyaBilgileri { get; set; }
        public virtual DbSet<EBHDosyaTakip> EBHDosyaTakip { get; set; }
        public virtual DbSet<SEDDosyaTakip> SEDDosyaTakip { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<EvrakZimmetSED> EvrakZimmetSED { get; set; }
        public virtual DbSet<EvrakZimmetEBH> EvrakZimmetEBH { get; set; }
        public virtual DbSet<MahalleKoy> MahalleKoy { get; set; }
        public virtual DbSet<DenetimSED> DenetimSED { get; set; }
        public virtual DbSet<DenetimEBH> DenetimEBH { get; set; }
    }
}