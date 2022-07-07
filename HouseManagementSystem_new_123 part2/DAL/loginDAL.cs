using HouseManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HouseManagementSystem.DAL
{
   class loginDAL
    {
        static string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

        public bool loginCheck(loginBLL l)
        {
      
            bool isSuccess = false;

         
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("logincheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);

                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
    }
}
