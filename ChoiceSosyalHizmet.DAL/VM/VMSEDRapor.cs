using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
   public class VMSEDRapor
    {
        public int ID { get; set; }
        public string BaşvuranınAdıSoyadı { get; set; }
        public string BaşvuranınTC { get; set; }
        public string BaşvuranınDoğumTarihi { get; set; }
        public string BaşvuranınTelefon { get; set; }
        public string BaşvuranınAdres { get; set; }
        public string BaşvuruNedeni { get; set; }

        public string YardımAlanınAdıSoyadı { get; set; }
        public string YardımAlanınTC { get; set; }
        public string YardımAlanınDoğumTarihi { get; set; }
        public string YakınlıkDurumu { get; set; }
        
        public string Durum { get; set; }
        public string mahalleKöy { get; set; }
        public string BaşvuruTarihi { get; set; }
        public string ÖdemeSüresi { get; set; }
        public string ÖdemeBaşlangıcı { get; set; }
        public string ÖdemeBitişi { get; set; }
        public string YBSNo { get; set; }
        public string ArşivNo { get; set; }
        public string DosyaKayıtTarihi { get; set; }
        public string Not { get; set; }
    }
}
