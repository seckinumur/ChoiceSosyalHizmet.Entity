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
    public partial class PersonelListesiForm : MaterialForm
    {
        public SEDRaporFormu sedr = (SEDRaporFormu)Application.OpenForms["SEDRaporFormu"];
        public EBHRaporFormu sedr1 = (EBHRaporFormu)Application.OpenForms["EBHRaporFormu"];
        public PersonelListesiForm()
        {
            InitializeComponent();
        }
        public bool zimmetkontrol;
        public bool Bolum;
        public int ID;
        public int iD;
        private void PersonelListesiForm_Load(object sender, EventArgs e)
        {
            PersonelGrid.DataSource = PersonelRepo.PersonelRaporla();
        }

    
        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "PersonelID").ToString());
                if (Bolum == false)
                {
                    if (zimmetkontrol == false)
                    {
                        sedr.zimmetname.Text = ZimmetSEDRepo.ZimmeteEkle(id, ID);
                        MessageBox.Show("Evrak Zimmetlendi!");
                        this.Close();
                        sedr.SEDRaporFormu_Load(sender, e);
                    }
                }
                else
                {
                    if (zimmetkontrol == false)
                    {
                        sedr1.zimmetname.Text = ZimmetEBHRepo.ZimmeteEkle(id, ID);
                        MessageBox.Show("Evrak Zimmetlendi!");
                        this.Close();
                        sedr1.EBHRaporFormu_Load(sender, e);
                    }
                }
            }
            catch
            {
            }
        }

        private void PersonelListesiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sedr.SEDRaporFormu_Load(sender, e);
            }
            catch
            {
                sedr1.EBHRaporFormu_Load(sender, e);
            }
            
        }
    }
}
