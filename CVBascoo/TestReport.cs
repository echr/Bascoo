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

using CrystalDecisions.CrystalReports.Engine;

namespace CVBascoo
{
    public partial class TestReport : Form
    {
        private FormMenu fmenu = new FormMenu();
        public TestReport()
        {
            InitializeComponent();
        }
        public TestReport(FormMenu f)
        {
            InitializeComponent();
            fmenu = f;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDocument crystalrpt = new ReportDocument();
            //crystalrpt.SetDatabaseLogon("Dito", "123", ".", "BascoJaya");
            //rpt.SetDataBaseLogon(username, pwd);// if required ..followed by pwd...servername ,Database name

            
            //E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\CVBascoo\CrystalReport1.rpt
            crystalrpt.Load(@"E:\Data 7 ke 8\Skripsi Lagi Berjalan 1-11-2013\CVBascoo\CVBascoo\CrystalReport2.rpt");
            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();
        }

        private void TestReport_Load(object sender, EventArgs e)
        {

        }
    }
}
