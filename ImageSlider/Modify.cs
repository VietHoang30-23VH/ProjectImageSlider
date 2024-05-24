using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ImageSlider
{
    internal class Modify
    {
        public Modify() 
        {
            
        }
        SqlCommand sqlCommand; // truy van csdl
        SqlDataReader reader; // doc du lieu trong bang
        public List<Account> accounts(string query)
        {
            List<Account>  tks = new List<Account>();
            using (SqlConnection sql = Connection.GetSqlConnection())
            {
                sql.Open();
                sqlCommand = new SqlCommand(query, sql);
                reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    tks.Add(new Account(reader.GetString(0),reader.GetString(1)));
                }
                sql.Close();
            }
            return tks;
        }
        public void Commnad(string query) // dang ky tai khoan
        {
            using (SqlConnection sql = Connection.GetSqlConnection())
            {
                sql.Open();
                sqlCommand = new SqlCommand(query, sql);
                sqlCommand.ExecuteNonQuery();
                sql.Close();
            }
        }
    }
}
