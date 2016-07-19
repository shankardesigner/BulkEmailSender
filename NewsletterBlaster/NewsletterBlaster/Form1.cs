using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace NewsletterBlaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            


        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //open main form
            //this.Close();

            //this.Visible = false;
            // mainForm mf = new mainForm();
            // mf.Show();
            /*
            string c = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\3rd SEMESTER\Project\NewsletterBlaster\NewsletterBlaster\NewsletterBlaster\Resources\mydb.accdb";
            OleDbConnection con = new OleDbConnection(c);
            con.Open();
            string query = "INSERT INTO Users(FullName,Email) VALUES('" + txtUserName.Text + "','" + txtPassword.Text + "') ";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved Successfully!!");
            con.Close();

            */

            // OleDbCommand cmd = new OleDbCommand();
            // cmd.ExecuteNonQuery();

            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter User name and Password","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            try
            {
                //create connection
                /*string c = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\3rd SEMESTER\Project\new\NewsletterBlaster\NewsletterBlaster\Resources\mydb.accdb";
                OleDbConnection con = new OleDbConnection(c);
                con.Open();

                //string query = "SELECT userName, [password] FROM Users WHERE[userName]=? AND[password]=?";
                //OleDbCommand cmd = new OleDbCommand(query, con);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                //MessageBox.Show("userName");
                //cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT * FROM Users where Username='"+txtUserName+"' AND ;
                con.Close();*/

                this.Visible = false;
                mainForm mf = new mainForm();
                mf.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
