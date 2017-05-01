using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ChoiceSosyalHizmet.DAL.Repos;
using ChoiceSosyalHizmet.DAL.VM;

namespace ChoiceSosyalHizmet.WinForm
{
    public partial class GirisForm : MaterialForm
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            VMKullanicilar al = new VMKullanicilar()
            {
                KullaniciAdi = TxtKullaniciAdi.Text,
                Sifre = TxtParola.Text
            };
            bool gir= KullanicilarRepo.SistemeGiris(al);
            if (gir==true)
            {
                    MainForm ac = new MainForm();
                    ac.Show();
                    this.Hide();
                
            }
            else
            {
                TxtKullaniciAdi.Clear();
                TxtParola.Clear();
                TxtKullaniciAdi.Hint = "Kullanıcı Adı Hatalı!";
            }
        }

        private void TxtParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGiris.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                TxtParola.Clear();
            }
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
            KullanicilarRepo.veritabanisorgulama();
        }
    }
}
