using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class ConnectionManager
    {
        public static SqlConnection NewCon;
        public static String Constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            try
            {
                NewCon = new SqlConnection(Constr);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return NewCon;
        }
    }
}
