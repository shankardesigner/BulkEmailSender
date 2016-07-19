using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlaster
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            //Application.Run(new Welcome());
            //Form1 fm = new Form1();
            //this.Visible = false;
            //Timer myTimer = new Timer();
            //myTimer.Interval = (3000);
            //myTimer.Tick += new EventHandler(myTimer_Tick);
            //myTimer,start
            //this.Close();
            //this.Visible = false;
            //fm.Show();

            //Timer MyTimer = new Timer();
            //MyTimer.Interval = (3000); // 45 mins
            //MyTimer.Tick += new EventHandler(MyTimer_Tick);
            //MyTimer.Start();
            timer1.Enabled = true;
            timer1.Interval = 3000;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //this.Close();
            this.Visible = false;
            Form1 fm = new Form1();
            fm.Show();
        }

        //private void MyTimer_Tick(object sender, EventArgs e)
        //{

        //    Form1 fm = new Form1();
        //    fm.Show();
        //}
    }
}
