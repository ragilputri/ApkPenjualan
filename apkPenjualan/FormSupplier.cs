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
    public partial class FormSupplier : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;

        Koneksi koneksi = new Koneksi();

        string proses;
        string data;
        public FormSupplier()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_supplier", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbl_supplier");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_supplier";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conn.Close();
        }

        void EnableText()
        {
            txtKode.Enabled = true;
            txtNama.Enabled = true;
            txtPhone.Enabled = true;
            txtAlamat.Enabled = true;
            txtDesc.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        void DisableText()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            txtPhone.Enabled = false;
            txtAlamat.Enabled = false;
            txtDesc.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        void EnableBtn()
        {
            btnInput.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        void DisableBtn()
        {
            btnInput.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        void ClearText()
        {
            txtKode.Clear();
            txtNama.Clear();
            txtPhone.Clear();
            txtAlamat.Clear();
            txtDesc.Clear();
        }
        void VisibleError()
        {
            ErrorKode.Visible = false;
            ErrorNama.Visible = false;
            ErrorPhone.Visible = false;
            ErrorAlamat.Visible = false;
            ErrorDesc.Visible = false;
        }
        private void FormSupplier_Load(object sender, EventArgs e)
        {
            ShowData();
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
                if(proses == "input")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_supplier where KodeSup = '" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        txtNama.Text = (string)dr["NamaSup"];
                        txtPhone.Text = (string)dr["PhoneSup"];
                        txtAlamat.Text = (string)dr["AlamatSup"];
                        txtDesc.Text = (string)dr["DescSup"];
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        txtNama.Focus();
                    }
                }
                else if (proses == "update")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_supplier where KodeSup = '" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        txtNama.Text = (string)dr["NamaSup"];
                        txtPhone.Text = (string)dr["PhoneSup"];
                        txtAlamat.Text = (string)dr["AlamatSup"];
                        txtDesc.Text = (string)dr["DescSup"];
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ditemukan");
                    }
                }
                else if (proses == "delete")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("select * from tbl_supplier where KodeSup = '" + txtKode.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        txtNama.Text = (string)dr["NamaSup"];
                        txtPhone.Text = (string)dr["PhoneSup"];
                        txtAlamat.Text = (string)dr["AlamatSup"];
                        txtDesc.Text = (string)dr["DescSup"];
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ditemukan");
                    }
                }
            }
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
            else if (string.IsNullOrEmpty(txtDesc.Text))
            {
                ErrorDesc.Visible = true;
                txtDesc.Focus();
            }
            else
            {
                VisibleError();
                if (proses == "input")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("insert into tbl_supplier (KodeSup, NamaSup, PhoneSup, AlamatSup, DescSup) values ('" + txtKode.Text + "', '" + txtNama.Text + "', '" + txtPhone.Text + "', '" + txtAlamat.Text + "', '" + txtDesc.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil Tersimpan");
                    ShowData();
                    ClearText();
                    DisableText();
                    EnableBtn();
                }
                else if (proses == "update")
                {
                    SqlConnection conn = koneksi.GetConn();
                    conn.Open();
                    cmd = new SqlCommand("update tbl_supplier set NamaSup = '" + txtNama.Text + "', PhoneSup = '" + txtPhone.Text + "', AlamatSup = '" + txtAlamat.Text + "', DescSup = '" + txtDesc.Text + "' where KodeSup = '" + txtKode.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil Diupdate");
                    ShowData();
                    ClearText();
                    DisableText();
                    EnableBtn();
                }
                else if (proses == "delete")
                {
                    if (MessageBox.Show("Yakin Menghapus Data ini?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlConnection conn = koneksi.GetConn();
                        conn.Open();
                        cmd = new SqlCommand("delete from tbl_supplier where KodeSup = '" + txtKode.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        ShowData();
                        btnSave.Text = "Save";
                        ClearText();
                        DisableText();
                        EnableBtn();
                    }
                    else
                    {

                    }


                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            ClearText();
            DisableText();
            EnableBtn();
            VisibleError();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
