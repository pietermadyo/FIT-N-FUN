using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnFun.dsFitnFunTableAdapters;
using System.Data;
using Menu = FitnFun.Entity.Member;

namespace FitnFun.Control
{
    internal class MemberControl
    {
        private TBL_MEMBERTableAdapter TM = new TBL_MEMBERTableAdapter();
        private  TBL_USERTableAdapter TU = new TBL_USERTableAdapter();
        private ShowException SE = new ShowException();

        public DataTable showMenu()
        {

            DataTable DT = null;
            try
            {
                DT = TM.GetData();
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
                DT = TM.GetDataBy7(Keyword);
            }
            catch (Exception ex)
            {

                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
            return DT;
        }

        public void addMember(Menu M)
        {

            try
            {
                TM.InsertMember(M.Nama, Convert.ToDateTime(M.TglLahir), Convert.ToDateTime(M.TglMasuk), M.NoHp, M.Email, M.Alamat);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void addUser(Menu M)
        {

            try
            {
                TU.InsertUser(M.Nama, M.TglLahir,5);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void UpdateStatus(string aktif,string nama)
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

        

        public void UpdateMasaAktif()
        {

            try
            {
                TM.UpdateMasaAktivasi();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void editMember(Menu M, int idMember)
        {

            try
            {
                TM.UpdateMember(M.Nama,M.TglLahir,M.NoHp,M.Email,M.Alamat,idMember);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        public void deleteMember(int idmenu)
        {

            try
            {
                TM.DeleteMember(idmenu);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Kesalahan");
            }
        }

        
    }
}
