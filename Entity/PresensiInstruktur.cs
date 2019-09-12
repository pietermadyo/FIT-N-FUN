﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnFun.Entity
{
    class PresensiInstruktur
    {
        private int id;              
        private string tanggal;
        private string waktu;
        private string kelas ;
        private string waktuTerlambat;


        public PresensiInstruktur(int id, string tanggal, string waktu, string kelas, string waktuTerlambat)
        {
            this.id = id;
            this.kelas = kelas;
            this.tanggal = tanggal;
            this.waktu = waktu;
            this.waktuTerlambat = waktuTerlambat;
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

        public string Kelas
        {
            get { return kelas; }
            set { kelas = value; }
        }

        public string WaktuTerlambat
        {
            get { return waktuTerlambat; }
            set { waktuTerlambat = value; }
        }
    }
}
