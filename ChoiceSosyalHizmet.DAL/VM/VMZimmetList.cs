using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.DAL.VM
{
   public class VMZimmetList
    {
        public int ID { get; set; }
        public int PersonelID { get; set; }
        public string PersonelAdı { get; set; }
        public bool Zimmettemi { get; set; }
        public string ZimmeteAlişTarihi { get; set; }
        public string ZimmettenÇıkışTarihi { get; set; }
        public string DosyaAdı { get; set; }
        public string DosyaSahibiTC { get; set; }
        public string DosyaSahibiMahalleKöy { get; set; }
    }
}
