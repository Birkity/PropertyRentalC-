using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HouseManagementSystem.UI
{
    public partial class fmrUserPost : Form
    {
        public fmrUserPost()
        {
            InitializeComponent();
        }
        AddPostDAL dal = new AddPostDAL();
        public static int getid;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            fmrHome home = new fmrHome();
            home.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Details")
            {
                dataGridView1.CurrentRow.Selected = true;
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                getid = id;
                new fmrUpdatePost(id).Show();
                this.Close();
                this.Refresh();

            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {
                dataGridView1.CurrentRow.Selected = true;
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();//housetype
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();//housedescription
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();//housestatus
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();//price
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();//userid
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();//hid


            }

            else
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult = MessageBox.Show(" ","Are you sure you want to delete your post ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AddPostDAL adal = new AddPostDAL();
                    dataGridView1.CurrentRow.Selected = true;
                    int uid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                    int hid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                    adal.DeleteHouse(uid, hid);

                    fmrUserPost user = new fmrUserPost();
                    user.Show();
                    this.Close();

                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Refresh(); 
                }
             

            }

        }

        private void fmrUserPost_Load(object sender, EventArgs e)
        {
            PostDAL pdal = new PostDAL();
            DataTable dt = pdal.Select();

            dataGridView1.DataSource = dt;
        }

       
       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            PostDAL dal = new PostDAL();
            if (keywords != null)
            {
                DataTable dt = dal.SearchPost(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;
            }
        }
        private void HouseShow(int uid, int hid)
        {
            string myconnstrng = "Server = BIRKITY; Database = HouseRental;" + "Integrated security = True;";

            SqlConnection connection = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {


                SqlCommand command = new SqlCommand("HouseShow", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@hid", hid);
                connection.Open();


                adapter.Fill(dt);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox2.Text = rdr["houseType"].ToString();
                    textBox2.Text = rdr["Housedescription"].ToString();
                    comboBox1.Text = rdr["HouseStatus"].ToString();
                    textBox4.Text = rdr["price"].ToString();
                    textBox3.Text = rdr["userid"].ToString();
                    textBox1.Text = rdr["houseId"].ToString();

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
            PostDAL ad = new PostDAL();
            AddPostDAL dal = new AddPostDAL();
            AddPostBLL bl = new AddPostBLL();
            if (ad.IsNumber(textBox4.Text))
            {
              
                bl.houseType = comboBox2.Text;
                bl.houseDescription = textBox2.Text;
                bl.status_home = comboBox1.Text;
                bl.price = (int)Convert.ToDouble(textBox4.Text);
                bl.hid = int.Parse(textBox1.Text);
                bl.user_id = int.Parse(textBox3.Text);

            }
            else
            {

                MessageBox.Show("Enter a number");
            }
            bool success = dal.UpdateHouse(bl);


            if (success == true)
            {
                fmrUserPost post = new fmrUserPost();
                post.Show();
                this.Close();
                MessageBox.Show("Updated Successfully.");
          

            }
            else
            {

                MessageBox.Show("Failed to update house.");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
