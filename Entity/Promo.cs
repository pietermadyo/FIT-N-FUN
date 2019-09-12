using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class Promo
    {
        private string nama;
        private string kelas;
        private string tanggal;
        private double harga;

        public Promo(string nama, string kelas, string tanggal, double harga)
        {
            this.Nama = nama;
            this.Kelas = kelas;
            this.Tanggal = tanggal;
            this.Harga = harga;
        }


        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string Kelas
        {
            get { return kelas; }
            set { kelas = value; }
        }

        public string Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }

        public double Harga
        {
            get { return harga; }
            set { harga = value; }
        }
    }
}
