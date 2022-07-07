using FakeItEasy;
using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace HouseManagementSystem.UI
{
    public partial class fmrProfile : Form
    {
        public fmrProfile()
        {
            InitializeComponent();
        }
        CreateBLL cb = new CreateBLL();
        CreateDAL createdal = new CreateDAL();
        ProfileDAL pdal = new ProfileDAL();
        AddPostDAL dal = new AddPostDAL();
        PostDAL post = new PostDAL();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            fmrHome home = new fmrHome();
            home.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            Clear();
        }

        private void Clear()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtUsername.Text = "";
            txtGender.Text = "";
            txtContact.Text = "";
            txtPassword.Text = "";
            textBox1.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            cb.user_id = addbl.user_id;
            bool success = pdal.Delete(cb);

            if (success == true)
            {
                MessageBox.Show("User Deleted Successfully.");
                Clear();
                this.Close();
                fmrLogin fmrLogin = new fmrLogin();
                fmrLogin.Show();
                fmrAddPost mf = new fmrAddPost();
                mf.Hide();
            }
        }

        private void fmrProfile_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            cb.user_id = addbl.user_id;

            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection connection = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                SqlCommand command = new SqlCommand("DisplayProfile", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.Parameters.AddWithValue("@userid", cb.user_id);
                connection.Open();


                adapter.Fill(dt);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    txtfirstname.Text = rdr["firstName"].ToString();
                    txtlastname.Text = rdr["lastName"].ToString();
                    txtUsername.Text = rdr["userName"].ToString();
                    txtPassword.Text = rdr["Upassword"].ToString();
                    txtContact.Text  = rdr["telephoneNo"].ToString();
                    txtGender.Text = rdr["gender"].ToString();
                    textBox1.Text = rdr["email"].ToString();

                }
                rdr.Close();

                int rows = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
               
            }
            finally
            {

                connection.Close();
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            cb.user_name = txtUsername.Text;
            cb.password = txtPassword.Text;
            cb.user_id = addbl.user_id;
         
            cb.dateOfJoined = DateTime.Now;
            if(post.IsValidEmail(textBox1.Text))
            {
                cb.email = textBox1.Text;

            }else
            {
                label6.Visible = true;
                label6.Text = "Wrong email format";
            }
            if (post.IsPhoneNbr(txtContact.Text))
            {
                cb.contact = txtContact.Text;

            }
            else
            {
                label6.Visible = true;
                label6.Text = "Wrong Phone number format";
            }
            if (post.IsString(txtfirstname.Text) && post.IsString(txtlastname.Text))
            {
                cb.first_name = txtfirstname.Text;
                cb.last_name = txtlastname.Text;

            }
            else
            {
                label6.Visible = true;
                label6.Text = "Wrong name format";
            }
            if (txtGender.Text == "female" || txtGender.Text == "Female" 
                || txtGender.Text == "male" || txtGender.Text == "Male"
                || txtGender.Text == "other" || txtGender.Text == "Other")
            {
                cb.gender = txtGender.Text;

            }
            else
            {
                label6.Visible = true;
                label6.Text = "Wrong gender input";

            }

            bool success = pdal.Update(cb);

            if (success == true)
            {
                fmrHome home = new fmrHome();
                home.Show();
                this.Close();

            }
        }
       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
