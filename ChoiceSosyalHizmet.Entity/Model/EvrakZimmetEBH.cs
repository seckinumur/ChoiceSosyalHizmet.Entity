﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSosyalHizmet.Entity.Model
{
    public  class EvrakZimmetEBH
    {
        public int EvrakZimmetEBHID { get; set; }
        public int PersonelID { get; set; }
        public int EngelliBilgileriID { get; set; }
        public bool Zimmettemi { get; set; }
        public string ZimmeteAlisTarihi { get; set; }
        public string ZimmettenCikisTarihi { get; set; }

        public virtual Personel Personel { get; set; }
        public virtual EngelliBilgileri EngelliBilgileri { get; set; }
    }
}