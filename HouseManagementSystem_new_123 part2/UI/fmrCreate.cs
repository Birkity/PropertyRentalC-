using HouseManagementSystem.BLL;
using HouseManagementSystem.DAL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrCreate : Form
    {
        public fmrCreate()
        {
            InitializeComponent();
           
        }
        CreateBLL d = new CreateBLL();
        CreateDAL dal = new CreateDAL();

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
           
            txtFirstName.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PostDAL pro = new PostDAL();
            string str = "";
           
            d.dateOfJoined = DateTime.Now;
            if (string.IsNullOrWhiteSpace(textBox4.Text)
                || string.IsNullOrWhiteSpace(textBox5.Text)
                || string.IsNullOrWhiteSpace(txtFirstName.Text)
                || string.IsNullOrWhiteSpace(textBox1.Text)
                || string.IsNullOrWhiteSpace(comboBox1.Text)
                || string.IsNullOrWhiteSpace(textBox2.Text)
                 || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label6.Visible = true;
                label6.Text = "Please fill all the fields !";
            }
            else
            {
                if (pro.IsValidEmail(textBox5.Text))
                {
                    d.email = textBox5.Text;

                }
                else
                {
                    label6.Visible = true;
                    label6.Text = "Wrong email format";
                }
                if(pro.IsString(txtFirstName.Text) 
                    && pro.IsString(textBox1.Text)
                   )
                {
                    d.first_name = txtFirstName.Text;
                    d.last_name = textBox1.Text;
                  

                }
                else
                {
                    label6.Visible = true;
                    label6.Text = "Enter only string for names.";

                }
                if (pro.IsPhoneNbr(textBox4.Text))
                {
                    d.contact = textBox4.Text;

                }
                else
                {
                    label6.Visible = true;
                    label6.Text = "Wrong Phone number format";
                }
                
                

                
               
                if (comboBox1.Text == "female" || comboBox1.Text == "Female"
                    || comboBox1.Text == "male" || comboBox1.Text == "Male"
                  )
                {
                    d.gender = comboBox1.Text;

                }
                else
                {
                    label6.Visible = true;
                    label6.Text = "Wrong gender input";
                }
                AddPostDAL dala = new AddPostDAL();
                if (!dala.ValidateUsernameExists(textBox2.Text)
                    )
                {
                    label6.Visible = true;
                    label6.Text = "User name taken. Try different user name.";
                }
                else
                {
                    
                     d.user_name = textBox2.Text;
                  
                }
                if (pro.ValidatePassword(textBox3.Text, out str))
                {
                    d.password = textBox3.Text;
                }else
                {
                    label6.Visible = true;
                    label6.Text = str;

                }
                

                bool isSuccess = dal.Insert(d);


                if (isSuccess == true)
                {
                    MessageBox.Show("User created succesfully");
                    Clear();
                    fmrLogin log = new fmrLogin();
                    log.Show();
                    this.Close();
                   

                }
                else
                {
                   
                }
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmrCreate_Load(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_validitating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox1_click(object sender, CancelEventArgs e)
        {
           

        }

        private void textBox2_clicvalidate(object sender, CancelEventArgs e)
        {
            

        }

        private void textBox3_click(object sender, CancelEventArgs e)
        {
          
        }

        private void textBox4_validate(object sender, CancelEventArgs e)
        {
           
        }

        private void textBox5_validate(object sender, CancelEventArgs e)
        {
        }

        private void comboBox1_box(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            fmrLogin login = new fmrLogin();
            login.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
