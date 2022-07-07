namespace HouseManagementSystem.UI
{
    partial class fmrOwnerContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrOwnerContact));
            this.label23 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labhouseType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkphoneNo = new System.Windows.Forms.LinkLabel();
            this.linkemailAd = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(12, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(137, 21);
            this.label23.TabIndex = 74;
            this.label23.Text = "Contact the owner";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(352, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labhouseType
            // 
            this.labhouseType.AutoSize = true;
            this.labhouseType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labhouseType.Location = new System.Drawing.Point(13, 45);
            this.labhouseType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labhouseType.Name = "labhouseType";
            this.labhouseType.Size = new System.Drawing.Size(142, 17);
            this.labhouseType.TabIndex = 76;
            this.labhouseType.Text = "Owner Phone number :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 77;
            this.label1.Text = "Owner email address :";
            // 
            // linkphoneNo
            // 
            this.linkphoneNo.AutoSize = true;
            this.linkphoneNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkphoneNo.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkphoneNo.Location = new System.Drawing.Point(162, 45);
            this.linkphoneNo.Name = "linkphoneNo";
            this.linkphoneNo.Size = new System.Drawing.Size(88, 17);
            this.linkphoneNo.TabIndex = 78;
            this.linkphoneNo.TabStop = true;
            this.linkphoneNo.Text = "linkphoneNo";
            this.linkphoneNo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkphoneNo_LinkClicked);
            // 
            // linkemailAd
            // 
            this.linkemailAd.AutoSize = true;
            this.linkemailAd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkemailAd.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkemailAd.Location = new System.Drawing.Point(162, 92);
            this.linkemailAd.Name = "linkemailAd";
            this.linkemailAd.Size = new System.Drawing.Size(82, 17);
            this.linkemailAd.TabIndex = 79;
            this.linkemailAd.TabStop = true;
            this.linkemailAd.Text = "linkemailAd";
            this.linkemailAd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkemailAd_LinkClicked);
            // 
            // fmrOwnerContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(386, 153);
            this.Controls.Add(this.linkemailAd);
            this.Controls.Add(this.linkphoneNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labhouseType);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmrOwnerContact";
            this.Text = "fmrOwnerContact";
            this.Load += new System.EventHandler(this.fmrOwnerContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labhouseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkphoneNo;
        private System.Windows.Forms.LinkLabel linkemailAd;
    }
}