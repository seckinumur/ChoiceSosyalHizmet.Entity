namespace ChoiceSosyalHizmet.WinForm
{
    partial class GirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.TxtKullaniciAdi = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtParola = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.BtnGiris = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(70, 163);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(288, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "©2017 Choice AI V.0.8 Security Systems. ";
            // 
            // TxtKullaniciAdi
            // 
            this.TxtKullaniciAdi.Depth = 0;
            this.TxtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtKullaniciAdi.Hint = "Kullanıcı adı";
            this.TxtKullaniciAdi.Location = new System.Drawing.Point(20, 60);
            this.TxtKullaniciAdi.MaxLength = 32767;
            this.TxtKullaniciAdi.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtKullaniciAdi.Name = "TxtKullaniciAdi";
            this.TxtKullaniciAdi.PasswordChar = '\0';
            this.TxtKullaniciAdi.SelectedText = "";
            this.TxtKullaniciAdi.SelectionLength = 0;
            this.TxtKullaniciAdi.SelectionStart = 0;
            this.TxtKullaniciAdi.Size = new System.Drawing.Size(391, 23);
            this.TxtKullaniciAdi.TabIndex = 4;
            this.TxtKullaniciAdi.TabStop = false;
            this.TxtKullaniciAdi.UseSystemPasswordChar = false;
            this.TxtKullaniciAdi.TextChanged += new System.EventHandler(this.TxtKullaniciAdi_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.materialLabel2);
            this.panel1.Controls.Add(this.TxtParola);
            this.panel1.Controls.Add(this.TxtKullaniciAdi);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(12, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 203);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Geometr415 Blk BT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(123, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sisteme Güvenli Giriş";
            // 
            // TxtParola
            // 
            this.TxtParola.Depth = 0;
            this.TxtParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtParola.Hint = "Parola";
            this.TxtParola.Location = new System.Drawing.Point(20, 108);
            this.TxtParola.MaxLength = 32767;
            this.TxtParola.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtParola.Name = "TxtParola";
            this.TxtParola.PasswordChar = '\0';
            this.TxtParola.SelectedText = "";
            this.TxtParola.SelectionLength = 0;
            this.TxtParola.SelectionStart = 0;
            this.TxtParola.Size = new System.Drawing.Size(391, 23);
            this.TxtParola.TabIndex = 5;
            this.TxtParola.TabStop = false;
            this.TxtParola.UseSystemPasswordChar = true;
            this.TxtParola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtParola_KeyDown);
            this.TxtParola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtParola_KeyPress);
            // 
            // BtnGiris
            // 
            this.BtnGiris.AutoSize = true;
            this.BtnGiris.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnGiris.Depth = 0;
            this.BtnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGiris.Icon = null;
            this.BtnGiris.Location = new System.Drawing.Point(160, 572);
            this.BtnGiris.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnGiris.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Primary = false;
            this.BtnGiris.Size = new System.Drawing.Size(144, 36);
            this.BtnGiris.TabIndex = 6;
            this.BtnGiris.Text = "Sisteme Giriş Yap";
            this.BtnGiris.UseVisualStyleBackColor = true;
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = null;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(12, 550);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(456, 78);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChoiceSosyalHizmet.WinForm.Properties.Resources.shm;
            this.pictureBox1.Location = new System.Drawing.Point(115, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 640);
            this.MinimumSize = new System.Drawing.Size(480, 640);
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choice SHM V.1.5 Sisteme Giriş";
            this.Load += new System.EventHandler(this.GirisForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtKullaniciAdi;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton BtnGiris;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtParola;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.Label label1;
    }
}