using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrDisplayHouse : Form
    {
        int myid = 0;
        public fmrDisplayHouse(int id)
        {
            myid = id;
            InitializeComponent();
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmrDisplayHouse_Load(object sender, EventArgs e)
        {
            int hid = fmrHome.getid;
            DisplayCategory(myid);
            DisplayLocation(myid);
      


        }

        public void DisplayCategory(int hid)
        {

            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection connection = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {


                SqlCommand command = new SqlCommand("DisplayCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.Parameters.AddWithValue("@hid", hid);
                connection.Open();


                adapter.Fill(dt);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                   label6.Text = rdr["numberOfLivingroom"].ToString();
                    label7.Text = rdr["numberOfBedroom"].ToString();
                    label9.Text = rdr["numberOfKitchen"].ToString();
                    label10.Text = rdr["numberOfFloors"].ToString();
                    label8.Text = rdr["numberOfBedroom"].ToString();
                    label11.Text = rdr["Features"].ToString();

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

        public void DisplayLocation(int hid)
        {
         

            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection connection = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {


                SqlCommand command = new SqlCommand("DisplayLocation", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.Parameters.AddWithValue("@hid", hid);
              
                connection.Open();


                adapter.Fill(dt);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    label17.Text = rdr["city"].ToString();
                    label18.Text = rdr["subcity"].ToString();
                    label19.Text = rdr["district"].ToString();
                    label20.Text = rdr["steetAddress"].ToString();
                    label21.Text = rdr["famousLandmark"].ToString();
                   

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

        private void button1_Click(object sender, EventArgs e)
        {
           
            label24.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select FrontImage from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid",fmrHome.Ugetid);
            cmd.Parameters.AddWithValue("@hid", fmrHome.getid);

            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "posts");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])ds.Tables[0].Rows[0][0];
                        if(photo_aray == null){
                            pictureBox3.Image = null;
                        }
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                      

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               if (con.State == ConnectionState.Open)
                    con.Close();
              
            }
          
        }

        private void btnLiving_Click(object sender, EventArgs e)
        {
          
            label24.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_living from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", fmrHome.Ugetid);
            cmd.Parameters.AddWithValue("@hid", fmrHome.getid);

            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "posts");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])ds.Tables[0].Rows[0][0];
                        if (photo_aray == null)
                        {
                            pictureBox3.Image = null;
                        }
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                     

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
              
                   
                
                if (con.State == ConnectionState.Open)
                    con.Close();

            }
          
        }

        private void btnbed_Click(object sender, EventArgs e)
        {
  
            label24.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_bed from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", fmrHome.Ugetid);
            cmd.Parameters.AddWithValue("@hid", fmrHome.getid);

            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "posts");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])ds.Tables[0].Rows[0][0];
                        if (photo_aray == null)
                        {
                            pictureBox3.Image = null;
                        }
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                     

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
              
   
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
           
        }

        private void btnbath_Click(object sender, EventArgs e)
        {
          
            label24.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_bath from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", fmrHome.Ugetid);
            cmd.Parameters.AddWithValue("@hid", fmrHome.getid);

            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "posts");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])ds.Tables[0].Rows[0][0];
                        if (photo_aray == null)
                        {
                            pictureBox3.Image = null;
                        }
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                    


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
         
        }

        private void btnkitchen_Click(object sender, EventArgs e)
        {
           
            label24.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_kitchen from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", fmrHome.Ugetid);
            cmd.Parameters.AddWithValue("@hid", fmrHome.getid);

            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "posts");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])ds.Tables[0].Rows[0][0];
                        if (photo_aray == null)
                        {
                            pictureBox3.Image = null;
                        }
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                      

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
       
        }

        private void btnother_Click(object sender, EventArgs e)
        {
          
            label24.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select other from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", fmrHome.Ugetid);
            cmd.Parameters.AddWithValue("@hid", fmrHome.getid);

            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "posts");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])ds.Tables[0].Rows[0][0];
                        if (photo_aray == null)
                        {
                            pictureBox3.Image = null;
                        }
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                      


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
           
            fmrOwnerContact owner = new fmrOwnerContact();
            owner.Show();

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            fmrHome home = new fmrHome();
            home.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
