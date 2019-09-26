using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.Console
{
    class LogDb
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;initial catalog=WebApiApp;integrated security=True";
        string sql = "select * from [Log]";

        public LogDb()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
            }
        }

        public void Add(Log log)
        {
            DataRow row = ds.Tables[0].NewRow();
            row["Date"] = log.Date;
            row["Request"] = log.Request;
            row["RequestMethod"] = log.RequestMethod;
            row["ResponseDataCount"] = log.ResponseDataCount;
            row["ResponseStatus"] = log.ResponseStatus;

            ds.Tables[0].Rows.Add(row);
        }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
            }
        }
    }
}
