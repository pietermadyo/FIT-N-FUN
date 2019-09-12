using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class Pegawai
    {
        private string nama;
        private string alamat;
        private string tanggal_lahir;
        private string email;
        private string no_hp;
        private int idperan;

        public Pegawai(string nama, string tanggal_lahir, string alamat,string email,string no_hp, int idperan)
        {
            this.nama = nama;
            this.alamat = alamat;
            this.tanggal_lahir = tanggal_lahir;
            this.email = email;
            this.no_hp = no_hp;
            this.idperan = idperan;
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public string TanggalLahir
        {
            get { return tanggal_lahir; }
            set { tanggal_lahir = value; }
        }

        public int Idperan
        {
            get { return idperan; }
            set { idperan = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string NoHp
        {
            get { return no_hp; }
            set { no_hp = value; }
        }
    }
}
