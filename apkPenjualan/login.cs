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
    public partial class login : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        Koneksi koneksi = new Koneksi();

        HashCode hc = new HashCode();
        public login()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from tbl_user where NamaUser ='" + txtUsername.Text + "'and PassUser = '" + hc.PassHash(txtPass.Text) + "'", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                MenuUtama.menu.manageToolStripMenuItem.Enabled = true;
                MenuUtama.menu.transactionToolStripMenuItem.Enabled = true;
                MenuUtama.menu.recordTransactionToolStripMenuItem.Enabled = true;
                MenuUtama.menu.loginToolStripMenuItem.Enabled = false;
                MenuUtama.menu.signInToolStripMenuItem.Enabled = false;
                MenuUtama.menu.logoutToolStripMenuItem.Enabled = true;
                MenuUtama.menu.SNama.Text = (string)dr["NamaUser"];
                //MenuUtama mu = new MenuUtama();
                //mu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Username atau Password Salah!");
            }
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
