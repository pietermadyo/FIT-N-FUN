using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnFun.Control;

namespace FitnFun.Boundary
{
    public partial class Jadwal_Senam : Form
    {
        public Jadwal_Senam()
        {
            InitializeComponent();
        }

        JadwalControl JC = new JadwalControl();
        DataGridView DG = new DataGridView();

        private void Jadwal_Senam_Load(object sender, EventArgs e)
        {
            cbHourMulai.SelectedIndex = 0;
            cbMinuteMulai.SelectedIndex = 0;
            cbHourSelesai.SelectedIndex = 0;
            cbMinuteSelesai.SelectedIndex = 0;


            cmbNama.DataSource = JC.getNama();
            cmbNama.DisplayMember = "NAMA_PEGAWAI";
            getAllData();
        }
     
        public void getAllData()
        {
            DG = this.dataGridView1;
            DG.DataSource = JC.showJadwal();

            DataTable DT = JC.showJadwal();
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
            DG.Columns[1].HeaderText = "Instruktur";
            DG.Columns[2].HeaderText = "Tanggal";
            DG.Columns[3].HeaderText = "Waktu";
            DG.Columns[4].HeaderText = "Kelas";
            DG.Columns[5].HeaderText = "Harga";
            DG.Columns[6].HeaderText = "Waktu Selesai";

            DG.Columns[0].Width = 50;
            DG.Columns[1].Width = 110;
            DG.Columns[2].Width = 105;
            DG.Columns[3].Width = 100;
            DG.Columns[4].Width = 125;
            DG.Columns[5].Width = 115;
            DG.Columns[6].Width = 115;
        }

        public void searchDatagridview(DataGridView DG, string Keyword)
        {
            DG.DataSource = JC.searchJadwal(Keyword);

            DataTable DT = JC.searchJadwal(Keyword);
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
            DG.Columns[1].HeaderText = "Instruktur";
            DG.Columns[2].HeaderText = "Tanggal";
            DG.Columns[3].HeaderText = "Waktu";
            DG.Columns[4].HeaderText = "Kelas";
            DG.Columns[5].HeaderText = "Harga";
            DG.Columns[6].HeaderText = "Waktu Selesai";

            DG.Columns[0].Width = 50;
            DG.Columns[1].Width = 110;
            DG.Columns[2].Width = 105;
            DG.Columns[3].Width = 100;
            DG.Columns[4].Width = 125;
            DG.Columns[5].Width = 115;
            DG.Columns[6].Width = 115;
        }

       
        private void bindingSource1_PositionChanged_1(object sender, EventArgs e)
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

        private bool cektxt()
        {
            bool temp = true;
            if (cmbNama.Text == "")
            {
                errorProvider1.SetError(cmbNama, "Silahkan Isi Nama Instruktur");
                cmbNama.Focus();
                temp = false;
            }

            if (txtKelas.Text == "")
            {
                errorProvider1.SetError(txtKelas, "Silahkan Isi Kelas");
                txtKelas.Focus();
                temp = false;
            }

            if (dtptgl.Text == "")
            {
                errorProvider1.SetError(dtptgl, "Silahkan Isi Tanggal");
                dtptgl.Focus();
                temp = false;
            }
            if (txtHarga.Text == "")
            {
                errorProvider1.SetError(txtHarga, "Silahkan Isi Harga");
                txtHarga.Focus();
                temp = false;
            }
            
            //if ( txtWaktu.Text == "")
            //{
            //    errorProvider1.SetError( txtWaktu, "Silahkan Isi Waktu");
            //    txtWaktu.Focus();
            //    temp = false;
            //}

            //if (txtWaktuSelesai.Text == "")
            //{
            //    errorProvider1.SetError(txtWaktuSelesai, "Silahkan Isi Waktu terlambat");
            //    txtWaktuSelesai.Focus();
            //    temp = false;
            //}
            return temp;
        }

        private void cleartxt()
        {
           
            txtHarga.Clear();
            txtCari.Clear();
            txtKelas.Clear();
            //txtWaktu.Clear();
            //txtWaktuSelesai.Clear();
        }

        private string getKolom(DataGridView dg, int i)
        {
            return dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
        }

        private string getRow(DataGridView dg)
        {
            return dg.CurrentRow.Index.ToString();
        }

        string temp_menu = "";

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

        

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.enable();
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

                    string waktuMulai = cbHourMulai.SelectedItem + ":" + cbMinuteMulai.SelectedItem + ":00";
                    string waktuSelesai = cbHourSelesai.SelectedItem + ":" + cbMinuteSelesai.SelectedItem + ":00";
                    string nama = cmbNama.Text;
                    Entity.Jadwal J = new Entity.Jadwal();                   
                    J.Tanggal = dtptgl.Value.ToShortDateString();
                    J.Waktu = waktuMulai;//txtWaktu.Text;
                    J.Waktuselesai = waktuSelesai;//txtWaktuSelesai.Text;
                    J.Kelas = txtKelas.Text;
                    J.NamaInsrtuktur = nama;
                    J.Harga = Convert.ToDouble(txtHarga.Text);
                    DialogResult dr = MessageBox.Show("Apakah anda yakin akan mengupdate data jadwal " + temp_menu, "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        JC.ediJadwal(J, int.Parse(txtID.Text));
                        getAllData();
                    }
                    cleartxt();
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            

            if (cektxt() == true)
            {

                errorProvider1.Clear(); 

                string waktuMulai = cbHourMulai.SelectedItem + ":" + cbMinuteMulai.SelectedItem + ":00";
                string waktuSelesai = cbHourSelesai.SelectedItem + ":" + cbMinuteSelesai.SelectedItem + ":00";

                              
                string nama = cmbNama.Text;
                //string[] formats = { "MM:mm", "MM:mm:ss" };
                //DateTime expectedDate;
                //string[] formats2 = { "MM:mm", "MM:mm:ss" };
                //DateTime expectedDate2; 
                //if (DateTime.TryParseExact(txtWaktu.Text, formats, new CultureInfo("en-US"), 
                //                            DateTimeStyles.None, out expectedDate))
                //{
                    //if (DateTime.TryParseExact(txtWaktuSelesai.Text, formats2, new CultureInfo("en-US"),
                    //    DateTimeStyles.None, out expectedDate2))
                    //if ()
                    //{
                Entity.Jadwal J = new Entity.Jadwal();
                J.Tanggal = dtptgl.Value.ToShortDateString();
                J.Waktu = waktuMulai;//txtWaktu.Text;
                J.Waktuselesai = waktuSelesai;//txtWaktuSelesai.Text;
                J.Kelas = txtKelas.Text;
                J.NamaInsrtuktur = nama;
                J.Harga = Convert.ToDouble(txtHarga.Text);
                JC.addJadwal(J);
                cleartxt();
                getAllData();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Isi waktu dengan format HH:mm / HH:mm:ss ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //} 
                //}
                //else
                //{
                //    MessageBox.Show("Isi waktu dengan format HH:mm / HH:mm:ss ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}     
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
                DialogResult dr = MessageBox.Show("Apakah anda yakin menghapus data jadwal ?"
                + getKolom(dataGridView1, 1), "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    JC.deleteJadwal(int.Parse(txtID.Text));
                    getAllData();
                }
                txtID.Clear();
                this.enable();
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);

            cmbNama.Text = getKolom(dataGridView1, 1);
            dtptgl.Value = Convert.ToDateTime(getKolom(dataGridView1,2));



            //Convert.ToDateTime(txtWaktu.Text = getKolom(dataGridView1, 3));
            string waktuMulai = getKolom(dataGridView1, 3);
            string waktuMulaiHour = waktuMulai.Split(new char[] { ':' })[0];
            string waktuMulaiMinute = waktuMulai.Split(new char[] { ':' })[1];
            string waktuMulaiSecond = waktuMulai.Split(new char[] { ':' })[2];
            cbHourMulai.Text = waktuMulaiHour;
            cbMinuteMulai.Text = waktuMulaiMinute;

            string waktuSelesai = getKolom(dataGridView1, 6);
            string waktuSelesaiHour = waktuSelesai.Split(new char[] { ':' })[0];
            string waktuSelesaiMinute = waktuSelesai.Split(new char[] { ':' })[1];
            string waktuSelesaiSecond = waktuSelesai.Split(new char[] { ':' })[2];
            cbHourSelesai.Text = waktuSelesaiHour;
            cbMinuteSelesai.Text = waktuSelesaiMinute;

            //Convert.ToDateTime(txtWaktuSelesai.Text = getKolom(dataGridView1, 6));

            txtKelas.Text = getKolom(dataGridView1, 4);            
            txtHarga.Text = getKolom(dataGridView1, 5);           
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            txtID.Text = getKolom(dataGridView1, 0);
            txtRow.Text = getRow(dataGridView1);
        }

       
       
    }
}
