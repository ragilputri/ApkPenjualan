namespace apkPenjualan
{
    partial class FormPenjualan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPenjualan));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtKodePlg = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAlamatPlg = new System.Windows.Forms.TextBox();
            this.txtPhonePlg = new System.Windows.Forms.TextBox();
            this.txtNamaPlg = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtKodeBrg = new System.Windows.Forms.TextBox();
            this.txtNamaBrg = new System.Windows.Forms.TextBox();
            this.txtMerkBrg = new System.Windows.Forms.TextBox();
            this.txtSatuanBrg = new System.Windows.Forms.TextBox();
            this.txtHargaBrg = new System.Windows.Forms.TextBox();
            this.txtJumlahBrg = new System.Windows.Forms.TextBox();
            this.txtTotalBrg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalAll = new System.Windows.Forms.TextBox();
            this.Pembayaran = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtKembalian = new System.Windows.Forms.TextBox();
            this.txtBayar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTanggalNow = new System.Windows.Forms.TextBox();
            this.txtKodeTransaksi = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DVPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.DVPrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Pembayaran.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "FORM TRANSAKSI PENJUALAN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.txtKodePlg);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtAlamatPlg);
            this.groupBox1.Controls.Add(this.txtPhonePlg);
            this.groupBox1.Controls.Add(this.txtNamaPlg);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form Pelanggan";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(21, 128);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(160, 20);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Don\'t Have Account?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtKodePlg
            // 
            this.txtKodePlg.Location = new System.Drawing.Point(20, 79);
            this.txtKodePlg.Name = "txtKodePlg";
            this.txtKodePlg.Size = new System.Drawing.Size(257, 26);
            this.txtKodePlg.TabIndex = 28;
            this.txtKodePlg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKodePlg_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 20);
            this.label16.TabIndex = 27;
            this.label16.Text = "Kode Pelanggan";
            // 
            // txtAlamatPlg
            // 
            this.txtAlamatPlg.Location = new System.Drawing.Point(757, 41);
            this.txtAlamatPlg.Name = "txtAlamatPlg";
            this.txtAlamatPlg.Size = new System.Drawing.Size(257, 26);
            this.txtAlamatPlg.TabIndex = 24;
            // 
            // txtPhonePlg
            // 
            this.txtPhonePlg.Location = new System.Drawing.Point(396, 97);
            this.txtPhonePlg.Name = "txtPhonePlg";
            this.txtPhonePlg.Size = new System.Drawing.Size(257, 26);
            this.txtPhonePlg.TabIndex = 23;
            // 
            // txtNamaPlg
            // 
            this.txtNamaPlg.Location = new System.Drawing.Point(396, 41);
            this.txtNamaPlg.Name = "txtNamaPlg";
            this.txtNamaPlg.Size = new System.Drawing.Size(257, 26);
            this.txtNamaPlg.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(685, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "Alamat";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(301, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "Phone";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Nama";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(456, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(580, 207);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Kode";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nama";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Merk";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Satuan";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Harga";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Jumlah";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Total";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Action";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.Text = "Delete";
            this.Column8.ToolTipText = "Delete";
            this.Column8.UseColumnTextForButtonValue = true;
            this.Column8.Width = 150;
            // 
            // txtKodeBrg
            // 
            this.txtKodeBrg.Location = new System.Drawing.Point(161, 330);
            this.txtKodeBrg.Name = "txtKodeBrg";
            this.txtKodeBrg.Size = new System.Drawing.Size(257, 26);
            this.txtKodeBrg.TabIndex = 3;
            this.txtKodeBrg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKodeBrg_KeyPress);
            // 
            // txtNamaBrg
            // 
            this.txtNamaBrg.Location = new System.Drawing.Point(161, 384);
            this.txtNamaBrg.Name = "txtNamaBrg";
            this.txtNamaBrg.Size = new System.Drawing.Size(257, 26);
            this.txtNamaBrg.TabIndex = 4;
            // 
            // txtMerkBrg
            // 
            this.txtMerkBrg.Location = new System.Drawing.Point(161, 435);
            this.txtMerkBrg.Name = "txtMerkBrg";
            this.txtMerkBrg.Size = new System.Drawing.Size(257, 26);
            this.txtMerkBrg.TabIndex = 5;
            // 
            // txtSatuanBrg
            // 
            this.txtSatuanBrg.Location = new System.Drawing.Point(161, 488);
            this.txtSatuanBrg.Name = "txtSatuanBrg";
            this.txtSatuanBrg.Size = new System.Drawing.Size(257, 26);
            this.txtSatuanBrg.TabIndex = 6;
            // 
            // txtHargaBrg
            // 
            this.txtHargaBrg.Location = new System.Drawing.Point(161, 547);
            this.txtHargaBrg.Name = "txtHargaBrg";
            this.txtHargaBrg.Size = new System.Drawing.Size(257, 26);
            this.txtHargaBrg.TabIndex = 7;
            // 
            // txtJumlahBrg
            // 
            this.txtJumlahBrg.Location = new System.Drawing.Point(161, 601);
            this.txtJumlahBrg.Name = "txtJumlahBrg";
            this.txtJumlahBrg.Size = new System.Drawing.Size(257, 26);
            this.txtJumlahBrg.TabIndex = 8;
            this.txtJumlahBrg.TextChanged += new System.EventHandler(this.txtJumlahBrg_TextChanged);
            this.txtJumlahBrg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJumlahBrg_KeyPress);
            // 
            // txtTotalBrg
            // 
            this.txtTotalBrg.Location = new System.Drawing.Point(161, 657);
            this.txtTotalBrg.Name = "txtTotalBrg";
            this.txtTotalBrg.Size = new System.Drawing.Size(257, 26);
            this.txtTotalBrg.TabIndex = 9;
            this.txtTotalBrg.TextChanged += new System.EventHandler(this.txtTotalBrg_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Merk";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Satuan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 550);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Harga";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 604);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Jumlah";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 660);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(517, 479);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 26);
            this.label9.TabIndex = 17;
            this.label9.Text = "Total";
            // 
            // txtTotalAll
            // 
            this.txtTotalAll.Location = new System.Drawing.Point(776, 478);
            this.txtTotalAll.Name = "txtTotalAll";
            this.txtTotalAll.Size = new System.Drawing.Size(260, 26);
            this.txtTotalAll.TabIndex = 18;
            this.txtTotalAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAll.TextChanged += new System.EventHandler(this.txtTotalAll_TextChanged);
            // 
            // Pembayaran
            // 
            this.Pembayaran.Controls.Add(this.btnCancel);
            this.Pembayaran.Controls.Add(this.btnSave);
            this.Pembayaran.Controls.Add(this.txtKembalian);
            this.Pembayaran.Controls.Add(this.txtBayar);
            this.Pembayaran.Controls.Add(this.label11);
            this.Pembayaran.Controls.Add(this.label10);
            this.Pembayaran.Location = new System.Drawing.Point(471, 526);
            this.Pembayaran.Name = "Pembayaran";
            this.Pembayaran.Size = new System.Drawing.Size(565, 210);
            this.Pembayaran.TabIndex = 19;
            this.Pembayaran.TabStop = false;
            this.Pembayaran.Text = "Pembayaran";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(462, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 41);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(305, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 41);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtKembalian
            // 
            this.txtKembalian.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKembalian.Location = new System.Drawing.Point(305, 92);
            this.txtKembalian.Name = "txtKembalian";
            this.txtKembalian.Size = new System.Drawing.Size(245, 30);
            this.txtKembalian.TabIndex = 22;
            this.txtKembalian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBayar
            // 
            this.txtBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayar.Location = new System.Drawing.Point(25, 92);
            this.txtBayar.Name = "txtBayar";
            this.txtBayar.Size = new System.Drawing.Size(245, 30);
            this.txtBayar.TabIndex = 20;
            this.txtBayar.Text = "0";
            this.txtBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBayar.TextChanged += new System.EventHandler(this.txtBayar_TextChanged);
            this.txtBayar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBayar_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Kembalian";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Bayar";
            // 
            // txtTanggalNow
            // 
            this.txtTanggalNow.Enabled = false;
            this.txtTanggalNow.Location = new System.Drawing.Point(218, 259);
            this.txtTanggalNow.Name = "txtTanggalNow";
            this.txtTanggalNow.Size = new System.Drawing.Size(200, 26);
            this.txtTanggalNow.TabIndex = 22;
            // 
            // txtKodeTransaksi
            // 
            this.txtKodeTransaksi.Enabled = false;
            this.txtKodeTransaksi.Location = new System.Drawing.Point(24, 259);
            this.txtKodeTransaksi.Name = "txtKodeTransaksi";
            this.txtKodeTransaksi.Size = new System.Drawing.Size(173, 26);
            this.txtKodeTransaksi.TabIndex = 23;
            this.txtKodeTransaksi.TextChanged += new System.EventHandler(this.txtKodeTransaksi_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DVPrintDocument
            // 
            this.DVPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.DVPrintDocument_PrintPage);
            // 
            // DVPrintPreviewDialog
            // 
            this.DVPrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DVPrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DVPrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.DVPrintPreviewDialog.Enabled = true;
            this.DVPrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("DVPrintPreviewDialog.Icon")));
            this.DVPrintPreviewDialog.Name = "DVPrintPreviewDialog";
            this.DVPrintPreviewDialog.Visible = false;
            // 
            // FormPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 754);
            this.Controls.Add(this.txtKodeTransaksi);
            this.Controls.Add(this.txtTanggalNow);
            this.Controls.Add(this.Pembayaran);
            this.Controls.Add(this.txtTotalAll);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalBrg);
            this.Controls.Add(this.txtJumlahBrg);
            this.Controls.Add(this.txtHargaBrg);
            this.Controls.Add(this.txtSatuanBrg);
            this.Controls.Add(this.txtMerkBrg);
            this.Controls.Add(this.txtNamaBrg);
            this.Controls.Add(this.txtKodeBrg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormPenjualan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTransaksi";
            this.Load += new System.EventHandler(this.FormPenjualan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Pembayaran.ResumeLayout(false);
            this.Pembayaran.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtKodePlg;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAlamatPlg;
        private System.Windows.Forms.TextBox txtPhonePlg;
        private System.Windows.Forms.TextBox txtNamaPlg;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtKodeBrg;
        private System.Windows.Forms.TextBox txtNamaBrg;
        private System.Windows.Forms.TextBox txtMerkBrg;
        private System.Windows.Forms.TextBox txtSatuanBrg;
        private System.Windows.Forms.TextBox txtHargaBrg;
        private System.Windows.Forms.TextBox txtJumlahBrg;
        private System.Windows.Forms.TextBox txtTotalBrg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalAll;
        private System.Windows.Forms.GroupBox Pembayaran;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtKembalian;
        private System.Windows.Forms.TextBox txtBayar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTanggalNow;
        private System.Windows.Forms.TextBox txtKodeTransaksi;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Drawing.Printing.PrintDocument DVPrintDocument;
        private System.Windows.Forms.PrintPreviewDialog DVPrintPreviewDialog;
    }
}