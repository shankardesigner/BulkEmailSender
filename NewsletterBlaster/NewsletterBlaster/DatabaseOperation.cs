/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NewsletterBlaster
{
    public class DatabaseOperation
    {

        public OleDbConnection connection()
        {

            string conString = ConfigurationSettings.AppSettings["NewsLetterConnectionString"].ToString();
            OleDbConnection con = new OleDbConnection(conString);
            return con;
        }

    }
}
*/