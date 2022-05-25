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
    public partial class FormRecordPembelian : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;

        Koneksi koneksi = new Koneksi();
        public FormRecordPembelian()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_pembelian join tbl_barang on tbl_pembelian.kode_barang = tbl_barang.KodeBrg", conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach(DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["NoFaktur"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["kode_barang"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["NamaBrg"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["JumlahBeli"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["HargaBeli"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value) * Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value);
            }
            conn.Close();

        }

        void ClearText()
        {
            txtKodeSup.Clear();
            txtNamaSup.Clear();
            txtPhoneSup.Clear();
            txtDescSup.Clear();
            txtAlamatSup.Clear();
            LTanggal.Text = "";
        }

        void TotalAll()
        {
            int jumlah = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                jumlah += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                txtTotalAll.Text = jumlah.ToString();


                //rupiah = decimal.Parse(jumlah.ToString());
                //txtTotalAll.Text = rupiah.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
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
            cmd = new SqlCommand("select * from tbl_pembelian join tbl_barang on tbl_pembelian.kode_barang = tbl_barang.KodeBrg  where tbl_pembelian.NoFaktur = '" + txtSearch.Text + "'", conn);
            da = new SqlDataAdapter(cmd);
            DataTable dataTab = new DataTable();
            da.Fill(dataTab);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            foreach (DataRow item in dataTab.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["NoFaktur"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["kode_barang"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["NamaBrg"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["JumlahBeli"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["HargaBeli"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value) * Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value);
            }
            conn.Close();
        }

        private void FormRecordPembelian_Load(object sender, EventArgs e)
        {
            ShowData();
            TotalAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

            if (e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_pembelian join tbl_supplier on tbl_pembelian.Kode_Supplier = tbl_supplier.KodeSup where NoFaktur = '" + txtSearch.Text + "'", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtKodeSup.Text = (string)dr["Kode_Supplier"];
                    txtNamaSup.Text = (string)dr["NamaSup"];
                    txtPhoneSup.Text = (string)dr["PhoneSup"];
                    txtDescSup.Text = (string)dr["DescSup"];
                    txtAlamatSup.Text = (string)dr["AlamatSup"];
                    LTanggal.Text = (string)dr["TglFaktur"];
                    dataGridView1.Rows.Clear();
                    FoundData();
                    TotalAll();

                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                    dataGridView1.Rows.Clear();
                    ShowData();
                    TotalAll();
                    ClearText();
                }
            }
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("NOTA PEMBELIAN BARANG", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(250, 0));
            e.Graphics.DrawString("Nama Supplier : " + txtNamaSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 80));
            e.Graphics.DrawString("Jenis Supplier : " + txtDescSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 110));
            e.Graphics.DrawString("Phone Supplier : " + txtPhoneSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString("Alamat Supplier : " + txtAlamatSup.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 170));

            e.Graphics.DrawString("No Faktur : " + txtSearch.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Tanggal : " + LTanggal.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(380, 220));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            e.Graphics.DrawString("Nama Barang", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 270));
            e.Graphics.DrawString("Jumlah", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 270));
            e.Graphics.DrawString("Harga Beli", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 270));
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }

        private void txtKodeSup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();
                cmd = new SqlCommand("select * from tbl_pembelian join tbl_supplier on tbl_pembelian.Kode_Supplier = tbl_supplier.KodeSup join tbl_barang on tbl_pembelian.Kode_Barang = tbl_barang.KodeBrg where tbl_pembelian.Kode_Supplier = '" + txtKodeSup.Text + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtNamaSup.Text = (string)dr["NamaSup"];
                    txtPhoneSup.Text = (string)dr["PhoneSup"];
                    txtAlamatSup.Text = (string)dr["AlamatSup"];
                    txtDescSup.Text = (string)dr["DescSup"];

                    dataGridView1.Rows.Clear();

                    foreach(DataRow item in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["NoFaktur"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = item["kode_barang"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = item["NamaBrg"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = item["JumlahBeli"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = item["HargaBeli"].ToString();
                        dataGridView1.Rows[n].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value) * Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value);
                    }

                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan");
                    dataGridView1.Rows.Clear();
                    ShowData();
                    TotalAll();
                    ClearText();
                }
            }
        }
    }
}
