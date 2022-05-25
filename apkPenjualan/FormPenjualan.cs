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

namespace apkPenjualan
{ 
    public partial class FormPenjualan : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;

        Koneksi koneksi = new Koneksi();
        public FormPenjualan()
        {
            InitializeComponent();
        }

        void KodeTransaksi()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            long hitung;
            string urutan;
            cmd = new SqlCommand("select NoNota from tbl_penjualan where NoNota in(select max(NoNota) from tbl_penjualan) order by NoNota desc", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr["NoNota"]) + 1;
                string kodeurutan = "0000" + hitung;
                urutan = DateTime.Now.ToString("ddMMyyyy") + kodeurutan.Substring(kodeurutan.Length - 4, 4);
            
            }
            else
            {
                urutan = DateTime.Now.ToString("ddMMyyyy") + "0001";
            
            }
            dr.Close();
            txtKodeTransaksi.Text = urutan;
            conn.Close();
        }

        void Cleartext()
        {
            txtKodeBrg.Clear();
            txtNamaBrg.Clear();
            txtMerkBrg.Clear();
            txtSatuanBrg.Clear();
            txtHargaBrg.Clear();
            txtJumlahBrg.Clear();
            txtTotalBrg.Clear();
            
        }

        void ClearPlg()
        {
            txtKodePlg.Clear();
            txtNamaPlg.Clear();
            txtPhonePlg.Clear();
            txtAlamatPlg.Clear();
        }

        void TotalAll()
        {
            int jumlah = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                jumlah += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                txtTotalAll.Text = jumlah.ToString();
            }
            if (txtTotalAll.Text == "")
            {
                txtTotalAll.Text = "0";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPelanggan Fg = new FormPelanggan();
            Fg.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTanggalNow.Text = DateTime.Now.ToLongDateString();
        }

        private void FormPenjualan_Load(object sender, EventArgs e)
        {
            KodeTransaksi();
            txtKodePlg.Focus();
        }

        private void txtKodeBrg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_barang where KodeBrg = '" + txtKodeBrg.Text + "'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if(DateTime.Now < (DateTime)dr["TglExp"] && dr["JumlahBrg"].ToString() != "0")
                    {
                        txtNamaBrg.Text = (string)dr["NamaBrg"];
                        txtMerkBrg.Text = (string)dr["MerkBrg"];
                        txtSatuanBrg.Text = (string)dr["SatuanBrg"];
                        txtHargaBrg.Text = (string)dr["HargaBrg"];
                        txtJumlahBrg.Focus();
                    }
                    else if(DateTime.Now >= (DateTime)dr["TglExp"] && dr["JumlahBrg"].ToString() != "0")
                    {
                        MessageBox.Show("Barang Sudah Expired");
                        txtKodeBrg.Focus();
                    }
                    else if(dr["JumlahBrg"].ToString() == "0" && DateTime.Now < (DateTime)dr["TglExp"])
                    {
                        MessageBox.Show("Barang Sudah Habis");
                        txtKodeBrg.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Barang Sudah Habis dan Expired");
                        txtKodeBrg.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                }
            }
        }

        private void txtJumlahBrg_TextChanged(object sender, EventArgs e)
        {
            double hasil;
            try
            {
                hasil = Convert.ToDouble(txtHargaBrg.Text) * Convert.ToDouble(txtJumlahBrg.Text);
                txtTotalBrg.Text = hasil.ToString();

            }
            catch
            {
                txtTotalBrg.Text = "";
            }
        }

        private void txtJumlahBrg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

            if (e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_barang where KodeBrg = '"+txtKodeBrg.Text+"'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if(Convert.ToInt32(txtJumlahBrg.Text) <= Convert.ToInt32(dr["JumlaHBrg"]))
                    {
                        dataGridView1.Rows.Add(txtKodeBrg.Text, txtNamaBrg.Text, txtMerkBrg.Text, txtSatuanBrg.Text, txtHargaBrg.Text, txtJumlahBrg.Text, txtTotalBrg.Text);
                        Cleartext();
                        TotalAll();
                        dataGridView1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Persediaan Barang Hanya '" + dr["JumlahBrg"].ToString() + "'") ;
                    }
                }
                
            }
            else
            {
                txtJumlahBrg.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Yakin Menghapus Data Ini?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                TotalAll();
            }
            else
            {
                TotalAll();
            }
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double kembalian;
                kembalian = Convert.ToDouble(txtBayar.Text) - Convert.ToDouble(txtTotalAll.Text);
                txtKembalian.Text = kembalian.ToString();
            }
            catch
            {
                txtKembalian.Text = "0";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cleartext();
            ClearPlg();
            txtTotalAll.Clear();
            txtBayar.Clear();
            txtKembalian.Clear();
            dataGridView1.Rows.Clear();
        }
        void PenguranganStok()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cmd = new SqlCommand("Update tbl_barang set JumlahBrg = JumlahBrg - '" + dataGridView1.Rows[i].Cells[5].Value + "' where KodeBrg = '" + dataGridView1.Rows[i].Cells[0].Value + "'", conn);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtTotalAll.Text == "")
            {
                MessageBox.Show("Belum Ada Barang Yang Diinputkan");
            }
            else if(Convert.ToInt32(txtBayar.Text) < Convert.ToInt32(txtTotalAll.Text))
            {
                MessageBox.Show("Pembayaran Kurang");
            }
            else
            {
                SqlConnection conn = koneksi.GetConn();
                if(MessageBox.Show("Yakin ingin simpan dan cetak nota?","Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                {
                    conn.Open();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("insert into tbl_penjualan (NoNota, TglNota, Kode_Pelanggan, Kode_Barang, HargaBrg, Jumlah) values ('" + txtKodeTransaksi.Text + "','" + txtTanggalNow.Text + "', '" + txtKodePlg.Text + "', '" + dataGridView1.Rows[i].Cells[0].Value + "', '" + dataGridView1.Rows[i].Cells[4].Value + "', '" + dataGridView1.Rows[i].Cells[5].Value + "' )", conn);
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    DVPrintPreviewDialog.Document = DVPrintDocument;
                    DVPrintPreviewDialog.ShowDialog();
                    Cleartext();
                    ClearPlg();
                    txtTotalAll.Clear();
                    txtBayar.Clear();
                    txtKembalian.Clear();
                    dataGridView1.Rows.Clear();
                }
                else
                {

                }
                
            }
        }

        private void txtKodePlg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_pelanggan where KodePlg = '" + txtKodePlg.Text + "'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtNamaPlg.Text = (string)dr["NamaPlg"];
                    txtPhonePlg.Text = (string)dr["PhonePlg"];
                    txtAlamatPlg.Text = (string)dr["AlamatPlg"];
                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                }

            }
        }

        private void txtTotalBrg_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalAll_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("NOTA PENJUALAN BARANG", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(120, 0));
            e.Graphics.DrawString("Nama Pelanggan : " + txtNamaPlg.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 80));
            e.Graphics.DrawString("Phone Pelanggan : " + txtPhonePlg.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString("Alamat Pelanggan : " + txtAlamatPlg.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            
            e.Graphics.DrawString("No Nota : " + txtKodeTransaksi.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Tanggal : " + txtTanggalNow.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(380, 220));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            e.Graphics.DrawString("Nama Barang", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 270));
            e.Graphics.DrawString("Jumlah", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 270));
            e.Graphics.DrawString("Harga", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 270));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, 270));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 285));

            int yPos = 310;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[1].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[5].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[4].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[6].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, yPos));

                yPos += 25;
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, yPos));

            e.Graphics.DrawString("Total : Rp.  " + txtTotalAll.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 30));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, yPos + 40));
            e.Graphics.DrawString("Pembayaran : Rp.  " + txtBayar.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos + 90));
            e.Graphics.DrawString("Kembalian : Rp.  " + txtKembalian.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos + 120));

        }

        private void txtKodeTransaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
