namespace HouseManagementSystem.UI
{
    partial class fmrSplash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrSplash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labHouse = new System.Windows.Forms.Label();
            this.labtxt = new System.Windows.Forms.Label();
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.panelBG = new System.Windows.Forms.Panel();
            this.panelMovable = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 197);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labHouse
            // 
            this.labHouse.AutoSize = true;
            this.labHouse.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHouse.Location = new System.Drawing.Point(371, 70);
            this.labHouse.Name = "labHouse";
            this.labHouse.Size = new System.Drawing.Size(296, 50);
            this.labHouse.TabIndex = 1;
            this.labHouse.Text = "Property Rental";
            // 
            // labtxt
            // 
            this.labtxt.AutoSize = true;
            this.labtxt.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labtxt.Location = new System.Drawing.Point(459, 139);
            this.labtxt.Name = "labtxt";
            this.labtxt.Size = new System.Drawing.Size(208, 37);
            this.labtxt.TabIndex = 2;
            this.labtxt.Text = "Platform System";
            // 
            // timerSplash
            // 
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // panelBG
            // 
            this.panelBG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBG.Controls.Add(this.panelMovable);
            this.panelBG.Location = new System.Drawing.Point(0, 281);
            this.panelBG.Name = "panelBG";
            this.panelBG.Size = new System.Drawing.Size(730, 39);
            this.panelBG.TabIndex = 4;
            this.panelBG.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBG_Paint);
            // 
            // panelMovable
            // 
            this.panelMovable.BackColor = System.Drawing.Color.LimeGreen;
            this.panelMovable.Location = new System.Drawing.Point(8, 7);
            this.panelMovable.Name = "panelMovable";
            this.panelMovable.Size = new System.Drawing.Size(10, 25);
            this.panelMovable.TabIndex = 0;
            // 
            // fmrSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 385);
            this.Controls.Add(this.panelBG);
            this.Controls.Add(this.labtxt);
            this.Controls.Add(this.labHouse);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "fmrSplash";
            this.Text = "36";
            this.Load += new System.EventHandler(this.fmrSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBG.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labHouse;
        private System.Windows.Forms.Label labtxt;
        private System.Windows.Forms.Timer timerSplash;
        private System.Windows.Forms.Panel panelBG;
        private System.Windows.Forms.Panel panelMovable;
    }
}