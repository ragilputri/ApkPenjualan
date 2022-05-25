using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace apkPenjualan
{
    public partial class FormPembelian : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;

        Koneksi koneksi = new Koneksi();
        public FormPembelian()
        {
            InitializeComponent();
        }

        void NoFaktur()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            long hitung;
            string urutan;
            cmd = new SqlCommand("select NoFaktur from tbl_pembelian where NoFaktur in(select max(NoFaktur) from tbl_pembelian) order by NoFaktur desc", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr["NoFaktur"]) + 1;
                string kodeurutan = "0000" + hitung;
                urutan = DateTime.Now.ToString("ddMMyyyy") + kodeurutan.Substring(kodeurutan.Length - 4, 4);

            }
            else
            {
                urutan = DateTime.Now.ToString("ddMMyyyy") + "0001";

            }
            dr.Close();
            txtNoFaktur.Text = urutan;
            conn.Close();

        }

        void TotalAll()
        {
            decimal rupiah;
            int jumlah = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                jumlah += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                txtTotalAll.Text = jumlah.ToString();


                //rupiah = decimal.Parse(jumlah.ToString());
                //txtTotalAll.Text = rupiah.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
            }
            if (txtTotalAll.Text == "")
            {
                txtTotalAll.Text = "0";
            }
        }

        void ClearText()
        {
            txtKodeBrg.Clear();
            txtNamaBrg.Clear();
            txtMerkBrg.Clear();
            txtSatuanBrg.Clear();
            txtHargaBrg.Clear();
            txtHargaBeli.Clear();
            txtJumlahBeli.Clear();
            txtTotalBeli.Clear();
        }
        void ClearSupp()
        {
            txtKodeSup.Clear();
            txtNamaSup.Clear();
            txtPhoneSup.Clear();
            txtAlamatSup.Clear();
            txtDescSup.Clear();
        }
        private void txtKodeTransaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormPembelian_Load(object sender, EventArgs e)
        {
            NoFaktur();
            txtKodeSup.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTanggalNow.Text = DateTime.Now.ToLongDateString();
        }

        private void txtKodeSup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_supplier where KodeSup = '" + txtKodeSup.Text + "'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtNamaSup.Text = (string)dr["NamaSup"];
                    txtPhoneSup.Text = (string)dr["PhoneSup"];
                    txtAlamatSup.Text = (string)dr["AlamatSup"];
                    txtDescSup.Text = (string)dr["DescSup"];
                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                    txtKodeSup.Focus();
                }
            }
        }

        private void txtKodeBrg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_barang where KodeBrg = '"+txtKodeBrg.Text+"'",conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtNamaBrg.Text = (string)dr["NamaBrg"];
                    txtMerkBrg.Text = (string)dr["MerkBrg"];
                    txtSatuanBrg.Text = (string)dr["SatuanBrg"];
                    txtHargaBrg.Text = (string)dr["HargaBrg"];
                    txtHargaBeli.Focus();
                }
                else
                {
                    MessageBox.Show("Barang Tidak Ditemukan!");
                }
            }
        }

        private void txtJumlahBeli_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double hasil;
                hasil = Convert.ToDouble(txtHargaBeli.Text) * Convert.ToDouble(txtJumlahBeli.Text);
                txtTotalBeli.Text = hasil.ToString();
            }
            catch
            {
                txtTotalBeli.Text = "0";
            }
        }

        private void txtJumlahBeli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

            if (e.KeyChar == (char)13)
            {
                dataGridView1.Rows.Add(txtKodeBrg.Text, txtNamaBrg.Text, txtMerkBrg.Text, txtSatuanBrg.Text, txtHargaBeli.Text, txtJumlahBeli.Text, txtTotalBeli.Text);
                TotalAll();
                ClearText();
                dataGridView1.Focus();

            }
            else
            {
                txtJumlahBeli.Focus();
            }
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double hasil;
                hasil = Convert.ToDouble(txtBayar.Text) - Convert.ToDouble(txtTotalAll.Text);
                txtKembalian.Text = hasil.ToString();
            }
            catch
            {
                txtKembalian.Text = "0";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Yakin Menghapus Data ini?", "Question",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                TotalAll();
            }
            else
            {
                TotalAll();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTotalAll.Text == "")
            {
                MessageBox.Show("Belum Menginputkan Data");
            }
            else if (Convert.ToInt32(txtBayar.Text) < Convert.ToInt32(txtTotalAll.Text))
            {
                MessageBox.Show("Pembayaran Kurang");
            }
            else
            {
                SqlConnection conn = koneksi.GetConn();

                if(MessageBox.Show("Yakin ingin simpan dan cetak nota?","Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into tbl_pembelian (NoFaktur, TglFaktur, Kode_SUpplier, Kode_Barang, JumlahBeli, HargaBeli) values ('" + txtNoFaktur.Text + "', '" + txtTanggalNow.Text + "', '" + txtKodeSup.Text + "', '" + dataGridView1.Rows[i].Cells[0].Value + "', '" + dataGridView1.Rows[i].Cells[5].Value + "', '" + dataGridView1.Rows[i].Cells[4].Value + "')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    DVPrintPreviewDialog.Document = DVPrintDocument;
                    DVPrintPreviewDialog.ShowDialog();
                    ClearText();
                    ClearSupp();
                    dataGridView1.Rows.Clear();
                    txtTotalAll.Clear();
                    txtBayar.Clear();
                    txtKembalian.Clear();
                }
                else
                {

                }
                
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Yakin Membatalkan Proses?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ClearText();
                ClearSupp();
                dataGridView1.Rows.Clear();
                txtTotalAll.Clear();
                txtBayar.Clear();
                txtKembalian.Clear();
            }
            else
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("NOTA PEMBELIAN BARANG", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(120, 0));
            e.Graphics.DrawString("Nama Supplier : " +txtNamaSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 80));
            e.Graphics.DrawString("Jenis Supplier : " + txtDescSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString("Phone Supplier : " + txtPhoneSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString("Alamat Supplier : " + txtAlamatSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 170));

            e.Graphics.DrawString("No Faktur : " + txtNoFaktur.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Tanggal : " + txtTanggalNow.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(380, 220));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            e.Graphics.DrawString("Nama Barang", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 270));
            e.Graphics.DrawString("Jumlah", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 270));
            e.Graphics.DrawString("Harga Beli", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 270));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, 270));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 285));

            int yPos = 310;
            for (int i = 0; i < dataGridView1.Rows.Count; i++){
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[1].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos)) ;
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[5].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[4].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[6].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, yPos));

                yPos += 25;
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, yPos));
           
            e.Graphics.DrawString("Total : Rp.  "+ txtTotalAll.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 30));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, yPos + 40));
            e.Graphics.DrawString("Pembayaran : Rp.  " + txtBayar.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos + 90));
            e.Graphics.DrawString("Kembalian : Rp.  " + txtKembalian.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos + 120));

        }

        private void txtTotalAll_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
