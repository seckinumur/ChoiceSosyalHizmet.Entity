namespace ChoiceSosyalHizmet.WinForm
{
    partial class DosyaGecmisiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DosyaGecmisiForm));
            this.EvrakGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.EvrakGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // EvrakGrid
            // 
            this.EvrakGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EvrakGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.EvrakGrid.Location = new System.Drawing.Point(0, 63);
            this.EvrakGrid.MainView = this.gridView3;
            this.EvrakGrid.Margin = new System.Windows.Forms.Padding(4);
            this.EvrakGrid.Name = "EvrakGrid";
            this.EvrakGrid.Size = new System.Drawing.Size(677, 419);
            this.EvrakGrid.TabIndex = 2;
            this.EvrakGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.GridControl = this.EvrakGrid;
            this.gridView3.GroupPanelText = "Choice SHM Dosya Geçmişi Arama Motoru V.0.7 ";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsFind.AlwaysVisible = true;
            this.gridView3.OptionsFind.FindDelay = 100;
            this.gridView3.OptionsFind.FindNullPrompt = "Dosya Geçmişi Ara...";
            this.gridView3.OptionsFind.ShowFindButton = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(0, 485);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(677, 32);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Ecxel\'e Aktar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DosyaGecmisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 522);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.EvrakGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DosyaGecmisiForm";
            this.Text = "Dosya Geçmişi";
            this.Load += new System.EventHandler(this.DosyaGecmisiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EvrakGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl EvrakGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}