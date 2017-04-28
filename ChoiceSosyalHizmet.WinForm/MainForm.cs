using ChoiceSosyalHizmet.DAL.Repos;
using ChoiceSosyalHizmet.DAL.VM;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            RBT.Checked = false;
            RB1.Checked = false;
            RB2.Checked = false;
            SEDNot.Clear();
        }

        private void EBHButonTemizle()
        {
            EbhAd.Clear();
            EbhAdres.Clear();
            EbhARN.Clear();
            EbhBTA.Text = "";
            EbhDT.Text = "";
            EbhDurum.SelectedIndex = -1;
            EbhMK.Text = "";
            EbhOBT.Text = "";
            EbhTC.Clear();
            EbhTel.Clear();
            EbhBYD.SelectedIndex = -1;
            richTextBox1.Clear();
            EbhBad.Clear();
            EbhBDT.Text = "";
            EbhBtc.Clear();
            EbhRSU.SelectedIndex = -1;
            RDE.Checked = false;
            RDE2.Checked = false;
            EbhBTT.Text = "";
            EbhBTTT.Text = "";
            EbhYBS.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e) // MainForm Load İşlemi
        {
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            SEDRaporGrid.DataSource = SEDRepo.RaporListe();
            EBHRaporGrid.DataSource = EBHRepo.TumRaporListe();
            PersonelGrid.DataSource = PersonelRepo.PersonelRaporla();
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
                if (Sonuc != "Kayıt Başarıyla Kaydedildi!")
                {
                    MessageBox.Show(Sonuc);
                    return;
                }
                else
                {
                    MessageBox.Show(Sonuc);
                    SEDButonTemizle();
                    SEDRaporGrid.DataSource = SEDRepo.RaporListe();
                }
            }
            catch
            {
                Sonuc = "Tüm Alanlar Doldurulmadan Kayıt Yapılamaz!";
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
            DialogResult Uyari = new DialogResult();
            Uyari = MessageBox.Show("Güncellenecek Devam Edilsin mi?", "DİKKAT!", MessageBoxButtons.YesNo);
            if (Uyari == DialogResult.Yes)
            {
                string ChekDt, sonuc;
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
                    SEDRaporGrid.DataSource = SEDRepo.RaporListe();
                    SEDButonTemizle();
                }
                catch
                {
                    MessageBox.Show("Tüm Alanlar Doldurulmadan Güncelleme Yapılamaz!");
                }
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e) // SED Temizle Butonu
        {
            SEDButonTemizle();
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e) //SED Excel Aktarma İşlemi
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Microsoft Excel Engine|*.xlxs";
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                SEDRaporGrid.ExportToXlsx(save.FileName);
            }
        }

        private void EbhKaydet_Click(object sender, EventArgs e) //EBH Kaydet Butonu
        {
            string ChekDt, baslangict, bitistt = "", Sonuc,RaporSuresi="";
            if (RDE.Checked == true && EbhBTT.Text !="")
            {
                ChekDt = RDE.Text;
                baslangict = EbhBTT.Text;
            }
            else if (RDE2.Checked == true && EbhBTT.Text != "")
            {
                ChekDt = RDE2.Text;
                baslangict = EbhBTT.Text;
                bitistt = EbhBTTT.Text;
                RaporSuresi = EbhRSU.SelectedItem.ToString();
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
                    AdiSoyadi = EbhAd.Text,
                    Adres = EbhAdres.Text,
                    ArsivNo = EbhARN.Text,
                    BasvuruTarihi = EbhBTA.SelectedText,
                    DogumTarihi = EbhDT.SelectedText,
                    DosyaTarihi = DateTime.Now.ToShortDateString(),
                    Durum = EbhDurum.SelectedItem.ToString(),
                    mahalleKoy = EbhMK.SelectedText,
                    OdemeBaslangici = EbhOBT.SelectedText,
                    Tarih = DateTime.Now.ToShortDateString(),
                    TC = EbhTC.Text,
                    Telefon = EbhTel.Text,
                    YakinlikDurumu = EbhBYD.SelectedItem.ToString(),
                    YBSNo = EbhYBS.Text,
                    Not = richTextBox1.Text,
                    BakiciBilgileriAdiSoyadi = EbhBad.Text,
                    BakiciBilgileriDogumTarihi = EbhBDT.SelectedText,
                    BakiciBilgileriTC = EbhBtc.Text,
                    BaslangicTarihi = baslangict,
                    BitisTarihi = bitistt,
                    RaporSuresi = RaporSuresi,
                    RaporTipi = ChekDt,
                };
                Sonuc = EBHRepo.Kaydet(Kyd);
                if (Sonuc != "Kayıt Başarıyla Kaydedildi!")
                {
                    MessageBox.Show(Sonuc);
                    return;
                }
                else
                {
                    MessageBox.Show(Sonuc);
                    EBHButonTemizle();
                    EBHRaporGrid.DataSource = EBHRepo.TumRaporListe();
                }
            }
            catch
            {
                Sonuc = "Tüm Alanlar Doldurulmadan Kayıt Yapılamaz!";
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
            }
        }
        private bool ac;
        private void EbhRSU_SelectedIndexChanged(object sender, EventArgs e) //EBH Rapor Tipi Seçimi
        {
            if (EbhBTT.Text == ""&& ac==false)
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
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "1 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(1);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "2 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(2);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "3 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(3);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "4 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(4);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                    }
                    else if (EbhRSU.SelectedItem.ToString() == "5 YIL")
                    {
                        bitistar = Baslangictarihi.AddYears(5);
                        EbhBTTT.Text = bitistar.ToShortDateString();
                    }
                }
                catch
                {
                }
            }
            EbhRSU.SelectedIndex = -1;
            ac = false;
        }

        private void EbhTemizle_Click(object sender, EventArgs e) //EBH Temizle Butonu
        {
            EBHButonTemizle();
        }

        private void EbhGuncelle_Click(object sender, EventArgs e) //EBH Güncelle Butonu
        {
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
                    RaporSuresi = EbhRSU.SelectedItem.ToString();
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
                        AdiSoyadi = EbhAd.Text,
                        Adres = EbhAdres.Text,
                        ArsivNo = EbhARN.Text,
                        BasvuruTarihi = EbhBTA.SelectedText,
                        DogumTarihi = EbhDT.SelectedText,
                        DosyaTarihi = DateTime.Now.ToShortDateString(),
                        Durum = EbhDurum.SelectedItem.ToString(),
                        mahalleKoy = EbhMK.SelectedText,
                        OdemeBaslangici = EbhOBT.SelectedText,
                        Tarih = DateTime.Now.ToShortDateString(),
                        TC = EbhTC.Text,
                        Telefon = EbhTel.Text,
                        YakinlikDurumu = EbhBYD.SelectedItem.ToString(),
                        YBSNo = EbhYBS.Text,
                        Not = richTextBox1.Text,
                        BakiciBilgileriAdiSoyadi = EbhBad.Text,
                        BakiciBilgileriDogumTarihi = EbhBDT.SelectedText,
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
                        return;
                    }
                    else
                    {
                        MessageBox.Show(Sonuc);
                        EBHButonTemizle();
                        EBHRaporGrid.DataSource = EBHRepo.TumRaporListe();
                    }
                }
                catch
                {
                    Sonuc = "Tüm Alanlar Doldurulmadan Güncelleme Yapılamaz!";
                }
            }
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e) //SED Rapor Detay Tıklama
        {
            try
            {
                string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                SEDRaporFormu ac = new SEDRaporFormu();
                ac.idtut.Text = ID;
                ac.Show();
                this.Hide();
            }
            catch
            {
            }
            
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            VMPersonel per = new VMPersonel()
            {
                AdiSoyadi = Perad.Text,
                TC = Pertc.Text
            };
            MessageBox.Show( PersonelRepo.PersonelEkle(per));
            Perad.Clear();
            Pertc.Clear();
        }
    }
}
