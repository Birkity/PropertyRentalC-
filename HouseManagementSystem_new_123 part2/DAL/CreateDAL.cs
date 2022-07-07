using HouseManagementSystem.BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseManagementSystem.DAL
{
   class CreateDAL
    {
        static string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
        public bool Insert(CreateBLL c)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {

                SqlCommand cmd = new SqlCommand("CreateUserproc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", c.first_name);
                cmd.Parameters.AddWithValue("@last_name", c.last_name);
                cmd.Parameters.AddWithValue("@user_name", c.user_name);
                cmd.Parameters.AddWithValue("@password", c.password);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@gender", c.gender);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@dateOfJoined", c.dateOfJoined);

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
        public CreateBLL GetIDFromUsername(string username)
        {
            CreateBLL u = new CreateBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {

                string sql = "SELECT userid FROM userInfo WHERE userName='" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    u.user_id = int.Parse(dt.Rows[0]["userid"].ToString());
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

            return u;
        }
    }
}
