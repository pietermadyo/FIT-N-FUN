using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnFun.dsFitnFunTableAdapters;

namespace FitnFun.Control
{
    class LoginControl
    {
        TBL_USERTableAdapter TU = new TBL_USERTableAdapter();

        public bool cekLogin(string user, string pass)
        {
            bool cek = false;
            try
            {
                if (TU.GetUser(user,pass).ToString()!="")
                    cek = true;
            }
            catch (Exception )
            {
                cek = false;
            }
            return cek;
        }


        public int GetRoleUser(string user, string pass)
        {
            int role = 0;
            try
            {
                role = int.Parse(TU.GetRole(user,pass).ToString());
            }
            catch (Exception )
            {
                role = 0;
            }
            return role;
        }
    }
    
}
