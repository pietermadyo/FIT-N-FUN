using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnFun.Control;

namespace FitnFun.Boundary
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        LoginControl LC = new LoginControl();


        private void btnMasuk_Click(object sender, EventArgs e)
        {
            if (LC.cekLogin(txtuser.Text, txtpass.Text) == true)
            {
                int role = LC.GetRoleUser(txtuser.Text, txtpass.Text);

                if (role == 1)
                {
                    this.Hide();
                    FormUtama fr =new FormUtama();
                    fr.setToolStripUser("Pengguna : Admin - "+ txtuser.Text);
                    fr.setToolStripUserlabel(txtuser.Text);
                    fr.SetVisibleMenuKelolaMember(true);
                    fr.setVisibleMenuKelolaInstruktur(true);
                    fr.setVisibleMenuTransaksi(true);                    
                    fr.setVisibleMenuJadwal(true);                  
                    fr.setVisibleMenuPengelolaanPegawai(true);
                    fr.setVisiblePromo(true);
                    fr.ShowDialog();
                    this.Close();
                }
                else if (role == 2)
                {
                    this.Hide();
                    FormUtama fr = new FormUtama();
                    fr.setToolStripUser("Pengguna : Kasir - " + txtuser.Text);
                    fr.setToolStripUserlabel(txtuser.Text);
                    fr.SetVisibleMenuKelolaMember(true);
                    fr.setVisibleMenuTransaksi(true);
                    fr.setVisibleMenuKelolaInstruktur(false);
                    fr.setVisibleMenuJadwal(false);
                    fr.setVisibleMenuPengelolaanPegawai(false);
                    fr.setVisiblePromo(false);
                    fr.setVisibleDataPegawai(false);
                    fr.setVisibleJadwal(false);
                    fr.ShowDialog();
                    this.Close();
                }
                else if (role == 3)
                {
                    this.Hide();
                    FormUtama fr = new FormUtama();
                    fr.setToolStripUser("Pengguna : Instruktur - " + txtuser.Text);
                    fr.setToolStripUserlabel(txtuser.Text);
                    fr.SetVisibleMenuKelolaMember(false);
                    fr.setVisibleMenuKelolaInstruktur(false);
                    fr.setVisibleMenuTransaksi(false);                  
                    fr.setVisibleMenuJadwal(false);
                    fr.setVisibleMenuPengelolaanPegawai(false);
                    fr.ShowDialog();
                    this.Close();
                }
                else if (role == 4)
                {
                    this.Hide();
                    FormUtama fr = new FormUtama();
                    fr.setToolStripUser("Pengguna : Manager Operasional - " + txtuser.Text);
                    fr.setToolStripUserlabel(txtuser.Text);
                    fr.setVisibleMenuKelolaInstruktur(true);                                    
                    fr.setVisibleMenuJadwal(true);                    
                    fr.setVisibleMenuPengelolaanPegawai(false);
                    fr.setVisiblePromo(true);
                    fr.SetVisibleMenuKelolaMember(false);
                    fr.setVisibleMenuTransaksi(false);                 
                    fr.setVisibleDataPegawai(false);
                    fr.setVisibleJadwal(true);
                    fr.ShowDialog();
                    this.Close();
                }
                else if (role == 5)
                {
                    this.Hide();
                    FormUtama fr = new FormUtama();
                    fr.setToolStripUser("Pengguna : Member - " + txtuser.Text);
                    fr.setToolStripUserlabel(txtuser.Text);
                    fr.SetVisibleMenuKelolaMember(false);
                    fr.setVisibleMenuKelolaInstruktur(false);
                    fr.setVisibleMenuTransaksi(false);                 
                    fr.setVisibleMenuJadwal(false);                  
                    fr.setVisibleMenuPengelolaanPegawai(false);
                    fr.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tidak Memiliki Role");
                }
            }
            else
            {
                MessageBox.Show("Username atau Password Salah");
            }
        }

        private void txtuser_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
                e.Handled = true;
        }

        private void txtpass_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
                e.Handled = true;
        }

        private void btnBatal_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        
    }
    
}
