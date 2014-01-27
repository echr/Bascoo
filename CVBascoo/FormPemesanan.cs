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

namespace CVBascoo
{
    public partial class FormPemesanan : Form
    {
        private FormMenu fmenu = new FormMenu();
        private FormMenu formMenu;

        string dataSource = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\BascoJaya.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection();
        BindingSource bs1 = new BindingSource();

        string status = "";
        public static string um;

        public FormPemesanan(FormMenu f)
        {
            InitializeComponent();
            fmenu = f;
        }

        public FormPemesanan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void FormPemesanan_Load(object sender, EventArgs e)
        {

        }

        private void setvisible(bool x)
        {
            btnSave.Visible = !x;
            btnCancel.Visible = !x;


            textID.Enabled = false;
            textIdCust.Enabled = false;

            textCust.Enabled = !x;
            cbPesanan.Enabled = !x;
            textBanyakPesanan.Enabled = !x;
            cbSupplier.Enabled = !x;


            btnDelete.Visible = x;
            btnUpdate.Visible = x;
            btnAdd.Visible = x;


            //--dataGridView1.Enabled = x;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ingin Membatalkan ?", "Confrim Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                setvisible(true);
            }
        }
    }
}
