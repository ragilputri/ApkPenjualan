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
    public partial class registrasi : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        Koneksi koneksi = new Koneksi();
        HashCode hc = new HashCode();
        public registrasi()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("insert into tbl_user (Namauser, PassUser) values ('"+txtUsername.Text+"', '"+hc.PassHash(txtPass.Text)+"')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Akun Berhasil Dibuat, Silahkan Login!");
            conn.Close();
            this.Dispose();
            login lg = new login();
            lg.ShowDialog();

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
