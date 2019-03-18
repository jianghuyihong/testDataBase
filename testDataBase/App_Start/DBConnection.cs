using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace testDataBase.App_Start
{
    public class DBConnection
    {
        OleDbConnection con = null;


        public DBConnection()
        {
           // con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|db.mdb;");
            string conn_str = System.Configuration.ConfigurationManager.AppSettings["ConnString"].ToString();
            con = new OleDbConnection(conn_str);
        }

        public OleDbConnection Con
        {
            get { return con; }
            set { con = value; }
        }
    }
}