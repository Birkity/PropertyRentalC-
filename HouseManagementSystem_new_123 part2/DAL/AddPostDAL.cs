using HouseManagementSystem.BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseManagementSystem.DAL
{
    class AddPostDAL
    {
        string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
        public bool Insert(AddPostBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("houseInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure; 

                cmd.Parameters.AddWithValue("@houseType", u.houseType);
                cmd.Parameters.AddWithValue("@price", u.price);
                cmd.Parameters.AddWithValue("@user_id", u.user_id);
                cmd.Parameters.AddWithValue("@houseDescription", u.houseDescription);
                cmd.Parameters.AddWithValue("@status", u.status_home);
                cmd.Parameters.AddWithValue("@hid", u.hid);

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
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public AddPostBLL GetIDFromUsername(string username)
        {
            AddPostBLL u = new AddPostBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {

                string sql = "SELECT userID FROM userInfo WHERE userName='" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                   SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure; 
                conn.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    u.user_id = int.Parse(dt.Rows[0]["userid"].ToString());
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

            return u;
        }

        public void DeleteHouse(int uid, int hid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteHouse", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@hid", hid);
                cmd.Parameters.AddWithValue("@user_id", uid);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();


                if (rows > 0)
                {
                
                }
                else
                {
                   
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


        }

        public bool ValidateIDExists(int hid)
        {
      
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);
           
            SqlCommand cmd = new SqlCommand("ValidateIDExists", conn);
            cmd.Parameters.AddWithValue("@hid", hid);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
           

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool backupData()
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("backup_db", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool ValidateUsernameExists(string username)
        {

            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand("Select userName from userInfo where userName = @username ", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@username", username);

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool UpdateHouse(AddPostBLL bl)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateHouse", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@houseType", bl.houseType);
                cmd.Parameters.AddWithValue("@price", bl.price);
                cmd.Parameters.AddWithValue("@houseDescription", bl.houseDescription);
                cmd.Parameters.AddWithValue("@status", bl.status_home);
                cmd.Parameters.AddWithValue("@hid", bl.hid);
                cmd.Parameters.AddWithValue("@userid", bl.user_id);

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
