using HouseManagementSystem.BLL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HouseManagementSystem.DAL
{
    class ProfileDAL
    {
        public bool Delete(CreateBLL u)
        {

            bool isSuccess = false;
           string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
         
                SqlCommand cmd = new SqlCommand("DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@user_id", u.user_id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
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
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

       

        public bool Update(CreateBLL cb)
        {
            bool isSuccess = false;
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
              
  
                SqlCommand cmd = new SqlCommand("UpdateProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@first_name", cb.first_name);
                cmd.Parameters.AddWithValue("@last_name", cb.last_name);
                cmd.Parameters.AddWithValue("@user_name", cb.user_name);
                cmd.Parameters.AddWithValue("@password", cb.password);
                cmd.Parameters.AddWithValue("@contact", cb.contact);
                cmd.Parameters.AddWithValue("@gender", cb.gender);
                cmd.Parameters.AddWithValue("@email", cb.email);
                cmd.Parameters.AddWithValue("@date",cb.dateOfJoined);
                cmd.Parameters.AddWithValue("@userid", cb.user_id);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
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
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
    }
}
