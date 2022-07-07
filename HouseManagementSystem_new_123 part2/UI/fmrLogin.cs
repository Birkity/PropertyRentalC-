using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrLogin : Form
    {
        public fmrLogin()
        {
            InitializeComponent();
        }
        AddPostDAL adal = new AddPostDAL();
        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedInUser;
        public static int loggedInId;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                label6.Visible = true;
                label6.Text = "Please fill all the values";
            }
            else
            {
                l.username = txtUsername.Text;
                l.password = txtPassword.Text;

                bool isSuccess = dal.loginCheck(l);

                if (isSuccess == true)
                {
                    AddPostBLL addbl = adal.GetIDFromUsername(loggedInUser);

                    loggedInUser = l.username;
                    loggedInId = addbl.user_id;

                    fmrHome home = new fmrHome();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed. Try Again.");

                }

            }


        }

        private void linkLabelCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmrCreate fcr = new fmrCreate();
            fcr.Show();
            this.Hide();
        }

        private void txtUsername_click(object sender, CancelEventArgs e)
        {
           

        }

        private void txtPassword_click(object sender, CancelEventArgs e)
        {

           
        }

        private void fmrLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
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
