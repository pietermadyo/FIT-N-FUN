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
    public partial class LaporanStruck : Form
    {
        public LaporanStruck()
        {
            InitializeComponent();
        }

        public LaporanStruck(int id)
        {
            InitializeComponent();
            ReportStruck rpt = new ReportStruck();
            DataTable data = new DataTable();
            data = TP.cetakstrukpresensi(id);
            rpt.SetDataSource(data);
            
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Show();
        }
        private TBL_PRESENSIMEMBERTableAdapter TP = new TBL_PRESENSIMEMBERTableAdapter();

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
