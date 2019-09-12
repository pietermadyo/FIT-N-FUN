using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnFun.dsFitnFunTableAdapters;
using System.Data;
using Menu = FitnFun.Entity.PresensiInstruktur;


namespace FitnFun.Control
{
    class PresensiInstrukturControl
    {
        private ShowException SE = new ShowException();
        private TBL_PRESENSIINSTRUKTURTableAdapter TPI = new TBL_PRESENSIINSTRUKTURTableAdapter();
        private TBL_PENGELOLAAN_JADWALSENAMTableAdapter TJ = new TBL_PENGELOLAAN_JADWALSENAMTableAdapter();
        private TBL_DATAPEGAWAITableAdapter DP = new TBL_DATAPEGAWAITableAdapter(); 

        public DataTable showPresensiInstruktur()
        {

            DataTable DT = null;
            try
            {
                DT = TPI.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public void addPresensi(Menu M)
        {

            try
            {
                TPI.InsertpresensiInstruktur(M.Id,Convert.ToDateTime(M.Tanggal), Convert.ToDateTime(M.Waktu),M.Kelas,Convert.ToDateTime(M.WaktuTerlambat));
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public DataTable getKelas()
        {

            DataTable DT = null;
            try
            {
                DT = TJ.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public string GetKelasPresensi(string Kategori)
        {
            string temp = "";
            try
            {
                temp = TJ.GetKelas(Kategori);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return temp;
        }

        public string getWaktu(string kelas)
        {
            string temp = "";
            try
            {
                temp = TJ.getWaktu(kelas).ToString();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return temp;
        }

        public string CekIDInstruktur(int id)
        {
            string tmp = "";
            try
            {
                tmp = DP.CekIDInstruktur(id).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }
    }
}
