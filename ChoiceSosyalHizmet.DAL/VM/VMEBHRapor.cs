using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
   public class VMEBHRapor
    {
        public long ID { get; set; }
        public string EngelliAdıSoyadı { get; set; }
        public string EngelliTC { get; set; }
        public string EngelliDoğumTarihi { get; set; }
        public string EngelliTelefon { get; set; }
        public string EngelliAdres { get; set; }
        
        public string BakıcıBilgileriAdıSoyadı { get; set; }
        public string BakıcıBilgileriTC { get; set; }
        public string BakıcıBilgileriDoğumTarihi { get; set; }
        public string YakınlıkDurumu { get; set; }
        
        public string Durum { get; set; }
        public string mahalleKöy { get; set; }
        public string BaşvuruTarihi { get; set; }
        public string RaporTipi { get; set; }
        public string ÖdemeBaşlangıcı { get; set; }
        public string RaporSüresi { get; set; }
        public string BaşlangıcTarihi { get; set; }
        public string BitişTarihi { get; set; }
        public string YBSNo { get; set; }
        public string ArşivNo { get; set; }
        public string DosyaKayıtTarihi { get; set; }
        public string Not { get; set; }
        public string DenetimTarihi { get; set; }
    }
}
