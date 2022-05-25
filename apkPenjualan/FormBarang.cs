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
    public partial class FormBarang : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        Koneksi koneksi = new Koneksi();

        String proses;
        String data;
        public FormBarang()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_barang", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbl_barang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_barang";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conn.Close();
        }

        void EnableText()
        {
            txtKode.Enabled = true;
            txtNama.Enabled = true;
            txtMerk.Enabled = true;
            txtSatuan.Enabled = true;
            txtJumlah.Enabled = true;
            txtHarga.Enabled = true;
            dateTimeExp.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        void Disabletext()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            txtMerk.Enabled = false;
            txtSatuan.Enabled = false;
            txtJumlah.Enabled = false;
            txtHarga.Enabled = false;
            dateTimeExp.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        void EnableBtn()
        {
            btnInput.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        void DisabledBtn()
        {
            btnInput.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        void ClearText()
        {
            txtKode.Clear();
            txtNama.Clear();
            txtMerk.Clear();
            txtSatuan.Clear();
            txtJumlah.Clear();
            txtHarga.Clear();
        }
        
        void VisibleError()
        {
            ErrorKode.Visible = false;
            ErrorNama.Visible = false;
            ErrorMerk.Visible = false;
            ErrorSatuan.Visible = false;
            ErrorJumlah.Visible = false;
            ErrorHarga.Visible = false;
        }

        void KodeBarang()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            long hitung;
            string urutan;
            cmd = new SqlCommand ("select kode from tbl_barang where KodeBrg in(select max(kode) from tbl_barang) order by KodeBrg desc", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                hitung = Convert.ToInt64(dr[0].ToString().Substring(dr["KodeBrg"].ToString().Length - 3, 3)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "BRG" + kodeurutan.Substring(kodeurutan.Length - 3, 3);
            }
            else
            {
                urutan = "BRG001";
            }
            dr.Close();
            txtKode.Text = urutan;
            conn.Close();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            EnableText();
            DisabledBtn();
            txtKode.Focus();
            proses = "input";
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnableText();
            DisabledBtn();
            txtKode.Focus();
            proses = "update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EnableText();
            DisabledBtn();
            txtKode.Focus();
            proses = "delete";
            btnSave.Text = "Delete";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKode.Text))
            {
                ErrorKode.Visible = true;
                txtKode.Focus();
            }
            else if (string.IsNullOrEmpty(txtNama.Text))
            {
                ErrorNama.Visible = true;
                txtNama.Focus();
            }
            else if (string.IsNullOrEmpty(txtMerk.Text))
            {
                ErrorMerk.Visible = true;
                txtMerk.Focus();
            }
            else if (string.IsNullOrEmpty(txtSatuan.Text))
            {
                ErrorSatuan.Visible = true;
                txtSatuan.Focus();
            }
            else if (string.IsNullOrEmpty(txtJumlah.Text))
            {
                ErrorJumlah.Visible = true;
                txtJumlah.Focus();
            }
            else if (string.IsNullOrEmpty(txtHarga.Text))
            {
                ErrorHarga.Visible = true;
                txtHarga.Focus();
            }
            else
            {
                VisibleError();
                if (proses == "input" && data == "tambah")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("Insert into tbl_barang (KodeBrg, NamaBrg, MerkBrg, SatuanBrg, JumlahBrg, HargaBrg, TglExp) values ('" + txtKode.Text + "', '" + txtNama.Text + "','" + txtMerk.Text + "','" + txtSatuan.Text + "', '" + txtJumlah.Text + "','" + txtHarga.Text + "','" + this.dateTimeExp.Value.ToString("MM/dd/yyyy") + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil Disimpan");
                    ShowData();
                    ClearText();
                    Disabletext();
                    EnableBtn();
                }
                else if (proses == "update" && data == "ada")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("update tbl_barang set NamaBrg = '" + txtNama.Text + "', MerkBrg = '" + txtMerk.Text + "', SatuanBrg = '" + txtSatuan.Text + "', JumlahBrg = '" + txtJumlah.Text + "', HargaBrg = '" + txtHarga.Text + "', TglExp = '" + this.dateTimeExp.Value.ToString("MM/dd/yyyy") + "' where KodeBrg = '" + txtKode.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil Diupdate");
                    ShowData();
                    ClearText();
                    Disabletext();
                    EnableBtn();
                }
                else if (proses == "delete" && data == "ada")
                {
                    if (MessageBox.Show("Yakin Menghapus Data Ini?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlConnection conn = koneksi.GetConn();
                        conn.Open();
                        cmd = new SqlCommand("delete from tbl_barang where KodeBrg = '" + txtKode.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Data Berhasil Dihapus");
                        btnSave.Text = "Save";
                        ShowData();
                        ClearText();
                        Disabletext();
                        EnableBtn();
                    }
                    else
                    {
                        btnSave.Text = "Delete";
                    }

                }
                else
                {
                    MessageBox.Show("Perintah Tidak Dikenal");
                }
            }
            
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (proses == "input")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_barang where KodeBrg='" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtMerk.Text = (string)dr[2];
                        txtNama.Text = (string)dr[1];
                        txtSatuan.Text = (string)dr[3];
                        txtJumlah.Text = dr[4].ToString();
                        txtHarga.Text = (string)dr[5];
                        dateTimeExp.Value = (DateTime)dr[6];
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        txtNama.Focus();
                        data = "tambah";
                    }
                    conn.Close();
                }
                else if (proses == "update")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_barang where KodeBrg='" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtMerk.Text = (string)dr[2];
                        txtNama.Text = (string)dr[1];
                        txtSatuan.Text = (string)dr[3];
                        txtJumlah.Text = dr[4].ToString();
                        txtHarga.Text = (string)dr[5];
                        dateTimeExp.Value = (DateTime)dr[6];
                        data = "ada";
                    }
                    else
                    {
                        MessageBox.Show("Data Barang Tidak Ditemukan");
                    }
                    conn.Close();
                }
                else if (proses == "delete")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_barang where KodeBrg='" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtMerk.Text = (string)dr[2];
                        txtNama.Text = (string)dr[1];
                        txtSatuan.Text = (string)dr[3];
                        txtJumlah.Text = dr[4].ToString();
                        txtHarga.Text = (string)dr[5];
                        dateTimeExp.Value = (DateTime)dr[6];
                        data = "ada";
                    }
                    else
                    {
                        MessageBox.Show("Data Barang Tidak Ditemukan");

                    }
                    conn.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            Disabletext();
            EnableBtn();
            VisibleError();
            btnSave.Text = "Save";
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
