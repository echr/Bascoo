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
    public partial class ViewPemasaran : Form
    {
        string dataSource = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\BascoJaya.mdf;Integrated Security=True;Connect Timeout=30";

        
        private FormMenu fmenu = new FormMenu();
        private FormMenu formMenu;

        SqlConnection con = new SqlConnection();
        BindingSource bs1 = new BindingSource();

         public ViewPemasaran(FormMenu f)
        {
            InitializeComponent();
            fmenu = f;
        }

        public ViewPemasaran()
        {
            InitializeComponent();
        }

        private void ViewPemasaran_Load(object sender, EventArgs e)
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Barang";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strCon);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bs1.DataSource = table;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bs1;
        }
    }
}
