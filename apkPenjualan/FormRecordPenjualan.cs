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
    public partial class FormRecordPenjualan : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;

        Koneksi koneksi = new Koneksi();
        public FormRecordPenjualan()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_penjualan join tbl_barang on tbl_penjualan.Kode_Barang = tbl_barang.KodeBrg", conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["NoNota"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Kode_Barang"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["NamaBrg"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Jumlah"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["HargaBrg"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value) * Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value);
            }
            conn.Close();

        }

        void TotalAll()
        {
            int jumlah = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                jumlah += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                txtTotalAll.Text = jumlah.ToString();
            }
            if (txtTotalAll.Text == "")
            {
                txtTotalAll.Text = "0";
            }
        }

        void FoundData()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_penjualan join tbl_barang on tbl_penjualan.Kode_Barang = tbl_barang.KodeBrg  where tbl_penjualan.NoNota = '" + txtSearch.Text + "'", conn);
            da = new SqlDataAdapter(cmd);
            DataTable dataTab = new DataTable();
            da.Fill(dataTab);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataRow item in dataTab.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["NoNota"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Kode_Barang"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["NamaBrg"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Jumlah"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["HargaBrg"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value) * Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value);
            }
            conn.Close();
        }

        void DataPlg()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_pelanggan join tbl_penjualan on tbl_pelanggan.KodePlg = tbl_penjualan.Kode_Pelanggan where tbl_penjualan.Kode_Pelanggan = '" + txtKodePlg.Text + "'", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txtNamaPlg.Text = (string)dr["NamaPlg"];
                txtPhonePlg.Text = (string)dr["PhonePlg"];
                txtAlamatPlg.Text = (string)dr["AlamatPlg"];
            }
            conn.Close();
        }
        void DataBrgPlg()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_penjualan join tbl_barang on tbl_penjualan.Kode_Barang = tbl_barang.KodeBrg  where tbl_penjualan.Kode_Pelanggan = '" + txtKodePlg.Text + "'", conn);
            da = new SqlDataAdapter(cmd);
            DataTable dataTab = new DataTable();
            da.Fill(dataTab);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataRow item in dataTab.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["NoNota"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Kode_Barang"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["NamaBrg"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Jumlah"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["HargaBrg"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value) * Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value);
            }
            conn.Close();
        }
        void ClearText()
        {
            txtKodePlg.Clear();
            txtNamaPlg.Clear();
            txtPhonePlg.Clear();
            txtAlamatPlg.Clear();
            Ltanggal.Text = "";
        }

        private void FormRecordPenjualan_Load(object sender, EventArgs e)
        {
            ShowData();
            TotalAll();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("NOTA PENJUALAN BARANG", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(120, 0));
            e.Graphics.DrawString("Nama Pelanggan : " + txtNamaPlg.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 80));
            e.Graphics.DrawString("Phone Pelanggan : " + txtPhonePlg.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString("Alamat Pelanggan : " + txtAlamatPlg.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 140));

            e.Graphics.DrawString("No Nota : " + txtSearch.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Tanggal : " + Ltanggal.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(380, 220));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            e.Graphics.DrawString("Nama Barang", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 270));
            e.Graphics.DrawString("Jumlah", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 270));
            e.Graphics.DrawString("Harga", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 270));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, 270));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 285));

            int yPos = 310;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[2].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[3].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[4].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, yPos));
                e.Graphics.DrawString((string)dataGridView1.Rows[i].Cells[5].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, yPos));

                yPos += 25;
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, yPos));

            e.Graphics.DrawString("Total : Rp.  " + txtTotalAll.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 30));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, yPos + 40));

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

            if (e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_penjualan where NoNota = '" + txtSearch.Text + "'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtKodePlg.Text = (string)dr["Kode_Pelanggan"];
                    Ltanggal.Text = (string)dr["TglNota"];
                    dataGridView1.Rows.Clear();
                    FoundData();
                    TotalAll();

                    if (string.IsNullOrEmpty(txtKodePlg.Text))
                    {
                        txtNamaPlg.Clear();
                        txtPhonePlg.Clear();
                        txtAlamatPlg.Clear();
                        txtKodePlg.Text = "Tidak Ada data Pelanggan";
                    }
                    else
                    {
                        txtNamaPlg.Clear();
                        txtPhonePlg.Clear();
                        txtAlamatPlg.Clear();
                        DataPlg();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                    dataGridView1.Rows.Clear();
                    ShowData();
                    ClearText();
                    TotalAll();
                }
                
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }

        private void txtKodePlg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_pelanggan join tbl_penjualan on tbl_pelanggan.KodePlg = tbl_penjualan.Kode_Pelanggan where tbl_penjualan.Kode_Pelanggan = '" + txtKodePlg.Text + "'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtNamaPlg.Text = (string)dr["NamaPlg"];
                    txtPhonePlg.Text = (string)dr["PhonePlg"];
                    txtAlamatPlg.Text = (string)dr["AlamatPlg"];
                    dataGridView1.Rows.Clear();
                    DataBrgPlg();

                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                    dataGridView1.Rows.Clear();
                    ShowData();
                    ClearText();
                    TotalAll();
                }
                conn.Close();
            }
        }
    }
}
