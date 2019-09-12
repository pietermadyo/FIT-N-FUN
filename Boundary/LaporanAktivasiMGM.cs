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
    public partial class LaporanAktivasiMGM : Form
    {
        private TBL_TRANSAKSITableAdapter TT = new TBL_TRANSAKSITableAdapter();
        public LaporanAktivasiMGM(int id, string tm)
        {
            InitializeComponent();
            RptAktivasiMGM rpt = new RptAktivasiMGM();
            DataTable data = new DataTable();
            data = TT.cetaktransaksi(id);
            rpt.SetDataSource(data);
            rpt.SetParameterValue("namakasir", tm);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Show();
        }
    }
}
