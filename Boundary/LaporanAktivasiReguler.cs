using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FitnFun.dsFitnFunTableAdapters;
using FitnFun.Report;

namespace FitnFun.Boundary
{
    public partial class LaporanAktivasiReguler : Form
    {
        public LaporanAktivasiReguler()
        {
            InitializeComponent();
        }
        private TBL_TRANSAKSITableAdapter TT = new TBL_TRANSAKSITableAdapter();

        private string temp;

        //public void setToolStripUser1(string text)
        //{
        //    temp = text;
        //}

        public LaporanAktivasiReguler(int id,string tm)
        {
            InitializeComponent();
            //RptTransaksiReguler rpt = new RptTransaksiReguler();
            RptAktivasiReguler rpt = new RptAktivasiReguler();
            DataTable data = new DataTable();
            data = TT.cetaktransaksi(id);
            rpt.SetDataSource(data);
            rpt.SetParameterValue("namakasir", tm);
            
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Show();
        }

        
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
