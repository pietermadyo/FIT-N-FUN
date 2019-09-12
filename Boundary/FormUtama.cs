using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnFun.Boundary
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
            toolStripStatusLabel1.Visible = false;
        }

        public void setToolStripUserlabel(string text)
        {
            this.toolStripStatusLabel1.Text = text;
        }

        public void setToolStripUser(string text)
        {
            this.toolStripUser.Text = text;
        }


        private void presensiInstrukturToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PresensiInstruktur frPresensiInstruktur = new PresensiInstruktur();
            frPresensiInstruktur.MdiParent = this;
            frPresensiInstruktur.Show();
        }

        
        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void jadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jadwal_Senam frJadwalSenam = new Jadwal_Senam();
            frJadwalSenam.MdiParent = this;
            frJadwalSenam.Show();
        }

        

        private void pengelolanMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.MdiParent = this;
            fr.Show();
        }

        private void presensiMemberToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PresensiMember frPresensiMember = new PresensiMember();
            frPresensiMember.MdiParent = this;
            frPresensiMember.Show();
        }

        private void promoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

      
        private void pendapatanPerbulanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transaksiHarianDanBulananToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rewardInstrukturToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jumlahStatusMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult fr = MessageBox.Show("Apakah anda yakin ingin LogOut ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (fr == DialogResult.Yes)
            {
                Application.Restart();
            }  
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult fr = MessageBox.Show("Apakah anda ingin exit ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (fr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

        public void setVisibleMenuTransaksi(bool set)
        {
            this.transaksiToolStripMenuItem.Visible = set;
        }

        public void setVisibleMenuKelolaInstruktur(bool set) 
        {
            this.kelolaInstrukturToolStripMenuItem.Visible = set;
        }

        public void SetVisibleMenuKelolaMember(bool set)
        {
            this.toolStripMenuKelolaMember.Visible = set;
        }

        public void setVisibleMenuJadwal(bool set)
        {
            this.jadwalToolStripMenuItem.Visible = set;
        }

        public void setVisibleDataPegawai(bool set)
        {
            this.dataPegawaiToolStripMenuItem.Visible = set;
        }

        public void setVisiblePromo(bool set)
        {
            this.promoToolStripMenuItem.Visible = set;
        }

        private void pengelolaanPegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataPegawai frPromo = new DataPegawai();
            frPromo.MdiParent = this;
            frPromo.Show();
        }

        public void setVisibleMenuPengelolaanPegawai(bool set)
        {
            this.pengelolaanPegawaiToolStripMenuItem.Visible = set;
        }

        public void setVisibleJadwal(bool set)
        {
            this.jadwalPromoToolStripMenuItem.Visible = set;
        }
       

        private void transaksiMemberGetMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiAktivasiMemberGetMember frTransaksi = new TransaksiAktivasiMemberGetMember();
            frTransaksi.MdiParent = this;
            frTransaksi.Show();
        }

        private void transaksiAktivasiRegulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiAktivasiReguler frTransaksi = new TransaksiAktivasiReguler();
            frTransaksi.setToolStripUser1(toolStripStatusLabel1.Text);
            frTransaksi.MdiParent = this;
            frTransaksi.Show();
        }

        private void transaksiSenamRegulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiSenamReguler frTransaksi = new TransaksiSenamReguler();
            
            frTransaksi.MdiParent = this;
            frTransaksi.Show();
        }

        private void transaksiAktivasiCoupleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiAktivasiCouple frTransaksi = new TransaksiAktivasiCouple();
            frTransaksi.MdiParent = this;
            frTransaksi.Show();
        }

        private void transaksiDepositSenamPaketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiDepositSenamPaket frTransaksi = new TransaksiDepositSenamPaket();
            frTransaksi.MdiParent = this;
            frTransaksi.Show();
        }

        private void promoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promo frPromo = new Promo();
            frPromo.MdiParent = this;
            frPromo.Show();
        }

        private void dataPegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jadwalPromoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
       
        

        

        
        
      
    }
}
