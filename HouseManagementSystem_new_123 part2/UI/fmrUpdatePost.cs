using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrUpdatePost : Form
    {
        int myid = 0;
        public fmrUpdatePost(int id)
        {
            myid = id;
            InitializeComponent();
        }
        AddPostDAL dal = new AddPostDAL();
        LocationBLL loc = new LocationBLL();
        PostDAL post = new PostDAL();


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmrUserPost_Load(object sender, EventArgs e)
        {
            int hid = fmrUserPost.getid;
            DisplayCategory(hid);
            DisplayLocation(hid);

        }

        private void DisplayCategory(int hid)
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
                    textbox.Text = rdr["numberOfLivingroom"].ToString();
                    textBox1.Text = rdr["numberOfBedroom"].ToString();
                    textBox3.Text = rdr["numberOfKitchen"].ToString();
                    textBox4.Text = rdr["numberOfFloors"].ToString();
                    textBox2.Text = rdr["numberOfBathroom"].ToString();
                    textBox5.Text = rdr["Features"].ToString();

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

        private void DisplayLocation(int hid)
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
                    textBox6.Text = rdr["city"].ToString();
                    textBox7.Text = rdr["subcity"].ToString();
                    textBox8.Text = rdr["district"].ToString();
                    textBox9.Text = rdr["steetAddress"].ToString();
                    textBox10.Text = rdr["famousLandmark"].ToString();


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
     

        

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
           

            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            PostBLL p = new PostBLL();
            PostDAL pdal = new PostDAL();

            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select FrontImage from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", addbl.user_id);
            cmd.Parameters.AddWithValue("@hid", fmrUserPost.getid);

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
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                        if (pictureBox3.Image == null)
                        {
                            pictureBox3.Image.Dispose();
                        }


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
            label6.Text = "";

            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
         

            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_living from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", addbl.user_id);
            cmd.Parameters.AddWithValue("@hid", fmrUserPost.getid);

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
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                        if (pictureBox3.Image == null)
                        {
                            pictureBox3.Image.Dispose();
                        }


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
            label6.Text = "";

            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
     

            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_bed from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", addbl.user_id);
            cmd.Parameters.AddWithValue("@hid", fmrUserPost.getid);

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
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                        if (pictureBox3.Image == null)
                        {
                            pictureBox3.Image.Dispose();
                        }


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
            label6.Text = "";

            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
         

            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_bath from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", addbl.user_id);
            cmd.Parameters.AddWithValue("@hid", fmrUserPost.getid);

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
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                        if (pictureBox3.Image == null)
                        {
                            pictureBox3.Image.Dispose();
                        }


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
            label6.Text = "";

            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
          
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select img_kitchen from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", addbl.user_id);
            cmd.Parameters.AddWithValue("@hid", fmrUserPost.getid);

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
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                        if (pictureBox3.Image == null)
                        {
                            pictureBox3.Image.Dispose();
                        }


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
            label6.Text = "";

            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
     

            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection con = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand("Select other from posts where us_id = @uid and hid = @hid", con);
            cmd.Parameters.AddWithValue("@uid", addbl.user_id);
            cmd.Parameters.AddWithValue("@hid", fmrUserPost.getid);

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
                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                        Image img = (Image)converter.ConvertFrom(photo_aray);
                        pictureBox3.Image = img;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Refresh();
                        if (pictureBox3.Image == null)
                        {
                            pictureBox3.Image.Dispose();
                        }


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

        private void btnupdatecategory_Click(object sender, EventArgs e)
        {
            CategoryBLL category = new CategoryBLL();
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            CategoryDAL adal = new CategoryDAL();
            if (string.IsNullOrWhiteSpace(textBox3.Text)
              || string.IsNullOrWhiteSpace(textBox4.Text)
              || string.IsNullOrWhiteSpace(textBox5.Text)
              || string.IsNullOrWhiteSpace(textbox.Text)
              || string.IsNullOrWhiteSpace(textBox1.Text)
              || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label9.Visible = true;
                label9.Text = "Fill all the fields";


            }
            else
            {
                if (post.IsNumber(textBox3.Text) && post.IsNumber(textBox4.Text) &&
                  post.IsNumber(textBox5.Text) && post.IsNumber(textBox2.Text)
                  && post.IsNumber(textBox1.Text) && post.IsNumber(textbox.Text))
                {
                    category.houseid = fmrUserPost.getid;
                    category.NlivingRoom = int.Parse(textbox.Text);
                    category.Nbedroom = int.Parse(textBox1.Text);
                    category.Nbathroom = int.Parse(textBox2.Text);
                    category.Nkitchen = int.Parse(textBox3.Text);
                    category.Nfloors = int.Parse(textBox4.Text);
                    category.Features = textBox5.Text;


                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "Enter a number only";
                }


              

            }

            bool success = adal.updateCategory(category);

            if (success == true)
            {
                MessageBox.Show("Update of property added Successfully.");

            }
            else
            {
                label9.Visible = true;
                label9.Text = "Failed to update a property.";
             
            }



        }

        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            LocationBLL loc = new LocationBLL();
            string loggedInUser = fmrLogin.loggedInUser;
            AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
            LocationDAL locdal = new LocationDAL();
            if (string.IsNullOrWhiteSpace(textBox6.Text)
              || string.IsNullOrWhiteSpace(textBox10.Text)
              || string.IsNullOrWhiteSpace(textBox9.Text)
              || string.IsNullOrWhiteSpace(textBox8.Text)
              || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                label8.Visible = true;
                label8.Text = "Fill all the fields";

            }
            else
            {

                loc.city = textBox6.Text;
                loc.subcity = textBox7.Text;
                loc.district = textBox8.Text;
                loc.streetAddress = textBox9.Text;
                loc.famousLandmark = textBox10.Text;
                loc.hid = fmrUserPost.getid;
            }

            bool success = locdal.updateLocation(loc);

            if (success == true)
            {
                MessageBox.Show("Update of property added Successfully.");

            }
            else
            {
                label8.Visible = true;
                label8.Text = "Failed to update a property.";
              
            }


        }

        private void btnimgupdate_Click(object sender, EventArgs e)
        {
            fmrUpdateImg imgupdate = new fmrUpdateImg();
            imgupdate.Show();
            this.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            fmrUserPost user = new fmrUserPost();
            user.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
