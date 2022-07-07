
using System;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseManagementSystem.DAL
{
    class HomeDAL
    {
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("selectAllHouse", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public bool check(int hid)
        {
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetHouseInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@houseID", hid);
               

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

        public DataTable Search(string keywords)
        {
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM houseInfo WHERE houseId LIKE '%" + keywords + "%' OR houseType LIKE '%" + keywords + "%' OR Housedescription LIKE '%" + keywords + "%' OR HouseStatus LIKE '%" + keywords + "%'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
    }
}
