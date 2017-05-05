using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
   public class VMZimmetList
    {
        public long ID { get; set; }
        public string DosyaAdı { get; set; }
        public string DosyaSahibiTC { get; set; }
        public string DosyaSahibiMahalleKöy { get; set; }
        public string Zimmettemi { get; set; }
        public string ZimmeteAlişTarihi { get; set; }
        public string ZimmettenÇıkışTarihi { get; set; }
        public long PersonelID { get; set; }
        public string PersonelAdı { get; set; }   
    }
}
