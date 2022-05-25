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
    public partial class MenuUtama : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi koneksi = new Koneksi();

        login frmLogin;
        public static MenuUtama menu;
        MenuStrip mnstrip;


        public MenuUtama()
        {
            InitializeComponent();
        }

        void KondisiAwal()
        {
            if (SNama.Text=="username")
            {
                manageToolStripMenuItem.Enabled = false;
                transactionToolStripMenuItem.Enabled = false;
               
            }
            
        }

        void MenuTerkunci()
        {
            manageToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            recordTransactionToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Enabled = false;
            menu = this;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.ShowDialog();
        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            //KondisiAwal();
            MenuTerkunci();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrasi rg = new registrasi();
            rg.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBarang fb = new FormBarang();
            fb.ShowDialog();
        }

        private void pelangganToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPelanggan Fpelanggan = new FormPelanggan();
            Fpelanggan.ShowDialog();
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPenjualan Pj = new FormPenjualan();
            Pj.ShowDialog();
        }

        private void penjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRecordPenjualan RPenjualan = new FormRecordPenjualan();
            RPenjualan.ShowDialog();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSupplier Fs = new FormSupplier();
            Fs.ShowDialog();
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPembelian FPembelian = new FormPembelian();
            FPembelian.ShowDialog();
        }

        private void pembelianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRecordPembelian RPembelian = new FormRecordPembelian();
            RPembelian.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            STanggal.Text = DateTime.Now.ToString("dd MM yyyy");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SNama.Text = "";
            loginToolStripMenuItem.Enabled = true;
            signInToolStripMenuItem.Enabled = true;
            MenuTerkunci();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
