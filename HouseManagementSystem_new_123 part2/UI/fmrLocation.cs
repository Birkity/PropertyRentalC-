using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrLocation : Form
    {
        public fmrLocation()
        {
            InitializeComponent();
        }
        LocationBLL abl = new LocationBLL();
        LocationDAL locdal = new LocationDAL();
        CategoryDAL categoryDAL = new CategoryDAL();
        AddPostDAL dal = new AddPostDAL();
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmbCity.Text)
                || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox3.Text)
                || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox1.Text)
                || string.IsNullOrWhiteSpace(txtfamlandmark.Text))
            {
                label7.Visible = true;
                label7.Text = "Fill all the fields";

            }
            else
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
                abl.city = cmbCity.Text;
                abl.subcity = textBox2.Text;
                abl.district = textBox3.Text;
                abl.streetAddress = textBox1.Text;
                abl.famousLandmark = txtfamlandmark.Text;
                abl.hid = fmrAddPost.hid;
                abl.usid = addbl.user_id;
            }

            bool success = locdal.Insert(abl);

            if (success == true)
            {
                MessageBox.Show("Location of your house added Successfully.");
                this.Close();
                fmrPosts post = new fmrPosts();
                post.Show();

            }
            else
            {
                label7.Visible = true;
                label7.Text = "Failed to Add location of your house.";
              
            }
        }

        private void Clear()
        {
            cmbCity.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            txtfamlandmark.Text = "";
            textBox3.Text = "";
        }

        private void fmrLocation_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          


        }
    }
}
