using ChoiceSosyalHizmet.DAL.Repos;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChoiceSosyalHizmet.WinForm
{
    public partial class SEDRaporFormu : MaterialForm
    {
        public SEDRaporFormu()
        {
            InitializeComponent();
        }
        public MainForm AnaEkran = (MainForm)Application.OpenForms["MainForm"];
        private bool kontrol;
        private void SEDRaporFormu_Load(object sender, EventArgs e)
        {
           var al = SEDRepo.SEDBul(idtut.Text);
           TxtBasvuranAd.Text = al.AdiSoyadi;
           TxtAdres.Text = al.Adres;
           TxtANo.Text = al.ArsivNo;
           CBoxN.SelectedItem = al.BasvuruNedeni;
           DateBT.Text = al.BasvuruTarihi;
           DateDogumT.Text = al.DogumTarihi;
           CboxDurum.SelectedItem = al.Durum;
           CboxMa.SelectedItem = al.mahalleKoy;
           DateOB.Text = al.OdemeBaslangici;
           DateOBi.Text = al.OdemeBitisi;
           if(al.OdemeSuresi == "Tek Seferlik")
            {
                RBT.Checked = true;
            }
           else if (al.OdemeSuresi== "1 Yıllık")
            {
                RB1.Checked = true;
            }
            else if(al.OdemeSuresi== "2 Yıllık")
            {
                RB2.Checked = true;
            }
            TxtTc.Text = al.TC;
            TxtTel.Text = al.Telefon;
            CboxYD.SelectedItem = al.YakinlikDurumu;
            TxtAdY.Text = al.YardimAlaninAdiSoyadi;
            DateDY.Text = al.YardimAlaninDogumTarihi;
            TxtTcY.Text = al.YardimAlaninTC;
            TxtYBS.Text = al.YBSNo;
            SEDNot.Text = al.not;
            kontrol = true;
        }

        private void RBT_CheckedChanged(object sender, EventArgs e)
        {
            DateOBi.Text = "";
            DateOBi.Enabled = false;
        }

        private void RB1_CheckedChanged(object sender, EventArgs e)
        {
            if (DateOB.Text == "" && kontrol==true)
            {
                RB1.Checked = false;
            }
            else
            {
                DateOBi.Enabled = true;
                DateTime OdemeBaslangici = DateOB.DateTime, Odemebitisi;
                Odemebitisi = OdemeBaslangici.AddYears(1);
                DateOBi.Text = Odemebitisi.ToShortDateString();
            }
        }

        private void RB2_CheckedChanged(object sender, EventArgs e)
        {
            if (DateOB.Text == "" && kontrol == true)
            {
                RB2.Checked = false;
            }
            else
            {
                DateOBi.Enabled = true;
                DateTime OdemeBaslangici = DateOB.DateTime, Odemebitisi;
                Odemebitisi = OdemeBaslangici.AddYears(2);
                DateOBi.Text = Odemebitisi.ToShortDateString();
            }
        }

        private void SEDRaporFormu_FormClosed(object sender, FormClosedEventArgs e) //Form Kapanınca Ana Ekrana Geri Dönücek.
        {
            AnaEkran.Visible = true;
        }
    }
}
