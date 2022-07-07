using HouseManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseManagementSystem.DAL
{
    class LocationDAL
    {
        string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
        public bool Insert(LocationBLL abl)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("LocationInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@city", abl.city);
                cmd.Parameters.AddWithValue("@subcity", abl.subcity);
                cmd.Parameters.AddWithValue("@district", abl.district);
                cmd.Parameters.AddWithValue("@streetAddress", abl.streetAddress);
                cmd.Parameters.AddWithValue("@famousLandmark", abl.famousLandmark);
                cmd.Parameters.AddWithValue("@houId", abl.hid);

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

        public bool updateLocation(LocationBLL loc)
        {
            bool isSuccess = false;
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {


                SqlCommand cmd = new SqlCommand("UpdateLocation", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@city", loc.city);
                cmd.Parameters.AddWithValue("@subcity", loc.subcity);
                cmd.Parameters.AddWithValue("@district", loc.district);
                cmd.Parameters.AddWithValue("@streetAddress", loc.streetAddress);
                cmd.Parameters.AddWithValue("@famousLandmark", loc.famousLandmark);
                cmd.Parameters.AddWithValue("@hid", loc.hid);


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
    }
}
