namespace rest
{
    partial class frmRaporlar
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.grpMenuBaslik = new System.Windows.Forms.GroupBox();
            this.lvIstatistik = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAraSıcak = new System.Windows.Forms.Button();
            this.btnMakarna = new System.Windows.Forms.Button();
            this.btnCorba = new System.Windows.Forms.Button();
            this.btnFastFood = new System.Windows.Forms.Button();
            this.btnSalatalar = new System.Windows.Forms.Button();
            this.btnTatlilar = new System.Windows.Forms.Button();
            this.btnIcecek = new System.Windows.Forms.Button();
            this.btnAnaYemek = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.grpIstatistik = new System.Windows.Forms.GroupBox();
            this.chRapor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnZraporu = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpMenuBaslik.SuspendLayout();
            this.grpIstatistik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackgroundImage = global::rest.Properties.Resources.geriDon;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriDon.Location = new System.Drawing.Point(30, 699);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(68, 63);
            this.btnGeriDon.TabIndex = 26;
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // grpMenuBaslik
            // 
            this.grpMenuBaslik.BackColor = System.Drawing.Color.Transparent;
            this.grpMenuBaslik.Controls.Add(this.lvIstatistik);
            this.grpMenuBaslik.Controls.Add(this.btnAraSıcak);
            this.grpMenuBaslik.Controls.Add(this.btnMakarna);
            this.grpMenuBaslik.Controls.Add(this.btnCorba);
            this.grpMenuBaslik.Controls.Add(this.btnFastFood);
            this.grpMenuBaslik.Controls.Add(this.btnSalatalar);
            this.grpMenuBaslik.Controls.Add(this.btnTatlilar);
            this.grpMenuBaslik.Controls.Add(this.btnIcecek);
            this.grpMenuBaslik.Controls.Add(this.btnAnaYemek);
            this.grpMenuBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpMenuBaslik.ForeColor = System.Drawing.Color.White;
            this.grpMenuBaslik.Location = new System.Drawing.Point(17, 56);
            this.grpMenuBaslik.Name = "grpMenuBaslik";
            this.grpMenuBaslik.Size = new System.Drawing.Size(314, 558);
            this.grpMenuBaslik.TabIndex = 25;
            this.grpMenuBaslik.TabStop = false;
            this.grpMenuBaslik.Text = "Menü";
            // 
            // lvIstatistik
            // 
            this.lvIstatistik.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvIstatistik.HideSelection = false;
            this.lvIstatistik.Location = new System.Drawing.Point(224, 470);
            this.lvIstatistik.Name = "lvIstatistik";
            this.lvIstatistik.Size = new System.Drawing.Size(10, 10);
            this.lvIstatistik.TabIndex = 1;
            this.lvIstatistik.UseCompatibleStateImageBehavior = false;
            this.lvIstatistik.View = System.Windows.Forms.View.Details;
            this.lvIstatistik.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun Adı";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adedi";
            // 
            // btnAraSıcak
            // 
            this.btnAraSıcak.BackgroundImage = global::rest.Properties.Resources.snackHotMeal;
            this.btnAraSıcak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAraSıcak.Location = new System.Drawing.Point(159, 416);
            this.btnAraSıcak.Name = "btnAraSıcak";
            this.btnAraSıcak.Size = new System.Drawing.Size(140, 126);
            this.btnAraSıcak.TabIndex = 7;
            this.btnAraSıcak.UseVisualStyleBackColor = true;
            this.btnAraSıcak.Click += new System.EventHandler(this.btnAraSıcak_Click);
            this.btnAraSıcak.MouseHover += new System.EventHandler(this.btnAraSıcak_MouseHover);
            // 
            // btnMakarna
            // 
            this.btnMakarna.BackgroundImage = global::rest.Properties.Resources.pasta;
            this.btnMakarna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakarna.Location = new System.Drawing.Point(12, 416);
            this.btnMakarna.Name = "btnMakarna";
            this.btnMakarna.Size = new System.Drawing.Size(140, 126);
            this.btnMakarna.TabIndex = 6;
            this.btnMakarna.UseVisualStyleBackColor = true;
            this.btnMakarna.Click += new System.EventHandler(this.btnMakarna_Click);
            this.btnMakarna.MouseHover += new System.EventHandler(this.btnMakarna_MouseHover);
            // 
            // btnCorba
            // 
            this.btnCorba.BackgroundImage = global::rest.Properties.Resources.soup;
            this.btnCorba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCorba.Location = new System.Drawing.Point(159, 288);
            this.btnCorba.Name = "btnCorba";
            this.btnCorba.Size = new System.Drawing.Size(140, 122);
            this.btnCorba.TabIndex = 5;
            this.btnCorba.UseVisualStyleBackColor = true;
            this.btnCorba.Click += new System.EventHandler(this.btnCorba_Click);
            this.btnCorba.MouseHover += new System.EventHandler(this.btnCorba_MouseHover);
            // 
            // btnFastFood
            // 
            this.btnFastFood.BackgroundImage = global::rest.Properties.Resources.fast;
            this.btnFastFood.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFastFood.Location = new System.Drawing.Point(13, 288);
            this.btnFastFood.Name = "btnFastFood";
            this.btnFastFood.Size = new System.Drawing.Size(140, 122);
            this.btnFastFood.TabIndex = 4;
            this.btnFastFood.UseVisualStyleBackColor = true;
            this.btnFastFood.Click += new System.EventHandler(this.btnFastFood_Click);
            this.btnFastFood.MouseHover += new System.EventHandler(this.btnFastFood_MouseHover);
            // 
            // btnSalatalar
            // 
            this.btnSalatalar.BackgroundImage = global::rest.Properties.Resources.salata;
            this.btnSalatalar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalatalar.Location = new System.Drawing.Point(159, 155);
            this.btnSalatalar.Name = "btnSalatalar";
            this.btnSalatalar.Size = new System.Drawing.Size(140, 127);
            this.btnSalatalar.TabIndex = 3;
            this.btnSalatalar.UseVisualStyleBackColor = true;
            this.btnSalatalar.Click += new System.EventHandler(this.btnSalatalar_Click);
            this.btnSalatalar.MouseHover += new System.EventHandler(this.btnSalatalar_MouseHover);
            // 
            // btnTatlilar
            // 
            this.btnTatlilar.BackgroundImage = global::rest.Properties.Resources.transparentTatli;
            this.btnTatlilar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTatlilar.Location = new System.Drawing.Point(13, 155);
            this.btnTatlilar.Name = "btnTatlilar";
            this.btnTatlilar.Size = new System.Drawing.Size(140, 127);
            this.btnTatlilar.TabIndex = 2;
            this.btnTatlilar.UseVisualStyleBackColor = true;
            this.btnTatlilar.Click += new System.EventHandler(this.btnTatlilar_Click);
            this.btnTatlilar.MouseHover += new System.EventHandler(this.btnTatlilar_MouseHover);
            // 
            // btnIcecek
            // 
            this.btnIcecek.BackgroundImage = global::rest.Properties.Resources.icecek;
            this.btnIcecek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcecek.Location = new System.Drawing.Point(159, 26);
            this.btnIcecek.Name = "btnIcecek";
            this.btnIcecek.Size = new System.Drawing.Size(140, 123);
            this.btnIcecek.TabIndex = 1;
            this.btnIcecek.UseVisualStyleBackColor = true;
            this.btnIcecek.Click += new System.EventHandler(this.btnIcecek_Click);
            this.btnIcecek.MouseHover += new System.EventHandler(this.btnIcecek_MouseHover);
            // 
            // btnAnaYemek
            // 
            this.btnAnaYemek.BackgroundImage = global::rest.Properties.Resources.anaYemek;
            this.btnAnaYemek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnaYemek.Location = new System.Drawing.Point(13, 26);
            this.btnAnaYemek.Name = "btnAnaYemek";
            this.btnAnaYemek.Size = new System.Drawing.Size(140, 123);
            this.btnAnaYemek.TabIndex = 0;
            this.btnAnaYemek.UseVisualStyleBackColor = true;
            this.btnAnaYemek.Click += new System.EventHandler(this.btnAnaYemek_Click);
            this.btnAnaYemek.MouseHover += new System.EventHandler(this.btnAnaYemek_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(442, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Başlangıç Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(494, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "Bitiş Tarihi :";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBaslangic.Location = new System.Drawing.Point(619, 28);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(200, 22);
            this.dtBaslangic.TabIndex = 29;
            this.dtBaslangic.Value = new System.DateTime(2022, 12, 13, 13, 11, 1, 0);
            // 
            // dtBitis
            // 
            this.dtBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBitis.Location = new System.Drawing.Point(619, 89);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(200, 22);
            this.dtBitis.TabIndex = 30;
            // 
            // grpIstatistik
            // 
            this.grpIstatistik.BackColor = System.Drawing.Color.Transparent;
            this.grpIstatistik.Controls.Add(this.chRapor);
            this.grpIstatistik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpIstatistik.ForeColor = System.Drawing.Color.White;
            this.grpIstatistik.Location = new System.Drawing.Point(376, 117);
            this.grpIstatistik.Name = "grpIstatistik";
            this.grpIstatistik.Size = new System.Drawing.Size(814, 581);
            this.grpIstatistik.TabIndex = 31;
            this.grpIstatistik.TabStop = false;
            // 
            // chRapor
            // 
            this.chRapor.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chRapor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chRapor.Legends.Add(legend1);
            this.chRapor.Location = new System.Drawing.Point(6, 11);
            this.chRapor.Name = "chRapor";
            this.chRapor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Satislar";
            this.chRapor.Series.Add(series1);
            this.chRapor.Size = new System.Drawing.Size(802, 564);
            this.chRapor.TabIndex = 0;
            this.chRapor.Text = "chart1";
            // 
            // btnZraporu
            // 
            this.btnZraporu.BackgroundImage = global::rest.Properties.Resources.allProducts;
            this.btnZraporu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZraporu.Location = new System.Drawing.Point(165, 636);
            this.btnZraporu.Name = "btnZraporu";
            this.btnZraporu.Size = new System.Drawing.Size(151, 126);
            this.btnZraporu.TabIndex = 32;
            this.btnZraporu.UseVisualStyleBackColor = true;
            this.btnZraporu.Click += new System.EventHandler(this.btnZraporu_Click);
            this.btnZraporu.MouseHover += new System.EventHandler(this.btnZraporu_MouseHover);
            // 
            // frmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::rest.Properties.Resources.arkaplan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1202, 791);
            this.Controls.Add(this.btnZraporu);
            this.Controls.Add(this.grpIstatistik);
            this.Controls.Add(this.dtBitis);
            this.Controls.Add(this.dtBaslangic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.grpMenuBaslik);
            this.Name = "frmRaporlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAPORLAR";
            this.Load += new System.EventHandler(this.frmRaporlar_Load);
            this.grpMenuBaslik.ResumeLayout(false);
            this.grpIstatistik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.GroupBox grpMenuBaslik;
        private System.Windows.Forms.Button btnAraSıcak;
        private System.Windows.Forms.Button btnMakarna;
        private System.Windows.Forms.Button btnCorba;
        private System.Windows.Forms.Button btnFastFood;
        private System.Windows.Forms.Button btnSalatalar;
        private System.Windows.Forms.Button btnTatlilar;
        private System.Windows.Forms.Button btnIcecek;
        private System.Windows.Forms.Button btnAnaYemek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.GroupBox grpIstatistik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chRapor;
        private System.Windows.Forms.ListView lvIstatistik;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnZraporu;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}