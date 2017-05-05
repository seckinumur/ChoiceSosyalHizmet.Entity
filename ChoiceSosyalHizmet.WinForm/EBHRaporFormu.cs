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
    public partial class EBHRaporFormu : MaterialForm
    {
        public MainForm AnaEkran = (MainForm)Application.OpenForms["MainForm"];
        private bool zimmetkontrol;
        public EBHRaporFormu()
        {
            InitializeComponent();
        }

        public void EBHRaporFormu_Load(object sender, EventArgs e)
        {
            var almahalle = MahalleKoyRepo.MahalleKarsila();
            foreach (var a in almahalle)
            {
                EbhMK.Properties.Items.Add(a);
            }
            ZAT.Text = "";
            var al = EBHRepo.EBHBul(idtut.Text);
            EbhAd.Text = al.AdiSoyadi;
            EbhAdres.Text = al.Adres;
            EbhARN.Text = al.ArsivNo;
            EbhBTA.Text = al.BasvuruTarihi;
            EbhDT.Text = al.DogumTarihi;
            EbhDurum.SelectedItem = al.Durum;
            EbhMK.SelectedItem = al.mahalleKoy;
            EbhOBT.Text = al.OdemeBaslangici;
            EbhTC.Text = al.TC;
            EbhTel.Text = al.Telefon;
            EbhBYD.SelectedItem = al.YakinlikDurumu;
            EbhYBS.Text = al.YBSNo;
            SEDNot.Text = al.Not;
            EbhBad.Text = al.BakiciBilgileriAdiSoyadi;
            EbhBDT.Text = al.BakiciBilgileriDogumTarihi;
            EbhBtc.Text = al.BakiciBilgileriTC;
            EbhBTT.Text = al.BaslangicTarihi;
            EbhBTTT.Text = al.BitisTarihi;
            EbhRSU.SelectedItem = al.RaporSuresi;
            if (al.RaporTipi == "Sürekli")
            {
                RDE.Checked = true;
            }
            else if (al.RaporTipi == "Süreksiz")
            {
                RDE2.Checked = true;
            }

            try
            {
                var zimmet = ZimmetEBHRepo.ZimmetBul(al.EngelliBilgileriID);
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
            if (DenetimRepo.DenetimKontrolEBH(idtut.Text) == false)
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int idalma = int.Parse(idtut.Text);
            DialogResult Uyari = new DialogResult();
            Uyari = MessageBox.Show("Güncellenecek Devam Edilsin mi?", "DİKKAT!", MessageBoxButtons.YesNo);
            if (Uyari == DialogResult.Yes)
            {
                string ChekDt, baslangict, bitistt = "", Sonuc, RaporSuresi = "";
                if (RDE.Checked == true && EbhBTT.Text != "")
                {
                    ChekDt = RDE.Text;
                    baslangict = EbhBTT.Text;
                }
                else if (RDE2.Checked == true && EbhBTT.Text != "")
                {
                    ChekDt = RDE2.Text;
                    baslangict = EbhBTT.Text;
                    bitistt = EbhBTTT.Text;
                    RaporSuresi = EbhRSU.Text;
                }
                else
                {
                    MessageBox.Show("Rapor Bilgileri Boş Bırakılamaz!");
                    return;
                }
                try
                {
                    VMEBH Kyd = new VMEBH()
                    {
                        EngelliBilgileriID = idalma,
                        AdiSoyadi = EbhAd.Text,
                        Adres = EbhAdres.Text,
                        ArsivNo = EbhARN.Text,
                        BasvuruTarihi = EbhBTA.DateTime.ToShortDateString(),
                        DogumTarihi = EbhDT.Text,
                        DosyaTarihi = DateTime.Now.ToShortDateString(),
                        Durum = EbhDurum.SelectedItem.ToString(),
                        mahalleKoy = EbhMK.SelectedItem.ToString(),
                        OdemeBaslangici = EbhOBT.Text,
                        Tarih = DateTime.Now.ToShortDateString(),
                        TC = EbhTC.Text,
                        Telefon = EbhTel.Text,
                        YakinlikDurumu = EbhBYD.SelectedItem.ToString(),
                        YBSNo = EbhYBS.Text,
                        Not = SEDNot.Text,
                        BakiciBilgileriAdiSoyadi = EbhBad.Text,
                        BakiciBilgileriDogumTarihi = EbhBDT.DateTime.ToShortDateString(),
                        BakiciBilgileriTC = EbhBtc.Text,
                        BaslangicTarihi = baslangict,
                        BitisTarihi = bitistt,
                        RaporSuresi = RaporSuresi,
                        RaporTipi = ChekDt,
                    };
                    Sonuc = EBHRepo.Guncelle(Kyd);
                    if (Sonuc != "Kayıt Başarıyla Güncellendi!")
                    {
                        MessageBox.Show(Sonuc);
                    }
                    else
                    {
                        MessageBox.Show(Sonuc);
                    }
                    EBHRaporFormu_Load(sender, e);
                }
                catch
                {
                    Sonuc = "Tüm Alanlar Doldurulmadan Kayıt Yapılamaz!";
                }
            }
        }

        private void RDE2_CheckedChanged(object sender, EventArgs e)
        {
            if (RDE2.Checked == true)
            {
                EbhRSU.Enabled = true;
                EbhBTTT.Enabled = true;
            }
            else
            {
                EbhRSU.Enabled = false;
                EbhBTTT.Enabled = false;
                EbhBTTT.Text = "";
                EbhRSU.SelectedIndex = -1;
            }
        }
        private bool ac;
        private void EbhRSU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EbhBTT.Text == "" && ac == false)
            {
                ac = true;
                MessageBox.Show("Önce Başlangıç Tarihi Seçin");
            }
            else
            {
                try
                {
                    DateTime Baslangictarihi = EbhBTT.DateTime, bitistar;
                    if (EbhRSU.SelectedItem.ToString() == "6 AY")
                    {
                        bitistar = Baslangictarihi.AddMonths(6);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                        return;
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "1 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(1);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                        return;
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "2 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(2);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                        return;
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "3 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(3);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                        return;
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "4 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(4);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                        return;
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "5 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(5);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                        return;
                    }
                }
                catch
                {
                }
            }
            EbhRSU.SelectedIndex = -1;
            ac = false;
        }

        private void zimmetbuton_Click(object sender, EventArgs e)
        {
            if (zimmetkontrol == true)
            {
                PersonelListesiForm ac = new PersonelListesiForm();
                ac.zimmetkontrol = false;
                ac.Bolum = true;
                ac.ID = int.Parse(idtut.Text);
                ac.Show();
                zimmetkontrol = false;
            }
            else
            {
                ZimmetEBHRepo.ZimmetKaldır(PersonelIDsi.Text);
                MessageBox.Show("Evrak Zimmeti Kaldırıldı!");
                EBHRaporFormu_Load(sender, e);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EBHRepo.Sil(idtut.Text));
            this.Close();
        }

        private void EBHRaporFormu_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnaEkran.Enabled = true;
            AnaEkran.MainForm_Load(sender, e);
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            DosyaGecmisiForm ac = new DosyaGecmisiForm();
            ac.ID = idtut.Text;
            ac.kontrol = true;
            ac.Show();
        }

        private void DenetimYapBtn_Click(object sender, EventArgs e)
        {
            DialogResult Uyari = new DialogResult();
            Uyari = MessageBox.Show("Bu Dosyaya Denetim Yapmak Üzerisiniz, Devam Edilsin mi?", "DİKKAT!", MessageBoxButtons.YesNo);
            if (Uyari == DialogResult.Yes)
            {
                DenetimRepo.DenetimYapEBH(idtut.Text);
                EBHRaporFormu_Load(sender, e);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void EbhTC_KeyPress(object sender, KeyPressEventArgs e) //harf giremez
        {
            e.Handled = Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar);
        }

        private void EbhAd_TextChanged(object sender, EventArgs e)//büyük harf
        {
            TextBox txBox = (TextBox)sender;
            int pos = txBox.SelectionStart;
            int slen = txBox.SelectionLength;
            txBox.Text = txBox.Text.ToUpper();
            txBox.SelectionStart = pos;
            txBox.SelectionLength = slen;
            txBox.Focus();
        }

        private void EbhMK_TextChanged(object sender, EventArgs e)
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
