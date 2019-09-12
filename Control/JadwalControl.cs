using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnFun.dsFitnFunTableAdapters;
using System.Data;
using FitnFun.Entity;


namespace FitnFun.Control
{
    class JadwalControl
    {
        private TBL_PENGELOLAAN_JADWALSENAMTableAdapter TJ = new TBL_PENGELOLAAN_JADWALSENAMTableAdapter();
        private TBL_DATAPEGAWAITableAdapter TP = new TBL_DATAPEGAWAITableAdapter();
        private ShowException SE = new ShowException();

        public DataTable showJadwal()
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

        public DataTable searchJadwal(String Keyword)
         {

             DataTable DT = null;
             try
             {
                 DT = TJ.GetDataBy3(Keyword);
             }
             catch (Exception ex)
             {

                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
             return DT;
         }

        public void addJadwal(Jadwal J)
         {
             try
             {

                 TJ.InsertJadwal(Convert.ToDateTime(J.Tanggal), J.Waktu,J.Kelas, J.NamaInsrtuktur, J.Harga,J.Waktuselesai);
             }
             catch (Exception ex)
             {
                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
         }

        public void ediJadwal(Jadwal J, int idjadwal)
         {

             try
             {
                 TJ.UpdateJadwal(Convert.ToDateTime(J.Tanggal), J.Waktu, J.Kelas, J.NamaInsrtuktur, J.Harga, J.Waktuselesai, idjadwal);
             }
             catch (Exception ex)
             {
                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
         }

        public void deleteJadwal(int idmenu)
         {

             try
             {
                 TJ.DeleteJadwal(idmenu);
             }
             catch (Exception ex)
             {
                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
         }

        public DataTable getNama()
        {

            DataTable DT = null;
            try
            {
                DT = TP.GetDataBy5();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }
           
    }
    
}
