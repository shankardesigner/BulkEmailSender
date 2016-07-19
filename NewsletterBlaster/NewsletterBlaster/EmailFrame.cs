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
    public partial class EmailFrame : Form
    {
        public EmailFrame()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            mainForm mf = new mainForm();
            mf.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string c = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\3rd SEMESTER\Project\new\NewsletterBlaster\NewsletterBlaster\Resources\mydb.accdb";
            OleDbConnection con = new OleDbConnection(c);
            con.Open();
            //string query = "INSERT INTO AudienceInfo(FullName,Email Address,Address,Phone Number, City, Country) VALUES('" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtAddress.Text + "','" + txtPhoneNumber.Text + "','" + txtCity.Text + "','" + txtCountry.Text + "') ";
            //OleDbCommand cmd = new OleDbCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into AudienceInfo ([Item_Name],[Item_Price]) values (?,?);
           string query = "INSERT INTO AudienceInfo (Name,Email,Address,Phone, City, Country) VALUES('" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtAddress.Text + "','" +txtPhoneNumber.Text + "','" + txtCity.Text + "','" + txtCountry.Text + "') ";
            //string query = "INSERT INTO AudienceInfo(FullName,Email) VALUES('" + txtUserName.Text + "','" + txtEmail.Text + "') ";
            OleDbCommand cmd = new OleDbCommand(query, con);

            // cmd.Parameters.AddWithValue("@FullName", txtUserName.Text);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved Successfully!!");
        }
    }
}
