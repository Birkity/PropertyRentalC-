using HouseManagementSystem.BLL;
using HouseManagementSystem.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HouseManagementSystem.DAL
{
    class PostDAL
    {
        public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public const string str = @"^[A-Z][a-zA-Z]*$";
        string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
        public bool Insertliving(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertImageliving", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@img_living", p.Img_living);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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

        internal bool InsertFront(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertImageFront", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FrontImage", p.frontimg);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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

        public DataTable SearchPost(string keywords)
        {
            AddPostDAL dal = new AddPostDAL();  
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM houseInfo WHERE houseId LIKE '%" + keywords + "%' and  userid = @userid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userid", addbl.user_id);

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

        internal DataTable Select()
        {
            AddPostDAL dal = new AddPostDAL();
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);

            DataTable dt = new DataTable();
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from houseInfo where userID = @userid", conn);
                cmd.Parameters.Add("@userid", addbl.user_id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.Text;

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

        internal bool InsertBed(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertImagebed", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@img_bed", p.Img_bed);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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

        internal bool InsertBath(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertImageBath", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@img_bath", p.Img_bath);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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

        internal bool InsertKitchen(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertImageKitchen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@img_kitchen", p.Img_kitchen);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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

        internal bool InsertOther(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertImageOther", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@other", p.other_img);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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
        public bool updateliving(PostBLL p)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateImageFront", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@img_living", p.Img_living);
                cmd.Parameters.AddWithValue("@dateOfPost", p.dateOfPost);
                cmd.Parameters.AddWithValue("@usid", p.uid);
                cmd.Parameters.AddWithValue("@hid", p.hid);

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
             //   MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;

        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public bool IsPhoneNbr(string number)
        {
            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }

       public bool IsString(string value)
        {
            if (Regex.IsMatch(value, "^[a-z]+$", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(text);
        }
    }
}
