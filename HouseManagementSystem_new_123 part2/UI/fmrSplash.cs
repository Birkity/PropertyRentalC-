using System;
using System.Windows.Forms;

namespace HouseManagementSystem.UI
{
    public partial class fmrSplash : Form
    {
        public fmrSplash()
        {
            InitializeComponent();
        }
        int move = 0;

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Interval = 20;
            panelMovable.Width += 5;

            move += 5;

            if (move == 640)
            {
                timerSplash.Stop();
                this.Hide();

                fmrLogin login = new fmrLogin();
                login.Show();
            }
        }

        private void fmrSplash_Load(object sender, EventArgs e)
        {
            timerSplash.Start();
        }

        private void panelBG_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
