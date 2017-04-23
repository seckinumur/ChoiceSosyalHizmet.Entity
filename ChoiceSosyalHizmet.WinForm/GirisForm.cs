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
            if (TxtKullaniciAdi.Text == "demo")
            {
                if (TxtParola.Text == "1234")
                {
                    MainForm ac = new MainForm();
                    ac.Show();
                    this.Hide();
                }
                else
                {
                    TxtParola.Clear();
                    TxtParola.Hint = "Yanlış Parola!";
                }
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
    }
}
