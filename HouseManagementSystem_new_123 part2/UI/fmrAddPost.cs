using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Collections.Generic;

using System.Windows.Forms;


namespace HouseManagementSystem.UI
{
    public partial class fmrAddPost : Form
    {
        public fmrAddPost()
        {
            InitializeComponent();
        }
        AddPostBLL u = new AddPostBLL();
        AddPostDAL dal = new AddPostDAL();
        CategoryBLL category = new CategoryBLL();
        CategoryDAL categoryDAL = new CategoryDAL();
        PostDAL post = new PostDAL();

        public static int hid;

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            fmrHome home = new fmrHome();
            home.Show();
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
            private void btnUpdate_Click(object sender, EventArgs e)
        {
          
          
                if (string.IsNullOrWhiteSpace(comboBox1.Text)
                    || string.IsNullOrWhiteSpace(comboBox2.Text)
                    || string.IsNullOrWhiteSpace(comboBox1.Text)
                    || string.IsNullOrWhiteSpace(textBox2.Text)
                    || string.IsNullOrWhiteSpace(textBox7.Text)
                    || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                label20.Visible = true;
                    label20.Text  = "Fill all the fields";

                }
                else
             {
                if (!dal.ValidateIDExists(int.Parse(textBox7.Text)))
                {
                    label20.Visible = true;
                    label20.Text = "House Number taken. Try again.";
                }
                else
                {
                    if (post.IsNumber(textBox2.Text))
                    {
                        string loggedInUser = fmrLogin.loggedInUser;
                        AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
                        fmrProfile profile = new fmrProfile();
                        u.hid = int.Parse(textBox7.Text);
                        u.houseType = comboBox2.Text;
                        u.price = int.Parse(textBox2.Text);
                        u.status_home = comboBox1.Text;
                        u.user_id = addbl.user_id;
                        u.houseDescription = txtHouse.Text;
                        hid = u.hid;

                    }
                    else
                    {
                        label20.Visible = true;
                        label20.Text = "Enter a number only";
                    }
                   
                }

             }
              


            bool success = dal.Insert(u);

            if (success == true)
            {
                MessageBox.Show("New House added Successfully.");
                Enabled_txtbox();

            }
            else
            {
               
            }

        }

        public void Enabled_txtbox()
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            checkedListBox1.Enabled = true;
            textBox1.Enabled = true;
        }

        private void Clear()
        {
            comboBox2.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            txtHouse.Text = "";
            checkedListBox1.Text = "";
            textBox7.Text = " ";

        }



        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
             string features = "";
          
            var selectedLangs = new List<string>();

            foreach (var lang in checkedListBox1.CheckedItems)
            {
                selectedLangs.Add(lang.ToString());
            }
            features = string.Join(", ", selectedLangs);
            if (string.IsNullOrWhiteSpace(textBox3.Text)
                || string.IsNullOrWhiteSpace(textBox4.Text)
                || string.IsNullOrWhiteSpace(textBox5.Text)
                || string.IsNullOrWhiteSpace(textBox6.Text)
                || string.IsNullOrWhiteSpace(textBox1.Text)
                || string.IsNullOrWhiteSpace(checkedListBox1.Text))
            {
                label21.Visible = true;
                label21.Text = "Fill all the fields";

            }
            else
            {
                
                if (post.IsNumber(textBox3.Text) && post.IsNumber(textBox4.Text) &&
                    post.IsNumber(textBox5.Text) && post.IsNumber(textBox6.Text)
                    && post.IsNumber(textBox1.Text))
                {
                    category.Nbedroom = int.Parse(textBox3.Text);
                    category.Nbathroom = int.Parse(textBox4.Text);
                    category.Nkitchen = int.Parse(textBox5.Text);
                    category.NlivingRoom = int.Parse(textBox6.Text);
                    category.Nfloors = int.Parse(textBox1.Text);
                    category.Features = features;
                    category.houseid = fmrAddPost.hid;
                  

                }
                else
                {
                    label21.Visible = true;
                    label21.Text ="Enter a number only";
                 }
            }
    
            bool success = categoryDAL.Insert(category);

            if (success == true)
            {
                MessageBox.Show("New Category added to the house Successfully.");
                Clear();
                this.Close();
                fmrLocation loc = new fmrLocation();
                loc.Show();

            }
            else
            {
                
               
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectImage_Click_1(object sender, EventArgs e)
        {
           



        }
        


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHouse_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}