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
    public partial class Customer : Form
    {
        string dataSource = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\BascoJaya.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection();
        BindingSource bs1 = new BindingSource();

        string status = "";
        public static string um;

        private FormMenu fmenu = new FormMenu();
        private FormMenu formMenu;

        public Customer()
        {
            InitializeComponent();
        }


        public Customer(FormMenu f)
        {
            InitializeComponent();
            fmenu = f;
        }

        private void setvisible(bool x)
        {
            btnSave.Visible = !x;
            btnCancel.Visible = !x;


            textID.Enabled = false;

            textNama.Enabled = !x;
            textPhone.Enabled = !x;
            textNegara.Enabled = !x;
            textAlamat.Enabled = !x;
            textEmail.Enabled = !x;


            btnDelete.Visible = x;
            btnUpdate.Visible = x;
            btnAdd.Visible = x;


            //--dataGridView1.Enabled = x;
        }

        public void refreshTable()
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Pelanggan";

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
        private string autoGenerateIDcode()
        {
            con.ConnectionString = dataSource;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 PelangganId FROM Pelanggan ORDER BY PelangganId DESC", con);

            string code = cmd.ExecuteScalar().ToString().Substring(1, 3);
            int number = int.Parse(code);
            number++;
            con.Close();
            string generateID;
            if (number < 10)
            {
                generateID = "C00" + number;
            }
            else if (number < 100)
            {
                generateID = "C0" + number;
            }
            else
            {
                generateID = "C" + number;
            }
            return generateID;
        }

        private void setkosong()
        {
            textID.Text = "";
            textNama.Text = "";
            textPhone.Text = "";
            textAlamat.Text = "";
            textNegara.Text = "";
            textEmail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setvisible(false);
            setkosong();
            textID.Text = autoGenerateIDcode();
            status = "add";

            //setvisible(true);
        }

        public bool isNumber(string text)
        {
            try
            {
                Int64.Parse(text);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ingin Membatalkan ?", "Confrim Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                setvisible(true);
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Pelanggan";

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


            textID.DataBindings.Add("Text", bs1, "PelangganId", false, DataSourceUpdateMode.Never);
            textNama.DataBindings.Add("Text", bs1, "NamaPelanggan", false, DataSourceUpdateMode.Never);
            textPhone.DataBindings.Add("Text", bs1, "NoTelpon", false, DataSourceUpdateMode.Never);
            textAlamat.DataBindings.Add("Text", bs1, "Alamat", false, DataSourceUpdateMode.Never);
            textNegara.DataBindings.Add("Text", bs1, "NegaraAsal", false, DataSourceUpdateMode.Never);
            textEmail.DataBindings.Add("Text", bs1, "Email", false, DataSourceUpdateMode.Never);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(dataSource);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            if (textNama.Text == "")
            {
                MessageBox.Show("Nama Harus Diisi");
            }
            else if (textNegara.Text == "")
            {
                MessageBox.Show("Negara Asal Harus Diisi");
            }
            else if (textAlamat.Text == "")
            {
                MessageBox.Show("Alamat Harus Diisi");
            }

            else if (textPhone.Text == "")
            {
                MessageBox.Show("No Telepon Harus Diisi");
            }
            else if (textPhone.Text.Length < 8)
            {
                MessageBox.Show("No Telepon Terlalu Pendek");
            }
            else if (textPhone.Text.Length > 15)
            {
                MessageBox.Show("No Telepon Terlalu Panjang");
            }
            else if (!isNumber(textPhone.Text))
            {
                MessageBox.Show("No Telepon Harus Angka");
            }
            else if (status == "add")
            {
                DialogResult result = MessageBox.Show("Simpan Data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cn.Open();
                    cmd.CommandText = "Insert into Pelanggan (PelangganId, NamaPelanggan, Alamat, NoTelpon, NegaraAsal, Email) values ('" + textID.Text + "','"
                        + textNama.Text + "','"
                        + textAlamat.Text + "','"
                        + textPhone.Text + "','"
                        + textNegara.Text + "','"
                        + textEmail.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    MessageBox.Show("Data Tercatat!", "CV Basco Jaya");
                    cn.Close();
                }
                refreshTable();
            }
            else if (status == "update")
            {
                cmd.Connection = cn;

                cn.Open();
                cmd.CommandText = "update Pelanggan set NamaPelanggan =  '" + textNama.Text +
                    "',Alamat= '" + textAlamat.Text +
                    "',NoTelpon= '" + textPhone.Text +
                    "',NegaraAsal='" + textNegara.Text +
                    "',Email='" + textEmail.Text + "' where PelangganId='" + textID.Text + "'";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(dataSource);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.Connection = cn;
            cn.Open();

            DialogResult result = MessageBox.Show("Hapus Data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.CommandText = "delete from Pelanggan where PelangganId='" + textID.Text + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Data Dihapus !", "CV Basco Jaya");
                cn.Close();
            }
            refreshTable();
        }
    }
}
