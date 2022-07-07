using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrUpdateImg : Form
    {
        public fmrUpdateImg()
        {
            InitializeComponent();
        }
        string imageName = "no-image.jpg";
        string sourcePath = "";
        string destinationPath = "";

        private bool btnimghouses = false;
        private bool btnimglivings = false;
        private bool btnimgbeds = false;
        private bool btnimgbaths = false;
        private bool btnimgkitchens = false;
        private bool btnimgothers = false;

        PostBLL p = new PostBLL();
        PostDAL pdal = new PostDAL();
        AddPostDAL dal = new AddPostDAL();

        private void fmrUpdateImg_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            int hid = fmrUserPost.getid;
            fmrUpdatePost post = new fmrUpdatePost(hid);
            post.Show();
        }
        public void Displayimg()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files Only (*.jpg; *.jpeg; *.png; *.gif| *.jpg; *.jpeg; *.png; *.gif)";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    pictureBox1.Image = new Bitmap(open.FileName);
                    string ext = Path.GetExtension(open.FileName);
                    string name = Path.GetFileNameWithoutExtension(open.FileName);
                    Guid g = new Guid();
                    g = Guid.NewGuid();
                    imageName = "" + name + g + ext;
                    sourcePath = open.FileName;
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                    destinationPath = paths + "\\images\\" + imageName;
                }
            }
        }

        private void btnimgliving_Click(object sender, EventArgs e)
        {
            btnimglivings = true;
            Displayimg();
            btnimghouses = false;
            btnimgbeds = false;
            btnimgbaths = false;
            btnimgkitchens = false;
            btnimgothers = false;
        }

        private void btnimghouse_Click(object sender, EventArgs e)
        {
            Displayimg();
            btnimghouses = true;
            btnimglivings = false;
            btnimgbeds = false;
            btnimgbaths = false;
            btnimgkitchens = false;
            btnimgothers = false;
        }

        private void btnimgbed_Click(object sender, EventArgs e)
        {
            btnimgbeds = true;
            Displayimg();
            btnimghouses = false;
            btnimglivings = false;
            btnimgbaths = false;
            btnimgkitchens = false;
            btnimgothers = false;
        }

        private void btnimgbath_Click(object sender, EventArgs e)
        {
            btnimgbaths = true;
            Displayimg();
            btnimghouses = false;
            btnimglivings = false;
            btnimgbeds = false;
            btnimgkitchens = false;
            btnimgothers = false;
        }

        private void btnimgkitchen_Click(object sender, EventArgs e)
        {
            btnimgkitchens = true;
            Displayimg();
            btnimghouses = false;
            btnimglivings = false;
            btnimgbeds = false;
            btnimgbaths = false;
            btnimgothers = false;
        }

        private void btnimgother_Click(object sender, EventArgs e)
        {
            btnimgothers = true;
            Displayimg();
            btnimghouses = false;
            btnimglivings = false;
            btnimgbeds = false;
            btnimgbaths = false;
            btnimgkitchens = false;
        }

        private void btnSaveimg_Click(object sender, EventArgs e)
        {
            PostDAL pdal = new PostDAL();
            PostBLL p = new PostBLL();
            bool isSuccesss = false;
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            if (btnimghouses == true)
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
                p.dateOfPost = DateTime.Now;
                p.hid = fmrUserPost.getid;
                p.uid = addbl.user_id;
                p.frontimg = arr;

                isSuccesss = pdal.InsertFront(p);

            }
            if (btnimgbeds == true)
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);

                p.dateOfPost = DateTime.Now;
                p.hid = fmrUserPost.getid;
                p.uid = addbl.user_id;
                p.Img_bed = arr;

                isSuccesss = pdal.InsertBed(p);


            }
            if (btnimgbaths == true)
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);

                p.dateOfPost = DateTime.Now;
                p.hid = fmrUserPost.getid;
                p.uid = addbl.user_id;
                p.Img_bath = arr;
                isSuccesss = pdal.InsertBath(p);

            }
            if (btnimgkitchens == true)
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
                p.dateOfPost = DateTime.Now;
                p.hid = fmrUserPost.getid;
                p.uid = addbl.user_id;
                p.Img_kitchen = arr;
                isSuccesss = pdal.InsertKitchen(p);

            }
            if (btnimglivings == true)
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);
                p.dateOfPost = DateTime.Now;
                p.hid = fmrUserPost.getid;
                p.uid = addbl.user_id;
                p.Img_living = arr;
                isSuccesss = pdal.updateliving(p);

            }
            if (btnimgothers == true)
            {
                string loggedInUser = fmrLogin.loggedInUser;
                AddPostBLL addbl = dal.GetIDFromUsername(loggedInUser);

                p.dateOfPost = DateTime.Now;
                p.hid = fmrUserPost.getid;
                p.uid = addbl.user_id;
                p.other_img = arr;
                isSuccesss = pdal.InsertOther(p);

            }




            if (isSuccesss == true)
            {
                label7.Visible = true;
               label7.Text = "Images of your house Updated Successfully";


            }
            else
            {
                MessageBox.Show("Failed to Add images.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Close();
                fmrHome home = new fmrHome();
                home.Show();
            }
        }

        private void linkback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            int id = 0;
            fmrUpdatePost updatePost = new fmrUpdatePost(id);
            updatePost.Show();
        }
    }
}
