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
    class PromoControl
    {
         private TBL_PROMOTableAdapter TP = new TBL_PROMOTableAdapter();
         private ShowException SE = new ShowException();

         public DataTable showPromo()
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
                 DT = TP.GetDataBy1(Keyword);
             }
             catch (Exception ex)
             {

                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
             return DT;
         }

         public void addMenu(Promo P)
         {
             try
             {
                 TP.InsertPromo(P.Nama,P.Kelas,P.Tanggal,P.Harga);
             }
             catch (Exception ex)
             {
                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
         }

         public void editMenu(Promo M, int idpromo)
         {

             try
             {
                 TP.UpdatePromo(M.Nama,M.Kelas,M.Tanggal,M.Harga,idpromo);
             }
             catch (Exception ex)
             {
                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
         }

         public void deleteMenu(int idmenu)
         {

             try
             {
                 TP.DeletePromo(idmenu);
             }
             catch (Exception ex)
             {
                 SE.ShowMessage(ex.ToString(), "Kesalahan");
             }
         }

    }
}
