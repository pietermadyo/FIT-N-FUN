using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnFun.Control;
using FitnFun.Boundary;



namespace FitnFun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MemberControl MC = new MemberControl();
        DataGridView DG = new DataGridView();
        public void getAllData()
        {
            DG = this.dataGridView1;
            DG.DataSource = MC.showMenu();

            DataTable DT = MC.showMenu();
            BindingList<DataTable> listTbl = new BindingList<DataTable>();
            if (DT.Rows.Count > 0)
            {
                int counter = 0, subTblIndex = -1;
                foreach (DataRow dr in DT.Rows)
                {
                    if (counter == 0)
                    {
                        listTbl.Add(DT.Clone());
                        subTblIndex++;
                    }
                    listTbl[subTblIndex].Rows.Add(dr.ItemArray);
                    counter++;
                    if (counter == 5)
                        counter = 0;
                }
            }


            bindingSource1.DataSource = listTbl;
            bindingNavigator1.BindingSource = bindingSource1;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource1.Position] : DT);



            DG.Columns[0].HeaderText = "ID";
            DG.Columns[1].HeaderText = "Nama";
            DG.Columns[2].HeaderText = "Status";
            DG.Columns[3].HeaderText = "Nomer HP";
            DG.Columns[4].HeaderText = "Email";
            DG.Columns[5].HeaderText = "Tanggal Lahir";
            DG.Columns[6].HeaderText = "Alamat";



            DG.Columns[0].Width = 30;
            DG.Columns[1].Width = 130;
            DG.Columns[2].Width = 130;
            DG.Columns[3].Width = 90;
            DG.Columns[4].Width = 120;
            DG.Columns[5].Width = 110;
            DG.Columns[6].Width = 130;
           

        }
        
        public void searchDatagridview(DataGridView DG, string Keyword)
        {
            DG.DataSource = MC.searchMenu(Keyword);

            DataTable DT = MC.searchMenu(Keyword);
            BindingList<DataTable> listTbl = new BindingList<DataTable>();
            if (DT.Rows.Count > 0)
            {
                int counter = 0, subTblIndex = -1;
                foreach (DataRow dr in DT.Rows)
                {
                    if (counter == 0)
                    {
                        listTbl.Add(DT.Clone());
                        subTblIndex++;
                    }
                    listTbl[subTblIndex].Rows.Add(dr.ItemArray);
                    counter++;
                    if (counter == 5)
                        counter = 0;
                }
            }


            bindingSource1.DataSource = listTbl;
            bindingNavigator1.BindingSource = bindingSource1;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource1.Position] : DT);



            DG.Columns[0].HeaderText = "ID";
            DG.Columns[1].HeaderText = "Nama";
            DG.Columns[2].HeaderText = "Status";
            DG.Columns[3].HeaderText = "Nomer HP";
            DG.Columns[4].HeaderText = "Email";
            DG.Columns[5].HeaderText = "Tanggal Lahir";
            DG.Columns[6].HeaderText = "Alamat";



            DG.Columns[0].Width = 30;
            DG.Columns[1].Width = 130;
            DG.Columns[2].Width = 130;
            DG.Columns[3].Width = 90;
            DG.Columns[4].Width = 120;
            DG.Columns[5].Width = 110;
            DG.Columns[6].Width = 130;
           


        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            getAllData();
        }
               
        private void bindingSource1_PositionChanged_1(object sender, EventArgs e)
        {
            this.searchDatagridview(dataGridView1, this.txtCari.Text);
            if (txtCari.Text == "")
            {
                getAllData();
            }
        }

        
        private void txtCari_TextChanged_1(object sender, EventArgs e)
        {
            searchDatagridview(dataGridView1, txtCari.Text);
        }
        
        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.enable();
        }

        public void enable()
        {
            txtCari.Enabled = true;
            dataGridView1.Enabled = true;
            btnBatal.Enabled = true;
            btnHapus.Enabled = true;
            btnTambah.Enabled = true;
            btnUbah.Enabled = true;
            cleartxt();
           
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                txtID.Text = getKolom(dataGridView1, 0);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
        }

        private string getKolom(DataGridView dg, int i)
        {
            return dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
        }

       
        private string getRow(DataGridView dg)
        {
            return dg.CurrentRow.Index.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
            txtNama.Text = getKolom(dataGridView1, 1);
            dateTimePicker1.Value = Convert.ToDateTime(getKolom(dataGridView1,5));
            txtEmail.Text = getKolom(dataGridView1, 4);
            txtNo_hp.Text = getKolom(dataGridView1, 3);       
            txtAlamat.Text = getKolom(dataGridView1, 6);


        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
        }

       

        private bool cektxt()
        {
            bool temp = true;
            if (txtNama.Text == "")
            {
                errorProvider1.SetError(txtNama, "Silahkan Isi Nama Member");
                txtNama.Focus();
                temp = false;
            }
            if (txtAlamat.Text == "")
            {
                errorProvider1.SetError(txtAlamat, "Silahkan Isi Nama Member");
                txtAlamat.Focus();
                temp = false;
            }
          
            if (dateTimePicker1.Text == "")
            {
                errorProvider1.SetError(dateTimePicker1, "Silahkan Isi Tanggal");
                dateTimePicker1.Focus();
                temp = false;
            }
            if (txtEmail.Text == "")
            {
                errorProvider1.SetError(txtEmail, "Silahkan Isi Email");
                txtEmail.Focus();
                temp = false;
            }
            if (txtNo_hp.Text == "")
            {
                errorProvider1.SetError(txtNo_hp, "Silahkan Isi NO HP");
                txtNo_hp.Focus();
                temp = false;
            }
            return temp;
        }

        private void cleartxt()
        {
            txtNama.Clear();
            txtAlamat.Clear();
            txtEmail.Clear();
            txtNo_hp.Clear();
            txtCari.Clear();
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
            

        private void btnTambah_Click(object sender, EventArgs e)
        {

            if (cektxt() == true)
            {
                if (emailIsValid(txtEmail.Text) == false)
                {
                    MessageBox.Show("Masukan Format email dengan benar!", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    errorProvider1.Clear();
                    Entity.Member M = new Entity.Member(txtNama.Text, dateTimePicker1.Value.ToShortDateString(),
                        DateTime.Now.ToShortDateString(), txtNo_hp.Text, txtEmail.Text, txtAlamat.Text);
                    MC.addMember(M);
                    MC.addUser(M);
                    MC.UpdateStatus("TIDAK AKTIF", txtNama.Text);
                    cleartxt();
                    getAllData();

                }
            }

        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNo_hp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        string temp_menu = "";

        

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Silahkan pilih data yang hendak dihapus");
                dataGridView1.Focus();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Apakah anda yakin menghapus data member ini ?"
                + getKolom(dataGridView1, 1), "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    MC.deleteMember(int.Parse(txtID.Text));
                    getAllData();
                }
                txtID.Clear();
                this.enable();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Silahkan pilih data yang hendak di ubah");
                dataGridView1.Focus();
            }
            else
            {
                if (cektxt() == true)
                {
                    errorProvider1.Clear();
                    FitnFun.Entity.Member M = new Entity.Member(txtNama.Text, dateTimePicker1.Value.ToShortDateString(), DateTime.Now.ToShortDateString(), txtNo_hp.Text, txtEmail.Text, txtAlamat.Text);                   
                    DialogResult dr = MessageBox.Show("Apakah anda yakin akan mengupdate data member " + temp_menu, "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        MC.editMember(M, int.Parse(txtID.Text));
                        getAllData();
                    }
                    cleartxt();
                }
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            MemberCard mc = new MemberCard(Convert.ToInt32(txtID.Text));
            mc.Show();
        }

    }
}
