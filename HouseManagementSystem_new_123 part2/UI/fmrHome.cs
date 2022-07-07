
using HouseManagementSystem.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrHome : Form
    {
        public fmrHome()
        {
            InitializeComponent();
        }
        public static int getid;
        public static int Ugetid;

        private void linkHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Show();

        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmrLogin fmrlog = new fmrLogin();
            fmrlog.Show();
            this.Close();
        }

        private void linkAddPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmrAddPost addPost = new fmrAddPost();
            addPost.Show();
            this.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmrProfile fp = new fmrProfile();
            fp.Show();
            this.Close();
        }

        private void fmrHome_Load(object sender, EventArgs e)
        {
            timerbackup.Start();

            HomeDAL dal = new HomeDAL();
            DataTable dt = dal.Select();
            dgHouse.DataSource = dt;

        }
      
      

        private void dgHouse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgHouse.Columns[e.ColumnIndex].Name == "Details")
            {
                dgHouse.CurrentRow.Selected = true;
                int id = int.Parse(dgHouse.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                int uid = int.Parse(dgHouse.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());

                getid = id;
                Ugetid = uid;

                new fmrDisplayHouse(getid).Show();
                this.Close();
                this.Refresh();

            }
          

        }

        private void linkPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmrUserPost post = new fmrUserPost();
            post.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBox1.Text;
            HomeDAL dal = new HomeDAL();
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgHouse.DataSource = dt;
                
            }
          
            else
            {
                DataTable dt = dal.Select();
                dgHouse.DataSource = dt;
            
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timerbackup_Tick(object sender, EventArgs e)
        {
            AddPostDAL dal = new AddPostDAL();
            
            bool success = dal.backupData();

         
        }
    }
    }

