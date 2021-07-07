namespace TrigCalc2.UI
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.SplashImageBox = new System.Windows.Forms.PictureBox();
            this.GitHubLink = new System.Windows.Forms.LinkLabel();
            this.LoadingBarTimer = new System.Windows.Forms.Timer(this.components);
            this.LoadingBar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SplashImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashImageBox
            // 
            this.SplashImageBox.ErrorImage = null;
            this.SplashImageBox.Image = ((System.Drawing.Image)(resources.GetObject("SplashImageBox.Image")));
            this.SplashImageBox.InitialImage = null;
            this.SplashImageBox.Location = new System.Drawing.Point(0, -2);
            this.SplashImageBox.Name = "SplashImageBox";
            this.SplashImageBox.Size = new System.Drawing.Size(700, 400);
            this.SplashImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SplashImageBox.TabIndex = 0;
            this.SplashImageBox.TabStop = false;
            // 
            // GitHubLink
            // 
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.GitHubLink.LinkColor = System.Drawing.Color.White;
            this.GitHubLink.Location = new System.Drawing.Point(13, 359);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(40, 13);
            this.GitHubLink.TabIndex = 1;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "GitHub";
            this.GitHubLink.VisitedLinkColor = System.Drawing.Color.DarkGray;
            // 
            // LoadingBarTimer
            // 
            this.LoadingBarTimer.Enabled = true;
            this.LoadingBarTimer.Interval = 15;
            this.LoadingBarTimer.Tick += new System.EventHandler(this.LoadingBarTimer_Tick);
            // 
            // LoadingBar
            // 
            this.LoadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(132)))));
            this.LoadingBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(132)))));
            this.LoadingBar.Location = new System.Drawing.Point(0, 390);
            this.LoadingBar.Name = "LoadingBar";
            this.LoadingBar.Size = new System.Drawing.Size(25, 10);
            this.LoadingBar.TabIndex = 2;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.LoadingBar);
            this.Controls.Add(this.GitHubLink);
            this.Controls.Add(this.SplashImageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.SplashImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SplashImageBox;
        private System.Windows.Forms.LinkLabel GitHubLink;
        public System.Windows.Forms.Timer LoadingBarTimer;
        public System.Windows.Forms.Panel LoadingBar;
    }
}