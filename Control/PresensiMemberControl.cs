using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnFun.dsFitnFunTableAdapters;
using System.Data;
using Menu = FitnFun.Entity.PresensiMember;

namespace FitnFun.Control
{
    class PresensiMemberControl
    {
        private ShowException SE = new ShowException();
        private TBL_PRESENSIMEMBERTableAdapter TPM = new TBL_PRESENSIMEMBERTableAdapter();
        private TBL_PENGELOLAAN_JADWALSENAMTableAdapter TJ = new TBL_PENGELOLAAN_JADWALSENAMTableAdapter();
        private TBL_TRANSAKSITableAdapter TT = new TBL_TRANSAKSITableAdapter();
        private TBL_PROMOTableAdapter TP = new TBL_PROMOTableAdapter();
        private TBL_MEMBERTableAdapter TM = new TBL_MEMBERTableAdapter();
        
        public DataTable showPresensi()
        {
            DataTable DT = null;
            try
            {
                DT = TPM.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public DataTable showPresensiLaporan(int id)
        {
            DataTable DT = null;
            try
            {
                DT = TPM.cetakstrukpresensi(id);
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
                TPM.InsertPresensiMember(M.Id, Convert.ToDateTime(M.Tanggal),M.Waktu, M.Kelas,M.Harga,M.SisaDeposit);              
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void addPresensiSenamPaket(Menu M)
        {

            try
            {
                TPM.InsertDepositSenamPaket(M.Id, Convert.ToDateTime(M.Tanggal), M.Waktu, M.Kelas, M.Harga, M.SisaDeposit,M.SisaKelas);
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

        public DataTable getKelasPromo()
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
       
        public string GetKelasPresensi(string Kategori)
        {
            string temp="";
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
       
        //public void UpdateDeposit(int idmember,string kelas)
        //{
        //    try
        //    {
        //        TPM.UpdateDeposit(idmember,kelas);
        //    }
        //    catch (Exception ex)
        //    {
        //        SE.ShowMessage(ex.ToString(), "Kesalahan");
        //    }
        //}

        public string getHarga(string kelas)
        {
            string tmp = "";
            try
            {
                tmp = TJ.GetHarga(kelas).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }

        public string getDeposit(int id)
        {
            string tmp = "";
            try
            {
                tmp = TT.GetJumlahDeposit(id).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }

        public string getDepositKelas(int id)
        {
            string tmp = "";
            try
            {
                tmp = TT.GetDepositKelas(id).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }

        public string updatedeposit(double sisa,int id)
        {
            string tmp = "";
            try
            {
                tmp = TT.UpdateDeposit(sisa,id).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }

        public string updateDepositKelas(double sisa, int id)
        {
            string tmp = "";
            try
            {
                tmp = TT.UpdateDepositKelas(sisa, id).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }

        public string CekIDMember(int id)
        {
            string tmp = "";
            try
            {
                tmp = TM.CekIDbyID(id).ToString();
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }
    }
}
