using ChoiceSosyalHizmet.DAL.Repos;
using ChoiceSosyalHizmet.DAL.VM;
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
        public MainForm Anaekran1 = (MainForm)Application.OpenForms["MainForm"];
        private bool kontrol;
        private bool zimmetkontrol;
        public void SEDRaporFormu_Load(object sender, EventArgs e)
        {
            kontrol = true;
            var almahalle = MahalleKoyRepo.MahalleKarsila();
            foreach (var a in almahalle)
            {
                CboxMa.Properties.Items.Add(a);
            }
            ZAT.Text = "";
            ZCT.Text = "";
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
            try
            {
                var zimmet = ZimmetSEDRepo.ZimmetBul(al.BasvuraninBilgileriID);
                zimmetbuton.Text = "ZİMMETİ KALDIR";
                zimmetname.Text = zimmet.PersonelAdı;
                ZAT.Text = zimmet.ZimmeteAlişTarihi;
                ZCT.Text = zimmet.ZimmettenÇıkışTarihi;
                PersonelIDsi.Text = zimmet.ID.ToString();
            }
            catch
            {
                zimmetname.Text = "ZİMMET YOK"; 
                zimmetbuton.Text = "ZİMMETLE";  
                zimmetkontrol = true;
            }
            if (DenetimRepo.DenetimKontrolSED(idtut.Text) == false)
            {
                DenetimYapBtn.BackColor = Color.DarkRed;
                DenetimYapBtn.ForeColor = Color.White;
            }
            else
            {
                DenetimYapBtn.BackColor = Color.ForestGreen;
                DenetimYapBtn.ForeColor = Color.White;
            }
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
            Anaekran1.Enabled=true;
            Anaekran1.MainForm_Load(sender, e);
        }

        private void zimmetbuton_Click(object sender, EventArgs e)
        {
            if (zimmetkontrol == true)
            {
                PersonelListesiForm ac = new PersonelListesiForm();
                ac.zimmetkontrol = false;
                ac.ID = int.Parse(idtut.Text);
                ac.Show();
                zimmetkontrol = false;
            }
            else
            {
                    ZimmetSEDRepo.ZimmetKaldır(PersonelIDsi.Text);
                    MessageBox.Show("Evrak Zimmeti Kaldırıldı!");
                    SEDRaporFormu_Load(sender, e);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) //Sed güncelleme
        {
            DialogResult Uyari = new DialogResult();
            Uyari = MessageBox.Show("Güncellenecek Devam Edilsin mi?", "DİKKAT!", MessageBoxButtons.YesNo);
            if (Uyari == DialogResult.Yes)
            {
                string ChekDt="";
                if (RBT.Checked == true)
                {
                    ChekDt = RBT.Text;
                }
                else if (RB1.Checked == true)
                {
                    ChekDt = RB1.Text;
                }
                else if (RB2.Checked == true)
                {
                    ChekDt = RB2.Text;
                }
                try
                {
                    int id = int.Parse(idtut.Text);
                    VMSED Kyd = new VMSED()
                    {
                        BasvuraninBilgileriID= id,
                        AdiSoyadi = TxtBasvuranAd.Text,
                        Adres = TxtAdres.Text,
                        ArsivNo = TxtANo.Text,
                        BasvuruNedeni = CBoxN.SelectedItem.ToString(),
                        BasvuruTarihi = DateBT.Text,
                        DogumTarihi = DateDogumT.Text,
                        DosyaTarihi = DateTime.Now.ToShortDateString(),
                        Durum = CboxDurum.SelectedItem.ToString(),
                        mahalleKoy = CboxMa.SelectedItem.ToString(),
                        OdemeBaslangici = DateOB.Text,
                        OdemeBitisi = DateOBi.Text,
                        OdemeSuresi = ChekDt,
                        Tarih = DateTime.Now.ToShortDateString(),
                        TC = TxtTc.Text,
                        Telefon = TxtTel.Text,
                        YakinlikDurumu = CboxYD.SelectedItem.ToString(),
                        YardimAlaninAdiSoyadi = TxtAdY.Text,
                        YardimAlaninDogumTarihi = DateDY.Text,
                        YardimAlaninTC = TxtTcY.Text,
                        YBSNo = TxtYBS.Text,
                        not = SEDNot.Text
                    };
                    MessageBox.Show(SEDRepo.Guncelle(Kyd));
                    SEDRaporFormu_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Gerekli Alanlar Doldurulmadan Kayıt Güncellenemez!");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SEDRepo.Sil(idtut.Text));
            this.Close();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            DosyaGecmisiForm ac = new DosyaGecmisiForm();
            ac.ID = idtut.Text;
            ac.Show();
        }

        private void DenetimYapBtn_Click(object sender, EventArgs e)
        {
            DialogResult Uyari = new DialogResult();
            Uyari = MessageBox.Show("Bu Dosyaya Denetim Yapmak Üzerisiniz, Devam Edilsin mi?", "DİKKAT!", MessageBoxButtons.YesNo);
            if (Uyari == DialogResult.Yes)
            {
                DenetimRepo.DenetimYapSED(idtut.Text);
                SEDRaporFormu_Load(sender, e);
            }
        }

        private void TxtTc_KeyPress(object sender, KeyPressEventArgs e) //Harf Giremez
        {
            e.Handled = Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar);
        }

        private void TxtBasvuranAd_TextChanged(object sender, EventArgs e) //büyük harf
        {
            TextBox txBox = (TextBox)sender;
            int pos = txBox.SelectionStart;
            int slen = txBox.SelectionLength;
            txBox.Text = txBox.Text.ToUpper();
            txBox.SelectionStart = pos;
            txBox.SelectionLength = slen;
            txBox.Focus();
        }

        private void CboxMa_TextChanged(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.ComboBoxEdit txBox = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            int pos = txBox.SelectionStart;
            int slen = txBox.SelectionLength;
            txBox.Text = txBox.Text.ToUpper();
            txBox.SelectionStart = pos;
            txBox.SelectionLength = slen;
            txBox.Focus();
        }
    }
}
