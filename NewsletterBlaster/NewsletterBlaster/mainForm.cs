using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.OleDb;
using System.IO;

namespace NewsletterBlaster
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.AudienceInfo' table. You can move, or remove it, as needed.
            string c = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\3rd SEMESTER\Project\new\NewsletterBlaster\NewsletterBlaster\Resources\mydb.accdb";
            OleDbConnection con = new OleDbConnection(c);
            con.Open();
           
            //OleDbCommand command = new OleDbCommand();
            //command.Connection = con;
            //string query = "select * from AudienceInfo";
            //command.CommandText = query;

            //OleDbDataAdapter da = new OleDbDataAdapter(command);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            con.Close();
            // MessageBox.Show("Saved Successfully!!");
            //this.audienceInfoTableAdapter.Fill(this.appData.AudienceInfo);

        }


        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;



            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.SkyBlue, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Source Sans Pro", (float)15.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //txtReceiversEmail.Text = "";
            //txtReceiversEmail.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //txtReceiversEmail.Text = "";
            //txtReceiversEmail.Enabled = false;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            // if (browseTemplate.ShowDialog() == DialogResult.OK)
            //{
            //txtCheckFile.Text = browseTemplate.FileName.ToString();

            //}
            DialogResult result = browseTemplate.ShowDialog();
            if (result == DialogResult.Cancel) return;
            StreamReader sr = new StreamReader(browseTemplate.FileName);
            txtMsgBox.Text = sr.ReadToEnd();
            sr.Close();

            //OpenFileDialog dlg = new OpenFileDialog();
            //if(dlg.ShowDialog()==DialogResult.OK)
            //{

            // }
        }

        private void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("glorious.sb@gmail.com");
                //msg.To.Add(txtReceiversEmail.Text);
                //msg.To.ForEach(x => message.To.Add(x));
                //msg.To.Add("'glorious.sb@gmail.com','shankar.bhattarai@w3.co'");
                //MailAddressCollection.Equals.Enabled;
                //Array emailRecepents = new arra;
                //msg.To.Add("<glorious.sb@gmail.com>,<shankar.bhattarai@w3.co>");
                msg.To.Add(txtReceiversEmail.Text);

                 if(txtCheckFile.Text!="")
                 {
                     //msg.Attachments.Add(new Attachment(txtCheckFile.Text));
                    //System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment(browseTemplate.Text);
                    //msg.Attachments.Add(attachment);

                    //Attachment data = new Attachment(textBoxAttachment.Text);
                    //msg.Attachments.Add(data);



                }

                string c = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\3rd SEMESTER\Project\new\NewsletterBlaster\NewsletterBlaster\Resources\mydb.accdb";
                OleDbConnection con = new OleDbConnection(c);
                con.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter("select * from AudienceInfo", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                

                if (radioButton1.Checked)
                {
                    //msg.To.Add("<glorious.sb@gmail.com>,<shankar.bhattarai@w3.co>");
                    foreach (DataRow dr in dt.Rows)
                    {
                        //msg.To.Add("<"+dr["Email"].ToString()+">,");
                        msg.To.Add(dr["Email"].ToString());
                    }

                }
                if (radioButton2.Checked)
                {
                    msg.To.Add("jaspershankar@live.com");
                }
                
                msg.IsBodyHtml = true;
                //msg.Body = txtMsgBox.Text;
                msg.Body = txtMsgBox.Text;
                msg.Subject = txtSubject.Text;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("glorious.sb@gmail.com","shirish123");
                client.Send(msg);
                msg = null;

                MessageBox.Show("Success!!");
            }
            catch (Exception)
            {

                MessageBox.Show("Failed To send Email!!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            EmailFrame mf = new EmailFrame();
            mf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            EmailFrame mf = new EmailFrame();
            mf.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 mf = new Form1();
            mf.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            txtReceiversEmail.Text = "";
            txtMsgBox.Text = "";
            txtSubject.Text = "";
        }
    }
   
}
