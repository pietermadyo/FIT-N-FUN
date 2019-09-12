using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class PresensiMember
    {
        private int id;      
        private string kelas;
        private string tanggal;
        private string waktu;
        private double harga;
        private double sisaDeposit;
        private double sisaKelas;

        public double SisaKelas
        {
            get { return sisaKelas; }
            set { sisaKelas = value; }
        }


        //public PresensiMember(int id, string kelas, string tanggal, string waktu, double harga, double sisaDeposit)
        //{
        //    this.id = id;
        //    this.kelas = kelas;
        //    this.tanggal = tanggal;
        //    this.waktu = waktu;
        //    this.harga = harga;
        //    this.sisaDeposit = sisaDeposit;
        //    this.sisaKelas = sisaKelas;
        //}

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public double SisaDeposit
        {
            get { return sisaDeposit; }
            set { sisaDeposit = value; }
        }
    }
}
