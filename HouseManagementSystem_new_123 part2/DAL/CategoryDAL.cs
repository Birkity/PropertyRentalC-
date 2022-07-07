using HouseManagementSystem.BLL;
using System;
using System.Data;
using System.Data.SqlClient;


namespace HouseManagementSystem.DAL
{
    class CategoryDAL
    {
        string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
        public bool Insert(CategoryBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
              

                SqlCommand cmd = new SqlCommand("InsertCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nbedroom", u.Nbedroom);
                cmd.Parameters.AddWithValue("@Nbathroom", u.Nbathroom);
                cmd.Parameters.AddWithValue("@Nkitchen", u.Nkitchen);
                cmd.Parameters.AddWithValue("@NlivingRoom", u.NlivingRoom);
                cmd.Parameters.AddWithValue("@NFloor", u.Nfloors);
                cmd.Parameters.AddWithValue("@feature", u.Features);
                cmd.Parameters.AddWithValue("@houseId", u.houseid);
         

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

        

        public bool updateCategory(CategoryBLL category)
        {
            bool isSuccess = false;
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {


                SqlCommand cmd = new SqlCommand("UpdateCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nlivingroom", category.NlivingRoom);
                cmd.Parameters.AddWithValue("@nbedroom", category.Nbedroom);
                cmd.Parameters.AddWithValue("@nbathroom", category.Nbathroom);
                cmd.Parameters.AddWithValue("@nkitchen", category.Nkitchen);
                cmd.Parameters.AddWithValue("@nfloors", category.Nfloors);
                cmd.Parameters.AddWithValue("@nfeatures", category.Features);
                cmd.Parameters.AddWithValue("@hid", category.houseid);


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
