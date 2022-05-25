namespace apkPenjualan
{
    partial class FormBarang
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtMerk = new System.Windows.Forms.TextBox();
            this.txtSatuan = new System.Windows.Forms.TextBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.dateTimeExp = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ErrorKode = new System.Windows.Forms.Label();
            this.ErrorNama = new System.Windows.Forms.Label();
            this.ErrorMerk = new System.Windows.Forms.Label();
            this.ErrorSatuan = new System.Windows.Forms.Label();
            this.ErrorJumlah = new System.Windows.Forms.Label();
            this.ErrorHarga = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "FORM BARANG";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(855, 251);
            this.dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Merk";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 529);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Satuan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Jumlah";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Harga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Tanggal Exp";
            // 
            // txtKode
            // 
            this.txtKode.Enabled = false;
            this.txtKode.Location = new System.Drawing.Point(130, 379);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(257, 26);
            this.txtKode.TabIndex = 9;
            this.txtKode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKode_KeyPress);
            // 
            // txtNama
            // 
            this.txtNama.Enabled = false;
            this.txtNama.Location = new System.Drawing.Point(130, 425);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(257, 26);
            this.txtNama.TabIndex = 10;
            // 
            // txtMerk
            // 
            this.txtMerk.Enabled = false;
            this.txtMerk.Location = new System.Drawing.Point(130, 478);
            this.txtMerk.Name = "txtMerk";
            this.txtMerk.Size = new System.Drawing.Size(257, 26);
            this.txtMerk.TabIndex = 11;
            // 
            // txtSatuan
            // 
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(130, 529);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.Size = new System.Drawing.Size(257, 26);
            this.txtSatuan.TabIndex = 12;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Enabled = false;
            this.txtJumlah.Location = new System.Drawing.Point(592, 373);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(257, 26);
            this.txtJumlah.TabIndex = 13;
            this.txtJumlah.TextChanged += new System.EventHandler(this.txtJumlah_TextChanged);
            this.txtJumlah.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJumlah_KeyPress);
            // 
            // txtHarga
            // 
            this.txtHarga.Enabled = false;
            this.txtHarga.Location = new System.Drawing.Point(592, 425);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(257, 26);
            this.txtHarga.TabIndex = 14;
            this.txtHarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHarga_KeyPress);
            // 
            // dateTimeExp
            // 
            this.dateTimeExp.Enabled = false;
            this.dateTimeExp.Location = new System.Drawing.Point(592, 477);
            this.dateTimeExp.Name = "dateTimeExp";
            this.dateTimeExp.Size = new System.Drawing.Size(257, 26);
            this.dateTimeExp.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(598, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 34);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(756, 549);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 34);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(456, 621);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(93, 34);
            this.btnInput.TabIndex = 18;
            this.btnInput.Text = "Input";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(598, 621);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 34);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(756, 621);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 34);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ErrorKode
            // 
            this.ErrorKode.AutoSize = true;
            this.ErrorKode.ForeColor = System.Drawing.Color.Red;
            this.ErrorKode.Location = new System.Drawing.Point(394, 384);
            this.ErrorKode.Name = "ErrorKode";
            this.ErrorKode.Size = new System.Drawing.Size(13, 20);
            this.ErrorKode.TabIndex = 21;
            this.ErrorKode.Text = "!";
            this.ErrorKode.Visible = false;
            // 
            // ErrorNama
            // 
            this.ErrorNama.AutoSize = true;
            this.ErrorNama.ForeColor = System.Drawing.Color.Red;
            this.ErrorNama.Location = new System.Drawing.Point(394, 428);
            this.ErrorNama.Name = "ErrorNama";
            this.ErrorNama.Size = new System.Drawing.Size(13, 20);
            this.ErrorNama.TabIndex = 22;
            this.ErrorNama.Text = "!";
            this.ErrorNama.Visible = false;
            // 
            // ErrorMerk
            // 
            this.ErrorMerk.AutoSize = true;
            this.ErrorMerk.ForeColor = System.Drawing.Color.Red;
            this.ErrorMerk.Location = new System.Drawing.Point(394, 482);
            this.ErrorMerk.Name = "ErrorMerk";
            this.ErrorMerk.Size = new System.Drawing.Size(13, 20);
            this.ErrorMerk.TabIndex = 23;
            this.ErrorMerk.Text = "!";
            this.ErrorMerk.Visible = false;
            // 
            // ErrorSatuan
            // 
            this.ErrorSatuan.AutoSize = true;
            this.ErrorSatuan.ForeColor = System.Drawing.Color.Red;
            this.ErrorSatuan.Location = new System.Drawing.Point(394, 532);
            this.ErrorSatuan.Name = "ErrorSatuan";
            this.ErrorSatuan.Size = new System.Drawing.Size(13, 20);
            this.ErrorSatuan.TabIndex = 24;
            this.ErrorSatuan.Text = "!";
            this.ErrorSatuan.Visible = false;
            // 
            // ErrorJumlah
            // 
            this.ErrorJumlah.AutoSize = true;
            this.ErrorJumlah.ForeColor = System.Drawing.Color.Red;
            this.ErrorJumlah.Location = new System.Drawing.Point(855, 376);
            this.ErrorJumlah.Name = "ErrorJumlah";
            this.ErrorJumlah.Size = new System.Drawing.Size(13, 20);
            this.ErrorJumlah.TabIndex = 25;
            this.ErrorJumlah.Text = "!";
            this.ErrorJumlah.Visible = false;
            // 
            // ErrorHarga
            // 
            this.ErrorHarga.AutoSize = true;
            this.ErrorHarga.ForeColor = System.Drawing.Color.Red;
            this.ErrorHarga.Location = new System.Drawing.Point(855, 425);
            this.ErrorHarga.Name = "ErrorHarga";
            this.ErrorHarga.Size = new System.Drawing.Size(13, 20);
            this.ErrorHarga.TabIndex = 26;
            this.ErrorHarga.Text = "!";
            this.ErrorHarga.Visible = false;
            // 
            // FormBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 684);
            this.Controls.Add(this.ErrorHarga);
            this.Controls.Add(this.ErrorJumlah);
            this.Controls.Add(this.ErrorSatuan);
            this.Controls.Add(this.ErrorMerk);
            this.Controls.Add(this.ErrorNama);
            this.Controls.Add(this.ErrorKode);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dateTimeExp);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.txtMerk);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FormBarang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Barang";
            this.Load += new System.EventHandler(this.FormBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtMerk;
        private System.Windows.Forms.TextBox txtSatuan;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.DateTimePicker dateTimeExp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label ErrorKode;
        private System.Windows.Forms.Label ErrorNama;
        private System.Windows.Forms.Label ErrorMerk;
        private System.Windows.Forms.Label ErrorSatuan;
        private System.Windows.Forms.Label ErrorJumlah;
        private System.Windows.Forms.Label ErrorHarga;
    }
}