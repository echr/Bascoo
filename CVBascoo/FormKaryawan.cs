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
    public partial class FormKaryawan : Form
    {
        string dataSource = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\BascoJaya.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection();
        BindingSource bs1 = new BindingSource();

        string status = "";
        public static string um;

        private FormMenu fmenu = new FormMenu();

        public FormKaryawan()
        {
            InitializeComponent();
        }

        public FormKaryawan(FormMenu f)
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
            textAlamat.Enabled = !x;
            textTgl.Enabled = !x;
            cbBag.Enabled = !x;


            btnDelete.Visible = x;
            btnUpdate.Visible = x;
            btnAdd.Visible = x;


            //--dataGridView1.Enabled = x;
        }

        private void setkosong()
        {
            textID.Text = "";
            textNama.Text = "";
            textPhone.Text = "";
            textAlamat.Text = "";
            textPhone.Text = "";
            textTgl.Text = "";
            cbBag.Text = "";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ingin Membatalkan ?", "Confrim Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                setvisible(true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Karyawan";

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


            textID.DataBindings.Add("Text", bs1, "IdKaryawan", false, DataSourceUpdateMode.Never);
            textNama.DataBindings.Add("Text", bs1, "NamaKaryawan", false, DataSourceUpdateMode.Never);
            textPhone.DataBindings.Add("Text", bs1, "NoTelpon", false, DataSourceUpdateMode.Never);
            textAlamat.DataBindings.Add("Text", bs1, "AlamatKaryawan", false, DataSourceUpdateMode.Never);
            textTgl.DataBindings.Add("Text", bs1, "TglLahir", false, DataSourceUpdateMode.Never);
            cbBag.DataBindings.Add("Text", bs1, "Posisi", false, DataSourceUpdateMode.Never);
            //textPass.DataBindings.Add("Text", bs1, "Password", false, DataSourceUpdateMode.Never);
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

        private void button3_Click(object sender, EventArgs e)
        {
            setvisible(false);
            setkosong();
            textID.Text = autoGenerateIDcode();
            status = "add";
        }

        private string autoGenerateIDcode()
        {
            con.ConnectionString = dataSource;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 IdKaryawan FROM Karyawan ORDER BY IdKaryawan DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();

            string generateID = "";
            if (dr.Read())
            {
                string lastID = dr["IdKaryawan"].ToString().Substring(1, 3);
                int number = int.Parse(lastID);
                number++;

                if (number < 10)
                {
                    generateID = "K00" + number;
                }
                else if (number < 100)
                {
                    generateID = "K0" + number;
                }
            }
            else
            {
                generateID = "K001";
            }
            con.Close();
            /*string code = cmd.ExecuteScalar().ToString().Substring(1, 3);
            int number = int.Parse(code);
            number++;
            con.Close();
            string generateID;
            if (number < 10)
            {
                generateID = "K00" + number;
            }
            else if (number < 100)
            {
                generateID = "K0" + number;
            }
            else
            {
                generateID = "K" + number;
            }*/
            return generateID;
        }

        public void refreshTable()
        {
            string strCon = dataSource;
            string strSQL = "SELECT * FROM Karyawan";

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(dataSource);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            if (textNama.Text == "")
            {
                MessageBox.Show("Nama Harus Diisi");
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
            else if (textPass.Text == "")
            {
                MessageBox.Show("Password Harus Diisi");
            }
            else if (textPass.Text.Length < 6)
            {
                MessageBox.Show("Password Terlalu Pendek");
            }
            else if (cbBag.SelectedItem == null)
            {
                MessageBox.Show("Bagian Karyawan Harus Diisi ");
            }
            else if (status == "add")
            {
                DialogResult result = MessageBox.Show("Simpan Data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cn.Open();
                    cmd.CommandText = "Insert into Karyawan (IdKaryawan, NamaKaryawan, AlamatKaryawan, NoTelpon, TglLahir, Password, Posisi) values ('" + textID.Text + "','"
                        + textNama.Text + "','"
                        + textAlamat.Text + "','"
                        + textPhone.Text + "','"
                        + textTgl.Text + "','"
                        + textPass.Text + "','"
                        + cbBag.Text + "')";
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
                cmd.CommandText = "update Pelanggan set NamaKaryawan =  '" + textNama.Text +
                    "',Alamat= '" + textAlamat.Text +
                    "',NoTelpon= '" + textPhone.Text +
                    "',TglLahir='" + textTgl.Text +
                    "',Bagian='" + cbBag.Text + "' where IdKaryawan='" + textID.Text + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Data Diubah !", "CV Basco Jaya");
                refreshTable();
            }
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
                cmd.CommandText = "delete from Karyawab where IdKaryawab='" + textID.Text + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Data Dihapus !", "CV Basco Jaya");
                cn.Close();
            }
            refreshTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            setvisible(false);
            status = "update";
        }
    }
}
