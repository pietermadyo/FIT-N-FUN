using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class PresensiPegawai
    {
        private int id;
        private string tanggal;
        private string waktu;
        private int idperan;

        public PresensiPegawai(int id, string tanggal, string waktu, int idperan)
        {
            this.Id = id;
            this.Tanggal = tanggal;
            this.Waktu = waktu;
            this.Idperan = idperan;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public int Idperan
        {
            get { return idperan; }
            set { idperan = value; }
        }
    }
}
