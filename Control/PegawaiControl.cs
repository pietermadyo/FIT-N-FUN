using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnFun.dsFitnFunTableAdapters;
using System.Data;
using Menu = FitnFun.Entity.Pegawai;

namespace FitnFun.Control
{
    class PegawaiControl
    {
        private TBL_DATAPEGAWAITableAdapter TP = new TBL_DATAPEGAWAITableAdapter();
        private TBL_RoleTableAdapter TR = new TBL_RoleTableAdapter();
        private TBL_USERTableAdapter TU = new TBL_USERTableAdapter();
        private ShowException SE = new ShowException();

        public DataTable showPegawai()
        {

            DataTable DT = null;
            try
            {
                DT = TP.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public DataTable searchMenu(String Keyword)
        {

            DataTable DT = null;
            try
            {
                DT = TP.GetDataBy3(Keyword);
            }
            catch (Exception ex)
            {

                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public void addPegawai(Menu M)
        {

            try
            {
                TP.InsertPegawai(M.Nama,M.Alamat,M.TanggalLahir,M.Email,M.NoHp,M.Idperan);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void addUser(Menu M,int idperan)
        {

            try
            {
                TU.InsertUser(M.Nama, M.TanggalLahir, idperan);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public DataTable getKategori()
        {

            DataTable DT = null;
            try
            {
                DT = TR.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public int GetIDKategori(string Kategori)
        {

           int temp = 0;
           try
           {
               temp = TR.GetIdPeran(Kategori).Value;
           }
           catch (Exception ex)
           {
               SE.ShowMessage(ex.ToString(), "Kesalahan");
           }
           return temp;
        }

        public void editPegawai(Menu M, int idpegawai)
        {

            try
            {
                TP.UpdatePegawai(M.Nama, M.Alamat, M.TanggalLahir, M.Email, M.NoHp, M.Idperan,idpegawai);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void deletePegawai(int idpegawai)
        {

            try
            {
                TP.DeletePegawai(idpegawai);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

    }
}
