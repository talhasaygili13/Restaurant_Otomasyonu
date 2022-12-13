namespace rest
{
    partial class billfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(billfrm));
            this.lblAdisyonId = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbTicket = new System.Windows.Forms.RadioButton();
            this.rbKredKarti = new System.Windows.Forms.RadioButton();
            this.rbNakit = new System.Windows.Forms.RadioButton();
            this.gbIndirimTutar = new System.Windows.Forms.GroupBox();
            this.txtIndirimTutari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.lblOdenecek = new System.Windows.Forms.Label();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.lblKdv = new System.Windows.Forms.Label();
            this.lblIndirim = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbIndirim = new System.Windows.Forms.GroupBox();
            this.chkIndirim = new System.Windows.Forms.CheckBox();
            this.lvUrunler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hesapKapat = new System.Windows.Forms.Button();
            this.hesapOzet = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4.SuspendLayout();
            this.gbIndirimTutar.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.gbIndirim.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdisyonId
            // 
            this.lblAdisyonId.AutoSize = true;
            this.lblAdisyonId.BackColor = System.Drawing.Color.Transparent;
            this.lblAdisyonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdisyonId.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAdisyonId.Location = new System.Drawing.Point(358, 74);
            this.lblAdisyonId.Name = "lblAdisyonId";
            this.lblAdisyonId.Size = new System.Drawing.Size(27, 24);
            this.lblAdisyonId.TabIndex = 15;
            this.lblAdisyonId.Text = "Id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(224, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 25);
            this.label10.TabIndex = 14;
            this.label10.Text = "Siparişler";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.rbTicket);
            this.groupBox4.Controls.Add(this.rbKredKarti);
            this.groupBox4.Controls.Add(this.rbNakit);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(561, 464);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 200);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ödeme Türü";
            // 
            // rbTicket
            // 
            this.rbTicket.AutoSize = true;
            this.rbTicket.Location = new System.Drawing.Point(29, 137);
            this.rbTicket.Name = "rbTicket";
            this.rbTicket.Size = new System.Drawing.Size(84, 28);
            this.rbTicket.TabIndex = 2;
            this.rbTicket.TabStop = true;
            this.rbTicket.Text = "Ticket";
            this.rbTicket.UseVisualStyleBackColor = true;
            // 
            // rbKredKarti
            // 
            this.rbKredKarti.AutoSize = true;
            this.rbKredKarti.Location = new System.Drawing.Point(29, 91);
            this.rbKredKarti.Name = "rbKredKarti";
            this.rbKredKarti.Size = new System.Drawing.Size(124, 28);
            this.rbKredKarti.TabIndex = 1;
            this.rbKredKarti.TabStop = true;
            this.rbKredKarti.Text = "Kredi Kartı";
            this.rbKredKarti.UseVisualStyleBackColor = true;
            // 
            // rbNakit
            // 
            this.rbNakit.AutoSize = true;
            this.rbNakit.Location = new System.Drawing.Point(29, 39);
            this.rbNakit.Name = "rbNakit";
            this.rbNakit.Size = new System.Drawing.Size(74, 28);
            this.rbNakit.TabIndex = 0;
            this.rbNakit.TabStop = true;
            this.rbNakit.Text = "Nakit";
            this.rbNakit.UseVisualStyleBackColor = true;
            // 
            // gbIndirimTutar
            // 
            this.gbIndirimTutar.BackColor = System.Drawing.Color.Transparent;
            this.gbIndirimTutar.Controls.Add(this.txtIndirimTutari);
            this.gbIndirimTutar.Controls.Add(this.label1);
            this.gbIndirimTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbIndirimTutar.ForeColor = System.Drawing.Color.White;
            this.gbIndirimTutar.Location = new System.Drawing.Point(1129, 89);
            this.gbIndirimTutar.Name = "gbIndirimTutar";
            this.gbIndirimTutar.Size = new System.Drawing.Size(225, 130);
            this.gbIndirimTutar.TabIndex = 8;
            this.gbIndirimTutar.TabStop = false;
            this.gbIndirimTutar.Text = "Özel Aktivite";
            this.gbIndirimTutar.Visible = false;
            // 
            // txtIndirimTutari
            // 
            this.txtIndirimTutari.Location = new System.Drawing.Point(10, 81);
            this.txtIndirimTutari.Name = "txtIndirimTutari";
            this.txtIndirimTutari.Size = new System.Drawing.Size(209, 29);
            this.txtIndirimTutari.TabIndex = 1;
            this.txtIndirimTutari.TextChanged += new System.EventHandler(this.txtIndirimTutari_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "İndirim tutarı giriniz";
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox3.Controls.Add(this.lblOdenecek);
            this.GroupBox3.Controls.Add(this.lblToplamTutar);
            this.GroupBox3.Controls.Add(this.lblKdv);
            this.GroupBox3.Controls.Add(this.lblIndirim);
            this.GroupBox3.Controls.Add(this.label9);
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.label6);
            this.GroupBox3.Controls.Add(this.label5);
            this.GroupBox3.Controls.Add(this.label4);
            this.GroupBox3.Controls.Add(this.label3);
            this.GroupBox3.Controls.Add(this.label2);
            this.GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GroupBox3.ForeColor = System.Drawing.Color.White;
            this.GroupBox3.Location = new System.Drawing.Point(229, 464);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(303, 200);
            this.GroupBox3.TabIndex = 9;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Ödeme Bilgileri";
            // 
            // lblOdenecek
            // 
            this.lblOdenecek.AutoSize = true;
            this.lblOdenecek.Location = new System.Drawing.Point(176, 163);
            this.lblOdenecek.Name = "lblOdenecek";
            this.lblOdenecek.Size = new System.Drawing.Size(21, 24);
            this.lblOdenecek.TabIndex = 11;
            this.lblOdenecek.Text = "0";
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(176, 121);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(21, 24);
            this.lblToplamTutar.TabIndex = 10;
            this.lblToplamTutar.Text = "0";
            // 
            // lblKdv
            // 
            this.lblKdv.AutoSize = true;
            this.lblKdv.Location = new System.Drawing.Point(176, 81);
            this.lblKdv.Name = "lblKdv";
            this.lblKdv.Size = new System.Drawing.Size(21, 24);
            this.lblKdv.TabIndex = 9;
            this.lblKdv.Text = "0";
            // 
            // lblIndirim
            // 
            this.lblIndirim.AutoSize = true;
            this.lblIndirim.Location = new System.Drawing.Point(176, 39);
            this.lblIndirim.Name = "lblIndirim";
            this.lblIndirim.Size = new System.Drawing.Size(21, 24);
            this.lblIndirim.TabIndex = 8;
            this.lblIndirim.Text = "0";
            this.lblIndirim.TextChanged += new System.EventHandler(this.lblIndirim_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "TL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 24);
            this.label8.TabIndex = 6;
            this.label8.Text = "TL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "TL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "TL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ara Toplam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "KDV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "İndirim";
            // 
            // gbIndirim
            // 
            this.gbIndirim.BackColor = System.Drawing.Color.Transparent;
            this.gbIndirim.Controls.Add(this.chkIndirim);
            this.gbIndirim.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbIndirim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbIndirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbIndirim.ForeColor = System.Drawing.Color.White;
            this.gbIndirim.Location = new System.Drawing.Point(919, 111);
            this.gbIndirim.Name = "gbIndirim";
            this.gbIndirim.Size = new System.Drawing.Size(187, 88);
            this.gbIndirim.TabIndex = 11;
            this.gbIndirim.TabStop = false;
            this.gbIndirim.Text = "Özel İndirim";
            // 
            // chkIndirim
            // 
            this.chkIndirim.AutoSize = true;
            this.chkIndirim.Location = new System.Drawing.Point(6, 44);
            this.chkIndirim.Name = "chkIndirim";
            this.chkIndirim.Size = new System.Drawing.Size(162, 28);
            this.chkIndirim.TabIndex = 0;
            this.chkIndirim.Text = "İndirim Uygula";
            this.chkIndirim.UseVisualStyleBackColor = true;
            this.chkIndirim.CheckedChanged += new System.EventHandler(this.chkIndirim_CheckedChanged);
            // 
            // lvUrunler
            // 
            this.lvUrunler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvUrunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvUrunler.FullRowSelect = true;
            this.lvUrunler.GridLines = true;
            this.lvUrunler.HideSelection = false;
            this.lvUrunler.Location = new System.Drawing.Point(229, 102);
            this.lvUrunler.Name = "lvUrunler";
            this.lvUrunler.Size = new System.Drawing.Size(611, 300);
            this.lvUrunler.TabIndex = 10;
            this.lvUrunler.UseCompatibleStateImageBehavior = false;
            this.lvUrunler.View = System.Windows.Forms.View.Details;
            this.lvUrunler.SelectedIndexChanged += new System.EventHandler(this.lvUrunler_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Adı";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adet";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ürün No";
            this.columnHeader3.Width = 124;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fiyat";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SatisId";
            this.columnHeader5.Width = 0;
            // 
            // hesapKapat
            // 
            this.hesapKapat.BackgroundImage = global::rest.Properties.Resources.hesapKapatma;
            this.hesapKapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hesapKapat.Location = new System.Drawing.Point(982, 470);
            this.hesapKapat.Name = "hesapKapat";
            this.hesapKapat.Size = new System.Drawing.Size(171, 159);
            this.hesapKapat.TabIndex = 17;
            this.hesapKapat.UseVisualStyleBackColor = true;
            this.hesapKapat.Click += new System.EventHandler(this.hesapKapatma);
            this.hesapKapat.MouseHover += new System.EventHandler(this.hesapKapat_MouseHover);
            // 
            // hesapOzet
            // 
            this.hesapOzet.BackgroundImage = global::rest.Properties.Resources.hesapOzet;
            this.hesapOzet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hesapOzet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hesapOzet.Location = new System.Drawing.Point(982, 282);
            this.hesapOzet.Name = "hesapOzet";
            this.hesapOzet.Size = new System.Drawing.Size(171, 156);
            this.hesapOzet.TabIndex = 16;
            this.hesapOzet.UseVisualStyleBackColor = true;
            this.hesapOzet.Click += new System.EventHandler(this.hesapOzet_Click);
            this.hesapOzet.MouseHover += new System.EventHandler(this.hesapOzet_MouseHover);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackgroundImage = global::rest.Properties.Resources.geriDon;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriDon.Location = new System.Drawing.Point(40, 669);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(68, 63);
            this.btnGeriDon.TabIndex = 13;
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // billfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::rest.Properties.Resources.arkaplan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1510, 750);
            this.Controls.Add(this.hesapKapat);
            this.Controls.Add(this.hesapOzet);
            this.Controls.Add(this.lblAdisyonId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbIndirimTutar);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.gbIndirim);
            this.Controls.Add(this.lvUrunler);
            this.Name = "billfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Hesap Ödeme";
            this.Load += new System.EventHandler(this.billfrm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbIndirimTutar.ResumeLayout(false);
            this.gbIndirimTutar.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.gbIndirim.ResumeLayout(false);
            this.gbIndirim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hesapKapat;
        private System.Windows.Forms.Button hesapOzet;
        private System.Windows.Forms.Label lblAdisyonId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbTicket;
        private System.Windows.Forms.RadioButton rbKredKarti;
        private System.Windows.Forms.RadioButton rbNakit;
        private System.Windows.Forms.GroupBox gbIndirimTutar;
        private System.Windows.Forms.TextBox txtIndirimTutari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label lblOdenecek;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Label lblKdv;
        private System.Windows.Forms.Label lblIndirim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbIndirim;
        private System.Windows.Forms.CheckBox chkIndirim;
        private System.Windows.Forms.ListView lvUrunler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}