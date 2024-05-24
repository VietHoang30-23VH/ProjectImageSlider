using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ImageSlider
{
    internal class Connection
    {
        private static string strconnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Winform\ImageSlider\ImageSlider\Database1.mdf;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strconnection);
        }
    }
}
