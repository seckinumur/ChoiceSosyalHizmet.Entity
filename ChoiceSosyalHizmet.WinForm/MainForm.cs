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
       

        public void MainForm_Load(object sender, EventArgs e) // MainForm Load İşlemi
        {
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);

            SEDRaporGrid.DataSource = SEDRepo.RaporListe();
            EBHRaporGrid.DataSource = EBHRepo.RaporListe();
            PersonelGrid.DataSource = PersonelRepo.PersonelRaporla();
            EvrakGrid.DataSource = ZimmetSEDRepo.ZimmetListele();
            EvrakZimmetEBHGrid.DataSource = ZimmetEBHRepo.ZimmetListele();
            gridControl1.DataSource = MahalleKoyRepo.MaahalleKoyRaporla();
            gridControl2.DataSource = KullanicilarRepo.KullaniciListele();
            DenetimRepo.DenetimSEDAI();
            DenetimRepo.DenetimEBHAI();
            gridView1.GroupPanelText = "Choice SHM SED  Arama Motoru V.0.7 | Toplam Kayıt Sayısı: " + gridView1.RowCount.ToString();
            gridView2.GroupPanelText = "Choice SHM EBH  Arama Motoru V.0.7 | Toplam Kayıt Sayısı: " + gridView2.RowCount.ToString();
            var almahalle = MahalleKoyRepo.MahalleKarsila();
            foreach (var a in almahalle)
            {
                CboxMa.Properties.Items.Add(a);
                EbhMK.Properties.Items.Add(a);
            }
            
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
                    mahalleKoy = CboxMa.Text,
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
            DateOBi.Text = "";
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
                    mahalleKoy = EbhMK.Text,
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
                    EBHRaporGrid.DataSource = EBHRepo.RaporListe();
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
                EbhBTTT.Text = "";
                EbhRSU.SelectedIndex = -1;
            }
        }
        private bool ac;
        private void EbhRSU_SelectedIndexChanged(object sender, EventArgs e) //EBH Rapor Tipi Seçimi
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

        private void EbhTemizle_Click(object sender, EventArgs e) //EBH Temizle Butonu
        {
            EBHButonTemizle();
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

        private void materialFlatButton1_Click(object sender, EventArgs e) // Personel Kaydetme
        {
            if (Perad.Text != "" && Pertc.Text != "")
            {
                try
                {
                    VMPersonel per = new VMPersonel()
                    {
                        AdiSoyadi = Perad.Text,
                        TC = Pertc.Text
                    };
                    MessageBox.Show(PersonelRepo.PersonelEkle(per));
                    Perad.Clear();
                    Pertc.Clear();
                    PersonelGrid.DataSource = PersonelRepo.PersonelRaporla();
                }
                catch
                {
                    MessageBox.Show("Personel Sisteminde Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Dolsurun");
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e) //Personel Güncelleme
        {
            try
            {
                if (personelidalma.Text == "")
                {
                    MessageBox.Show("Güncellenecek Personeli Seçin!");
                }
                else
                {
                    VMPersonel gnc = new VMPersonel()
                    {
                        AdiSoyadi = Perad.Text,
                        TC = Pertc.Text,
                        PersonelID = int.Parse(personelidalma.Text)
                    };
                    MessageBox.Show(PersonelRepo.PersonelGuncelle(gnc));
                    Perad.Clear();
                    Pertc.Clear();
                    PersonelGrid.DataSource = PersonelRepo.PersonelRaporla();
                }
            }
            catch
            {
                MessageBox.Show("Personel Sisteminde Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
            }
        }

        private void gridView4_DoubleClick(object sender, EventArgs e) //personel grid çift tıklama seçim
        {
            try
            {
                string ID = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "PersonelID").ToString();
                var a = PersonelRepo.PersonelBul(ID);
                Perad.Text = a.AdiSoyadi;
                Pertc.Text = a.TC;
                personelidalma.Text = a.PersonelID.ToString();
                materialFlatButton2.Enabled = true;
            }
            catch
            {
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e) // PErsonel Silme
        {
            try
            {
                if (personelidalma.Text == "")
                {
                    MessageBox.Show("Silinecek Personeli Seçin!");
                }
                else
                {
                    MessageBox.Show(PersonelRepo.PersonelSil(personelidalma.Text));
                    PersonelGrid.DataSource = PersonelRepo.PersonelRaporla();
                    Perad.Clear();
                    Pertc.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Personel Sisteminde Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
            }

        }

        private void gridView2_DoubleClick(object sender, EventArgs e) //EBH Grid Çift Tıklama
        {
            try
            {
                string ID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID").ToString();
                EBHRaporFormu ac = new EBHRaporFormu();
                ac.idtut.Text = ID;
                ac.Show();
                this.Hide();
            }
            catch
            {
            }
        }

        private void materialRaisedButton10_Click(object sender, EventArgs e) // EBH Excell Yazdırma
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Microsoft Excel Engine|*.xlxs";
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                EBHRaporGrid.ExportToXlsx(save.FileName);
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e) //SED Tarih Ararlığı Sıralama
        {
            if (Tarih1SED.Text == "" && Tarih2SED.Text == "")
            {
                MessageBox.Show("Sıralanacak Tarhleri Eksiksiz Girin!");
            }
            else
            {
                SEDRaporGrid.DataSource = SEDRepo.RaporTarih(Tarih1SED.DateTime.ToShortDateString(), Tarih2SED.DateTime.ToShortDateString());
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) //SED Grid Temizleme
        {
            SEDRaporGrid.DataSource = SEDRepo.RaporListe();
            Tarih1SED.Text = "";
            Tarih2SED.Text = "";
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e) //EBH grid tarih sırala
        {
            if (Tarih1EBH.Text == "" && Tarih2EBH.Text == "")
            {
                MessageBox.Show("Sıralanacak Tarhleri Eksiksiz Girin!");
            }
            else
            {
                EBHRaporGrid.DataSource = EBHRepo.RaporTarih(Tarih1EBH.DateTime.ToShortDateString(), Tarih2EBH.DateTime.ToShortDateString());
            }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            EBHRaporGrid.DataSource = EBHRepo.RaporListe();
        }

        private void materialRaisedButton14_Click(object sender, EventArgs e) // Evrakzimmet sed excell aktar
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Microsoft Excel Engine|*.xlxs";
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                EvrakGrid.ExportToXlsx(save.FileName);
            }
        }

        private void materialRaisedButton18_Click(object sender, EventArgs e) //evrak zimmet EBH excell aktar
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Microsoft Excel Engine|*.xlxs";
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                EvrakZimmetEBHGrid.ExportToXlsx(save.FileName);
            }
        }

        private void materialFlatButton8_Click(object sender, EventArgs e) //Mahalle köy Ekle
        {
            if (MahalleKoyText.Text != "")
            {
                try
                {
                    VMMahalleKoy per = new VMMahalleKoy()
                    {
                        Isim = MahalleKoyText.Text
                    };
                    MessageBox.Show(MahalleKoyRepo.MahalleKoyEkle(per));
                    MahalleKoyText.Clear();
                    gridControl1.DataSource = MahalleKoyRepo.MaahalleKoyRaporla();
                }
                catch
                {
                    MessageBox.Show("Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Dolsurun");
            }
        }

        private void materialFlatButton7_Click(object sender, EventArgs e) //mahalle köy güncelle
        {
            try
            {
                if (MahalleIDAlma.Text == "")
                {
                    MessageBox.Show("Güncellenecek Mahalle/Köy Seçin!");
                }
                else
                {
                    VMMahalleKoy gnc = new VMMahalleKoy()
                    {
                        Isim = MahalleKoyText.Text,
                        MahalleKoyID = int.Parse(MahalleIDAlma.Text)
                    };
                    MessageBox.Show(MahalleKoyRepo.MahalleKoyGuncelle(gnc));
                    gridControl1.DataSource = MahalleKoyRepo.MaahalleKoyRaporla();
                    MahalleIDAlma.Text = "";
                    MahalleKoyText.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
            }
        }

        private void materialFlatButton6_Click(object sender, EventArgs e) // Mahalle Köy Silme
        {
            try
            {
                if (MahalleIDAlma.Text == "")
                {
                    MessageBox.Show("Silinecek Mahalle/Köy Seçin!");
                }
                else
                {
                    MessageBox.Show(MahalleKoyRepo.MahalleKoySil(MahalleIDAlma.Text));
                    gridControl1.DataSource = MahalleKoyRepo.MaahalleKoyRaporla();
                    MahalleIDAlma.Text = "";
                    MahalleKoyText.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
            }
        }

        private void gridView6_DoubleClick(object sender, EventArgs e) //Mahalle Köy girid çift tıklama
        {
            try
            {
                string ID = gridView6.GetRowCellValue(gridView6.FocusedRowHandle, "MahalleKoyID").ToString();
                var a = MahalleKoyRepo.MahalleKoyBul(ID);
                MahalleIDAlma.Text = a.Isim;
                MahalleIDAlma.Text = a.MahalleKoyID.ToString();
                materialFlatButton7.Enabled = true;
            }
            catch
            {
            }
        }

        private void materialRaisedButton12_Click(object sender, EventArgs e) //Sed Denetime Gidilmeyenleri Sırala
        {
            SEDRaporGrid.DataSource = DenetimRepo.DenetimGidilmemisSED();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) //Sed Bitiş Tarihi 1 Ay Kala
        {
            SEDRaporGrid.DataSource = DenetimRepo.BitisTarihiSED();
        }

        private void materialRaisedButton11_Click(object sender, EventArgs e) //Ebh Denetime Gidilmeyenleri Sırala
        {
            EBHRaporGrid.DataSource = DenetimRepo.DenetimGidilmemisEBH();
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e) // Ebh bitişine 3 ay kalanları sırala
        {
            EBHRaporGrid.DataSource = DenetimRepo.BitisTarihiEBH();
        }

        private void materialFlatButton12_Click(object sender, EventArgs e) //Kullanici Ekle
        {
            if(KullaniciAdi.Text=="" && SifreKullanici.Text == "")
            {
                MessageBox.Show("Boş Olmaz");
            }
            else
            {
                try
                {
                    VMKullanicilar ekle = new VMKullanicilar()
                    {
                        KullaniciAdi = KullaniciAdi.Text,
                        Sifre = SifreKullanici.Text
                    };
                    MessageBox.Show(KullanicilarRepo.KullaniciEkle(ekle));
                }
                catch
                {
                    MessageBox.Show("Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
                }
            }
        }

        private void gridView7_DoubleClick(object sender, EventArgs e) //Kullanıcılar girid
        {
            try
            {
                string ID = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "KullanicilarID").ToString();
                var bu = KullanicilarRepo.KullaniciBul(ID);
                KullaniciAdi.Text = bu.KullaniciAdi;
                SifreKullanici.Text = bu.Sifre;
            }
            catch
            {
                MessageBox.Show("Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
            }
        }

        private void materialFlatButton10_Click(object sender, EventArgs e) // Kullanıcı Sil
        {
            try
            {
                if (KullaniciAdi.Text == "" && SifreKullanici.Text == "")
                {
                    MessageBox.Show("Silinecek Kullanıcıyı Yazın");
                }
                else
                {
                    VMKullanicilar sil = new VMKullanicilar()
                    {
                        KullaniciAdi = KullaniciAdi.Text,
                        Sifre = SifreKullanici.Text
                    };
                    MessageBox.Show(KullanicilarRepo.KullaniciSil(sil));
                }
            }
            catch
            {
                MessageBox.Show("Öngörülemeyen Hata Oluştu. Sistem Bu hata Nedeniyle Çökmekten Başarıyla Kurtarıldı!");
            }
            
        }
    }
}
