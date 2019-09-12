using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class Jadwal
    {
        private string nama_insrtuktur;
        private string kelas;
        private string tanggal;
        private string waktu;
        private string waktuselesai;
        private double harga;

        //public Jadwal(string tanggal, string waktu,string waktuselesai ,string kelas, string nama_insrtuktur, double harga)
        //{
        //    this.NamaInsrtuktur = nama_insrtuktur;
        //    this.Kelas = kelas;
        //    this.Tanggal = tanggal;
        //    this.Waktu = waktu;
        //    this.waktuselesai = waktuselesai;
        //    this.Harga = harga;
        //}


        public string NamaInsrtuktur
        {
            get { return nama_insrtuktur; }
            set { nama_insrtuktur = value; }
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

        public string Waktu
        {
            get { return waktu; }
            set { waktu = value; }
        }

        public double Harga
        {
            get { return harga; }
            set { harga = value; }
        }

        public string Waktuselesai
        {
            get { return waktuselesai; }
            set { waktuselesai = value; }
        }
    }
}
