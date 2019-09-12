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
    public partial class MemberCard : Form
    {
        public MemberCard()
        {
            InitializeComponent();
        }
        private TBL_MEMBERTableAdapter TM = new TBL_MEMBERTableAdapter();

        public MemberCard(int id)
        {
            InitializeComponent();
            RptMemberCard rpt = new RptMemberCard();
            DataTable data = new DataTable();
            data = TM.CetakMemberCard(id);
            rpt.SetDataSource(data);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Show();
        }
         
    }
}
