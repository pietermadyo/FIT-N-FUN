using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnFun.Entity
{
    class Transaksi
    {
        private int id;
        private string tanggal;
        private double deposit;
        private double depositKelas;
        private double jumlahaktivasi;

        public double Jumlahaktivasi
        {
            get { return jumlahaktivasi; }
            set { jumlahaktivasi = value; }
        }

        //public Transaksi(int id, string tanggal, double deposit,double depositKelas)
        //{
        //    this.id = id;
        //    this.tanggal = tanggal;            
        //    this.deposit = deposit;
        //    //this.sisadeposit = sisadeposit;
        //    this.depositKelas = depositKelas;
        //}
        
        public string Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }
        
        public double Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //public double Sisadeposit
        //{
        //    get { return sisadeposit; }
        //    set { sisadeposit = value; }
        //}

        public double DepositKelas
        {
            get { return depositKelas; }
            set { depositKelas = value; }
        }
    }
}
