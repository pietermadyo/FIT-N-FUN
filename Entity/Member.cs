using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class Member
    {
        private string nama;     
        private string tgl_lahir;
        private string tgl_masuk;
        private string no_hp;
        private string email;
        private string alamat;

        public Member(string nama, string tgl_lahir, string tgl_masuk, string no_hp, string email, string alamat)
        {
            this.nama = nama;
            this.tgl_lahir = tgl_lahir;
            this.no_hp = no_hp;
            this.email = email;
            this.alamat = alamat;
            this.TglMasuk = tgl_masuk;
        }
        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

      
        public string TglLahir
        {
            get { return tgl_lahir; }
            set { tgl_lahir = value; }
        }

        
        public string NoHp
        {
            get { return no_hp; }
            set { no_hp = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public string TglMasuk
        {
            get { return tgl_masuk; }
            set { tgl_masuk = value; }
        }
    }
}
