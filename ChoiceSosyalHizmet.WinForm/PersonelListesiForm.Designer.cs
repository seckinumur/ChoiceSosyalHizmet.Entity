namespace ChoiceSosyalHizmet.WinForm
{
    partial class PersonelListesiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelListesiForm));
            this.PersonelGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.PersonelGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // PersonelGrid
            // 
            this.PersonelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonelGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.PersonelGrid.Font = new System.Drawing.Font("Tahoma", 9F);
            this.PersonelGrid.Location = new System.Drawing.Point(3, 68);
            this.PersonelGrid.MainView = this.gridView4;
            this.PersonelGrid.Margin = new System.Windows.Forms.Padding(4);
            this.PersonelGrid.Name = "PersonelGrid";
            this.PersonelGrid.Size = new System.Drawing.Size(354, 409);
            this.PersonelGrid.TabIndex = 13;
            this.PersonelGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.GridControl = this.PersonelGrid;
            this.gridView4.GroupPanelText = "Choice PERSONEL  Arama Motoru V.0.7 ";
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsFind.AlwaysVisible = true;
            this.gridView4.OptionsFind.FindDelay = 100;
            this.gridView4.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView4.OptionsFind.FindNullPrompt = "TC Kimlik No yada Personel İsmi Arayın...";
            this.gridView4.OptionsFind.SearchInPreview = true;
            this.gridView4.OptionsFind.ShowFindButton = false;
            this.gridView4.DoubleClick += new System.EventHandler(this.gridView4_DoubleClick);
            // 
            // PersonelListesiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 480);
            this.Controls.Add(this.PersonelGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 480);
            this.Name = "PersonelListesiForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Seçim Sistemi";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PersonelListesiForm_FormClosed);
            this.Load += new System.EventHandler(this.PersonelListesiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PersonelGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl PersonelGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
    }
}