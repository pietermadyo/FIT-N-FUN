using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnFun.dsFitnFunTableAdapters;
using System.Data;
using FitnFun.Entity;
using Menu = FitnFun.Entity.Transaksi;

namespace FitnFun.Control
{
    class TransaksiControl
    {
        private TBL_TRANSAKSITableAdapter TT = new TBL_TRANSAKSITableAdapter();
        private ShowException SE = new ShowException();
        private TBL_MEMBERTableAdapter TM = new TBL_MEMBERTableAdapter();
        private TBL_PROMOTableAdapter TP = new TBL_PROMOTableAdapter();

        public DataTable showTransaksiLaporanReguler(int id)
        {
            DataTable DT = null;
            try
            {
                DT = TT.cetaktransaksi(id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public DataTable showTransaksi()
        {

            DataTable DT = null;
            try
            {
                DT = TT.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public DataTable showTransaksiSenamPaket()
        {

            DataTable DT = null;
            try
            {
                DT = TT.GetDataByDepositKelas();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public void addTransaksi(Menu M)
        {
            try
            {               
                TT.InsertTransaksi(Convert.ToInt32(M.Id),Convert.ToDateTime(M.Tanggal),Convert.ToDouble(M.Deposit));
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void addTransaksiSenamPaket(Menu M)
        {
            try
            {
                TT.InsertSenamPaket(Convert.ToInt32(M.Id), Convert.ToDateTime(M.Tanggal), Convert.ToDouble(M.Deposit), Convert.ToDouble(M.DepositKelas),M.Jumlahaktivasi);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void addTransaksiJumlahAktivasi(Menu M)
        {
            try
            {
                TT.InsertJumlahAktifasi(Convert.ToInt32(M.Id), Convert.ToDateTime(M.Tanggal), Convert.ToDouble(M.Deposit), Convert.ToDouble(M.Jumlahaktivasi));
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        

        public void UpdateStatusMember(string aktif,string nama)
        {

            try
            {
                TM.UpdateStatus(aktif,nama);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void UpdateStatusMemberByID(string aktif, int id)
        {

            try
            {
                TM.UpdateStatusByID(aktif, id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void UpdateMasaAktif(int id)
        {

            try
            {
                TT.UpdateMasaAktif(id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public double getHargaPromo(string kelas)
        {
            double temp = 0;          
            try
            {
                temp = Convert.ToDouble(TP.getHargaPromo(kelas));
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return temp;
        }

        public DataTable getKelas()
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

        public string GetKelasPromo(string Kategori)
        {
            string temp = "";
            try
            {
                temp = TP.GetKelasPromo(Kategori);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return temp;
        }

        public double getSisaDeposit(int id)
        {
            double tmp = 0;
            try
            {
                double tmpp = Convert.ToDouble(TT.GetJumlahDeposit(id));
                if (tmpp == 0)
                {
                    tmp = 0;
                }
                else
                {
                    tmp = tmpp;
                }
            }
            catch (Exception e)
            {
                SE.ShowMessage(e.ToString(), "Kesalahan");
            }
            return tmp;
        }

        public double getSisaSenamPaket(int id)
        {
            double tmp = 0;
            try
            {
                double tmpp = Convert.ToDouble(TT.GetDepositKelas(id));
                if (tmpp == 0)
                {
                    tmp = 0;
                }
                else
                {
                    tmp = tmpp;
                }
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
