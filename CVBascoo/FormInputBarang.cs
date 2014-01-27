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
    public partial class FormInputBarang : Form
    {
        string dataSource = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\CVBascoo\BascoJaya.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection();
        BindingSource bs1 = new BindingSource();

        string status = "";

        int tambah = 0;
        public static string um;

        private FormMenu fmenu = new FormMenu();
        private FormMenu formMenu;

        public FormInputBarang(FormMenu f)
        {
            InitializeComponent();
            fmenu = f;
        }

        public FormInputBarang()
        {
            InitializeComponent();
        }

        private void FormInputBarang_Load(object sender, EventArgs e)
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Barang1";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strCon);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bs1.DataSource = table;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bs1;

            setvisible(true);
            setkosong();


            textID.DataBindings.Add("Text", bs1, "IdBarang", false, DataSourceUpdateMode.Never);
            textMerk.DataBindings.Add("Text", bs1, "NamaBarang", false, DataSourceUpdateMode.Never);
            textHarga.DataBindings.Add("Text", bs1, "Harga", false, DataSourceUpdateMode.Never);
            textStok.DataBindings.Add("Text", bs1, "Stok", false, DataSourceUpdateMode.Never);
            textModel.DataBindings.Add("Text", bs1, "ModelBarang", false, DataSourceUpdateMode.Never);
            textMotif.DataBindings.Add("Text", bs1, "MotifBarang", false, DataSourceUpdateMode.Never);
        }

        private void setvisible(bool x)
        {
            btnSave.Visible = !x;
            btnCancel.Visible = !x;


            textID.Enabled = false;

            textMerk.Enabled = !x;
            textModel.Enabled = !x;
            textStok.Enabled = !x;
            textHarga.Enabled = !x;
            


            btnDelete.Visible = x;
            btnUpdate.Visible = x;
            btnAdd.Visible = x;

            textBox1.Visible = !x; 


            //--dataGridView1.Enabled = x;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            setvisible(false);
            setkosong();
            textID.Text = autoGenerateIDcode();
            status = "add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ingin Membatalkan ?", "Confrim Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                setvisible(true);
            }
        }

        public void refreshTable()
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Barang";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strCon);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bs1.DataSource = table;

            dataGridView1.DataSource = bs1;

            setvisible(true);
            setkosong();
        }

        private void setkosong()
        {
            textID.Text = "";
            textMerk.Text = "";
            textModel.Text = "";
            textHarga.Text = "";
            
            textStok.Text = "";
        }

        private string autoGenerateIDcode()
        {
            con.ConnectionString = dataSource;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 BarangId FROM Barang ORDER BY BarangId DESC", con);

            string code = cmd.ExecuteScalar().ToString().Substring(1, 3);
            int number = int.Parse(code);
            number++;
            con.Close();
            string generateID;
            if (number < 10)
            {
                generateID = "B00" + number;
            }
            else if (number < 100)
            {
                generateID = "B0" + number;
            }
            else
            {
                generateID = "B" + number;
            }
            return generateID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(dataSource);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            if (textMerk.Text == "")
            {
                MessageBox.Show("Merk Barang Harus Diisi");
            }
            else if (textModel.Text == "")
            {
                MessageBox.Show("Jenis Barang Harus Diisi");
            }
            else if (textStok.Text == "")
            {
                MessageBox.Show("Tambahan Stok Harus Diisi");
            }
                 
            else if (textHarga.Text == "")
            {
                MessageBox.Show("Harga Harus Diisi");
            }
            
            else if (status == "add")
            {
                DialogResult result = MessageBox.Show("Simpan Data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cn.Open();
                    cmd.CommandText = "Insert into Barang (BarangId, MerkBarang, JenisBarang, Harga, Supplier, Stok) values ('" + textID.Text + "','"
                        + textMerk.Text + "','"
                        + textModel.Text + "','"
                        + textHarga.Text + "'"
                        + textStok.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    MessageBox.Show("Data Tercatat!", "CV Basco Jaya");
                    cn.Close();
                }
                refreshTable();
            }
            else if (status == "update")
            {
                int stok_awal = int.Parse(textBox1.Text);
                int stok_baru = int.Parse(textStok.Text);
                tambah = stok_awal + stok_baru;

                cmd.Connection = cn;

                cn.Open();
                cmd.CommandText = "update Barang set MerkBarang =  '" + textMerk.Text +
                    "',JenisBarang= '" + textModel.Text +
                    "',Harga= '" + textHarga.Text +
                    "',Stok='" + tambah.ToString() + "' where BarangId='" + textID.Text + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Data Diubah !", "CV Basco Jaya");
                refreshTable();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            setvisible(false);
            status = "update";
        }
    }
}
