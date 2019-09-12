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
    public partial class LaporanStrutkAktivasiCouple : Form
    {
        private TBL_TRANSAKSITableAdapter TT = new TBL_TRANSAKSITableAdapter();
        public LaporanStrutkAktivasiCouple(int id, string tm)
        {
            InitializeComponent();
            RptAktivasiCouple rpt = new RptAktivasiCouple();
            DataTable data = new DataTable();
            data = TT.cetaktransaksi(id);
            rpt.SetDataSource(data);
            rpt.SetParameterValue("namakasir", tm);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Show();
        }

        private void LaporanStrutkAktivasiCouple_Load(object sender, EventArgs e)
        {

            
        }
    }
}
