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
                this.Hide();
                MainForm ac = new MainForm();
                ac.Show();
                    
                
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

        private void TxtKullaniciAdi_TextChanged(object sender, EventArgs e) //Tüm harfler Büyük
        {
            TextBox txBox = (TextBox)sender;
            int pos = txBox.SelectionStart;
            int slen = txBox.SelectionLength;
            txBox.Text = txBox.Text.ToUpper();
            txBox.SelectionStart = pos;
            txBox.SelectionLength = slen;
            txBox.Focus();
        }

        private void TxtParola_KeyPress(object sender, KeyPressEventArgs e) //Harf Gitremez
        {
            e.Handled = Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar);
        }
    }
}
