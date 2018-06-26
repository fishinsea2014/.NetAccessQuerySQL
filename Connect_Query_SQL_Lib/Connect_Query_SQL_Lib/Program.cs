using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Query_SQL_Lib
{
    class Program
    {
        static void Main(string[] args)
        {
            string connS = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JasonExer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Console.WriteLine("====Data base access and query====");
            using (SqlConnection conn = new SqlConnection(connS))
            {
                SqlCommand command = new SqlCommand("select * from [User]", conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) // Means get data from database, start reading
                {
                    Console.WriteLine("database is ok");
                }
            }

            Console.Read();
        }
    }
}
