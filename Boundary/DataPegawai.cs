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


namespace FitnFun.Boundary
{
    public partial class DataPegawai : Form
    {
        public DataPegawai()
        {
            InitializeComponent();           
        }

        PegawaiControl PC = new PegawaiControl();
        DataGridView DG = new DataGridView();

        private void DataPegawai_Load(object sender, EventArgs e)
        {
            cmbPeran.DataSource = PC.getKategori();
            cmbPeran.DisplayMember = "PERAN";
            getAllData();
        }

        private bool cektxt()
        {
            bool temp = true;
            if (txtNama.Text == "")
            {
                errorProvider1.SetError(txtNama, "Silahkan Isi Nama ");
                txtNama.Focus();
                temp = false;
            }

            if (txtAlamat.Text == "")
            {
                errorProvider1.SetError(txtAlamat, "Silahkan Isi Alamat");
                txtAlamat.Focus();
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
                errorProvider1.SetError(txtNo_hp, "Silahkan Isi No HP");
                txtNo_hp.Focus();
                temp = false;
            }

            if (dateTimePicker1.Text == "")
            {
                errorProvider1.SetError(dateTimePicker1, "Silahkan Isi tanggal lahir");
                dateTimePicker1.Focus();
                temp = false;
            }

            if (cmbPeran.Text == "")
            {
                errorProvider1.SetError(cmbPeran, "Silahkan Isi peran anda");
                cmbPeran.Focus();
                temp = false;
            }

            return temp;
        }

        private void cleartxt()
        {
            txtNama.Clear();
            txtAlamat.Clear();       
            cmbPeran.SelectedIndex = -1;
            txtEmail.Clear();
            txtNo_hp.Clear();
        }
     
        public void getAllData()
        {          
            DG = this.dataGridView1;
            DG.DataSource = PC.showPegawai();

            DataTable DT = PC.showPegawai();
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
          
            DG.Columns[0].HeaderText = "NIP PEGAWAI";
            DG.Columns[1].HeaderText = "Nama";
            DG.Columns[2].HeaderText = "Alamat";
            DG.Columns[3].HeaderText = "Tanggal Lahir";
            DG.Columns[4].HeaderText = "Email";
            DG.Columns[5].HeaderText = "Nomer HP";
            DG.Columns[6].HeaderText = "Peran";
            
            DG.Columns[0].Width = 105;
            DG.Columns[1].Width = 100;
            DG.Columns[2].Width = 100;
            DG.Columns[3].Width = 100;
            DG.Columns[4].Width = 100;
            DG.Columns[5].Width = 100;
            DG.Columns[6].Width = 120;
           
        }

        public void searchDatagridview(DataGridView DG, string Keyword)
        {
            DG.DataSource = PC.searchMenu(Keyword);

            DataTable DT = PC.searchMenu(Keyword);
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



            DG.Columns[0].HeaderText = "NIP PEGAWAI";
            DG.Columns[1].HeaderText = "Nama";
            DG.Columns[2].HeaderText = "Alamat";
            DG.Columns[3].HeaderText = "Tanggal Lahir";
            DG.Columns[4].HeaderText = "Email";
            DG.Columns[5].HeaderText = "Nomer HP";
            DG.Columns[6].HeaderText = "Peran";

            DG.Columns[0].Width = 105;
            DG.Columns[1].Width = 100;
            DG.Columns[2].Width = 100;
            DG.Columns[3].Width = 100;
            DG.Columns[4].Width = 100;
            DG.Columns[5].Width = 100;
            DG.Columns[6].Width = 120; ;


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
                    int IDKategori = PC.GetIDKategori(cmbPeran.Text);
                    Entity.Pegawai P = new Entity.Pegawai(txtNama.Text, dateTimePicker1.Value.ToShortDateString(), txtAlamat.Text, txtEmail.Text, txtNo_hp.Text, IDKategori);
                    PC.addPegawai(P);
                    PC.addUser(P, IDKategori);
                    cleartxt();
                    getAllData();
                }
                
            }                      
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            this.searchDatagridview(dataGridView1, this.txtCari.Text);
            if (txtCari.Text == "")
            {
                getAllData();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            searchDatagridview(dataGridView1, txtCari.Text);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            enable();
        }

        private string getKolom(DataGridView dg, int i)
        {
            return dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
        }


        private string getRow(DataGridView dg)
        {
            return dg.CurrentRow.Index.ToString();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);

            txtNama.Text = getKolom(dataGridView1, 1);
            dateTimePicker1.Value = Convert.ToDateTime(getKolom(dataGridView1, 3));
            txtEmail.Text = getKolom(dataGridView1, 4);
            txtNo_hp.Text = getKolom(dataGridView1, 5);
            txtAlamat.Text = getKolom(dataGridView1, 2);
            cmbPeran.Text = getKolom(dataGridView1,6);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Silahkan pilih data yang hendak dihapus");
                dataGridView1.Focus();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Apakah anda yakin menghapus data pegawai ini ?"
                + getKolom(dataGridView1, 1), "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    PC.deletePegawai(int.Parse(txtID.Text));
                    getAllData();
                }
                txtID.Clear();
                this.enable();
            }
        }
        string temp_menu = "";

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
                    int IDKategori = PC.GetIDKategori(cmbPeran.Text);
                    FitnFun.Entity.Pegawai P = new Entity.Pegawai(txtNama.Text, dateTimePicker1.Value.ToShortDateString(), txtAlamat.Text, txtEmail.Text, txtNo_hp.Text, IDKategori);
                    DialogResult dr = MessageBox.Show("Apakah anda yakin akan mengupdate data pegawai " + temp_menu, "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        PC.editPegawai(P, int.Parse(txtID.Text));
                        getAllData();
                    }
                    cleartxt();
                }
            }
        }

        
    }
}
