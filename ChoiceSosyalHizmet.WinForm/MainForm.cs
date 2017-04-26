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
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SEDButonTemizle() // SED Buton Temizleme Metodu
        {
            TxtBasvuranAd.Clear();
            TxtAdres.Clear();
            TxtANo.Clear();
            CBoxN.SelectedIndex = -1;
            DateBT.Text = "";
            DateDogumT.Text = "";
            CboxDurum.SelectedIndex = -1;
            CboxMa.Text = "";
            DateOB.Text = "";
            DateOBi.Text = "";
            TxtTc.Clear();
            TxtTel.Clear();
            CboxYD.SelectedIndex = -1;
            TxtAdY.Clear();
            DateDY.Text = "";
            TxtTcY.Clear();
            TxtYBS.Clear();
            SEDNot.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e) // MainForm Load İşlemi
        {
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            SEDRaporGrid.DataSource = SEDRepo.RaporListe();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) // MainForm Kapatılırsa Uygulamadan Çıkma
        {
            Application.Exit();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)  // SED Kaydet Butonu
        {
            string ChekDt, Sonuc;
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
            else
            {
                MessageBox.Show("Ödeme Süresi Seçmediniz!");
                return;
            }
            try
            {
                VMSED Kyd = new VMSED()
                {
                    AdiSoyadi = TxtBasvuranAd.Text,
                    Adres = TxtAdres.Text,
                    ArsivNo = TxtANo.Text,
                    BasvuruNedeni = CBoxN.SelectedItem.ToString(),
                    BasvuruTarihi = DateBT.SelectedText,
                    DogumTarihi = DateDogumT.SelectedText,
                    DosyaTarihi = DateTime.Now.ToShortDateString(),
                    Durum = CboxDurum.SelectedItem.ToString(),
                    mahalleKoy = CboxMa.SelectedText,
                    OdemeBaslangici = DateOB.SelectedText,
                    OdemeBitisi = DateOBi.Text,
                    OdemeSuresi = ChekDt,
                    Tarih = DateTime.Now.ToShortDateString(),
                    TC = TxtTc.Text,
                    Telefon = TxtTel.Text,
                    YakinlikDurumu = CboxYD.SelectedItem.ToString(),
                    YardimAlaninAdiSoyadi = TxtAdY.Text,
                    YardimAlaninDogumTarihi = DateDY.SelectedText,
                    YardimAlaninTC = TxtTcY.Text,
                    YBSNo = TxtYBS.Text,
                    not = SEDNot.Text
                };

                Sonuc = SEDRepo.Kaydet(Kyd);
            }
            catch
            {
                Sonuc = "Tüm Alanlar Doldurulmadan Kayıt Yapılamaz!";
            }
           
            if (Sonuc != "Kayıt Başarıyla Kaydedildi!")
            {
                MessageBox.Show(Sonuc);
                return;
            }
            else
            {
                MessageBox.Show(Sonuc);
                SEDButonTemizle();
                SEDRaporGrid.Refresh();
            }
        }

        private void RB1_CheckedChanged(object sender, EventArgs e) // SED Radio Buton 1 Yıllık Kontrolü
        {
            if (DateOB.SelectedText == "")
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

        private void RB2_CheckedChanged(object sender, EventArgs e) // SED Radio Buton 2 Yıllık Kontrolü
        {
            if (DateOB.SelectedText == "")
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

        private void RBT_CheckedChanged(object sender, EventArgs e) // SED Radio Buton Tek Seferlik Kontrolü
        {
            DateOBi.Enabled = false;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e) //SED Güncelle Butonu
        {
            string ChekDt,sonuc;
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
            else
            {
                return;
            }
            try
            {
                VMSED Kyd = new VMSED()
                {
                    AdiSoyadi = TxtBasvuranAd.Text,
                    Adres = TxtAdres.Text,
                    ArsivNo = TxtANo.Text,
                    BasvuruNedeni = CBoxN.SelectedItem.ToString(),
                    BasvuruTarihi = DateBT.SelectedText,
                    DogumTarihi = DateDogumT.SelectedText,
                    DosyaTarihi = DateTime.Now.ToShortDateString(),
                    Durum = CboxDurum.SelectedItem.ToString(),
                    mahalleKoy = CboxMa.SelectedText,
                    OdemeBaslangici = DateOB.SelectedText,
                    OdemeBitisi = DateOBi.SelectedText,
                    OdemeSuresi = ChekDt,
                    Tarih = DateTime.Now.ToShortDateString(),
                    TC = TxtTc.Text,
                    Telefon = TxtTel.Text,
                    YakinlikDurumu = CboxYD.SelectedItem.ToString(),
                    YardimAlaninAdiSoyadi = TxtAdY.Text,
                    YardimAlaninDogumTarihi = DateDY.SelectedText,
                    YardimAlaninTC = TxtTcY.Text,
                    YBSNo = TxtYBS.Text,
                    not = SEDNot.Text
                };

                sonuc = SEDRepo.Guncelle(Kyd);
                MessageBox.Show(sonuc);
                SEDButonTemizle();
            }
            catch
            {
                MessageBox.Show("Tüm Alanlar Doldurulmadan Güncelleme Yapılamaz!");
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e) // SED Temizle Butonu
        {
            SEDButonTemizle();
        }
    }
}
