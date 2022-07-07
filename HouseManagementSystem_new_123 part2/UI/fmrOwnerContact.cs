using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrOwnerContact : Form

    {
      
    
        public fmrOwnerContact()
        {
            InitializeComponent();
          
        }
        AddPostDAL dal = new AddPostDAL();
        CreateBLL cb = new CreateBLL();
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmrOwnerContact_Load(object sender, EventArgs e)
        {
           
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection connection = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {


                SqlCommand command = new SqlCommand("select telephoneNo, email from userInfo where userID = @userid", connection);
                command.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.Parameters.AddWithValue("@userid", fmrHome.Ugetid);
                connection.Open();


                adapter.Fill(dt);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    linkphoneNo.Text = rdr["telephoneNo"].ToString();
                    linkemailAd.Text = rdr["email"].ToString();
 
                }
                rdr.Close();

                int rows = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                connection.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkemailAd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkemailAd.LinkVisited = true;
            string email = linkemailAd.Text;
            System.Diagnostics.Process.Start($"mailto:{email}");
        }

        private void linkphoneNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
            linkphoneNo.LinkVisited = true;
            string phone = linkphoneNo.Text;
            System.Diagnostics.Process.Start($"www.truecaller.com/search/et/{phone}");
        }
    }
}
