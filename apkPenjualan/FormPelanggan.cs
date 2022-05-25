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
    public partial class FormPelanggan : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        Koneksi koneksi = new Koneksi();

        String proses;
        String data;

        public FormPelanggan()
        {
            InitializeComponent();
        }

        void ClearText()
        {
            txtKode.Clear();
            txtNama.Clear();
            txtPhone.Clear();
            txtAlamat.Clear();
        }

        void ShowData()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_pelanggan", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbl_pelanggan");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_pelanggan";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conn.Close();

        }
        void EnableText()
        {
            txtKode.Enabled = true;
            txtNama.Enabled = true;
            txtPhone.Enabled = true;
            txtAlamat.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

        }
        void DisableText()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            txtPhone.Enabled = false;
            txtAlamat.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        void DisableBtn()
        {
            btnInput.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        void EnableBtn()
        {
            btnInput.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        void VisibleError()
        {
            ErrorKode.Visible = false;
            ErrorNama.Visible = false;
            ErrorPhone.Visible = false;
            ErrorAlamat.Visible = false;
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
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                ErrorPhone.Visible = true;
                txtPhone.Focus();
            }
            else if (string.IsNullOrEmpty(txtAlamat.Text))
            {
                ErrorAlamat.Visible = true;
                txtAlamat.Focus();
            }
            else
            {
                VisibleError();
                if (proses == "input" && data == "tambah")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("Insert into tbl_pelanggan (KodePlg, NamaPlg, PhonePlg, AlamatPlg) values ('" + txtKode.Text + "', '" + txtNama.Text + "','" + txtPhone.Text + "','" + txtAlamat.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil Disimpan");
                    ShowData();
                    ClearText();
                    DisableText();
                    EnableBtn();
                }
                else if (proses == "update" && data == "ada")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("update tbl_pelanggan set NamaPlg = '" + txtNama.Text + "', PhonePlg = '" + txtPhone.Text + "', AlamatPlg = '" + txtAlamat.Text + "' where KodePlg = '" + txtKode.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil Di Update");
                    ShowData();
                    ClearText();
                    DisableText();
                    EnableBtn();
                }
                else if (proses == "delete" && data == "ada")
                {
                    if (MessageBox.Show("Yakin Menghapus Data Ini?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlConnection conn = koneksi.GetConn();
                        conn.Open();
                        cmd = new SqlCommand("delete from tbl_pelanggan where KodePlg = '" + txtKode.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Data Berhasil Dihapus");
                        btnSave.Text = "Save";
                        ShowData();
                        ClearText();
                        DisableText();
                        EnableBtn();
                    }
                    else
                    {
                        btnSave.Text = "Delete";
                    }
                }
            }
            

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            EnableText();
            DisableBtn();
            txtKode.Focus();
            proses = "input";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnableText();
            DisableBtn();
            txtKode.Focus();
            proses = "update";
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EnableText();
            DisableBtn();
            txtKode.Focus();
            proses = "delete";
            btnSave.Text = "Delete";
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (proses == "input") {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_pelanggan where KodePlg='" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtNama.Text = (string)dr[1];
                        txtPhone.Text = (string)dr[2];
                        txtAlamat.Text = (string)dr[3];
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
                    cmd = new SqlCommand("select * from tbl_pelanggan where KodePlg='" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtNama.Text = (string)dr[1];
                        txtPhone.Text = (string)dr[2];
                        txtAlamat.Text = (string)dr[3];
                        data = "ada";
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ditemukan");
                    }
                    conn.Close();
                }
                else if (proses == "delete")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_pelanggan where KodePlg='" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtNama.Text = (string)dr[1];
                        txtPhone.Text = (string)dr[2];
                        txtAlamat.Text = (string)dr[3];
                        data = "ada";
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ditemukan");
                    }
                    conn.Close();
                }
            }
        }

        private void FormPelanggan_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            DisableText();
            EnableBtn();
            btnSave.Text = "Save";
            VisibleError();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
