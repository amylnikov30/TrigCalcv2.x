using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TrigCalc2.UI
{


    public partial class SplashScreen : Form
    {
        
        private const string link = "https://github.com/amylnikov30/TrigCalcv2.x";
        
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(link);
        }

        private void LoadingBarTimer_Tick(object sender, EventArgs e)
        {
            LoadingBar.Width += 3;
            if (LoadingBar.Size.Width == this.Size.Width)
            {
                LoadingBarTimer.Stop();


                this.Hide();

                TrigCalcUI ui = new TrigCalcUI();
                ui.ShowDialog();
                this.Close();
            }
        }

        public void OnStart()
        {
            LoadingBar.Width += 3;
            if (LoadingBar.Size.Width == this.Size.Width)
            {
                LoadingBarTimer.Stop();
                this.Hide();
            }
        }

        public static void ShutDown()
        {
            Application.Exit();
        }
    }
}
