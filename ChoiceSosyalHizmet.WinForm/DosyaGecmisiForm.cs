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
    public partial class DosyaGecmisiForm : MaterialForm
    {
        public bool kontrol;
        public string ID;
        public DosyaGecmisiForm()
        {
            InitializeComponent();
        }

        private void DosyaGecmisiForm_Load(object sender, EventArgs e)
        {
            if (kontrol == false)
            {
               EvrakGrid.DataSource= SEDRepo.DosyaTakipBul(ID);
            }
            else
            {
                EvrakGrid.DataSource = EBHRepo.DosyaTakipBul(ID);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Microsoft Excel Engine|*.xlxs";
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                EvrakGrid.ExportToXlsx(save.FileName);
            }
        }
    }
}
