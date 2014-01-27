using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVBascoo
{
    public partial class FormMenu : Form
    {
        private FormKaryawan karyawan;
        private Customer cust;
        private FormSupplier sup;
        private FormPemesanan pem;
        private FormInputBarang inp;
        private TestReport trp;
        private ViewPemasaran Psr;

        
        public FormMenu()
        {
            InitializeComponent();
        }

      


        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cust == null ||cust .IsDisposed)
            {
                cust = new Customer(this);
                cust.Show();
                cust.MdiParent = this;

            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void lensaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( karyawan == null || karyawan.IsDisposed)
            {
                karyawan = new FormKaryawan(this);
                karyawan.Show();
                karyawan.MdiParent = this;

            }
            
        }

        private void keluarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sup == null || sup.IsDisposed)
            {
                sup = new FormSupplier(this);
                sup.Show();
                sup.MdiParent = this;

            }
        }

        private void tambahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pem == null || pem.IsDisposed)
            {
                pem = new FormPemesanan(this);
                pem.Show();
                pem.MdiParent = this;

            }
        }

        private void pembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inp == null || inp.IsDisposed)
            {
                inp = new FormInputBarang(this);
                inp.Show();
                inp.MdiParent = this;
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trp == null || trp.IsDisposed)
            {
                trp = new TestReport(this);
                trp.Show();
                trp.MdiParent = this;
            }
        }

        private void pemasaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Psr == null || Psr.IsDisposed)
            {
                Psr = new ViewPemasaran(this);
                Psr.Show();
                Psr.MdiParent = this;
            }
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
