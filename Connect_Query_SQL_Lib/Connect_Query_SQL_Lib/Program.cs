using Jason.Libraries.DAL;
using Jason.Libraries.Factory;
using Jason.Libraries.IDAL;
using Jason.Libraries.Model;
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
           
            try
            {
                Console.WriteLine("===Start Project===");
                
                //IBaseDAL baseDAL = new BaseDAL();
                IBaseDAL baseDAL = DALFactory.CreateInstance();
                Company company = baseDAL.Find<Company>(1002);
                List<Company> listCompanies = baseDAL.FindAll<Company>();

                //User user = baseDAL.Find<User>(1);
                //List<User> list = baseDAL.FindAll<User>();

                company.Name = "Vodafone";
                baseDAL.Update<Company>(company);


                //Console.Read();


            }
            catch (Exception ex)
            {
                Console.WriteLine("=======Error Message=============");
                Console.WriteLine(ex);
                Console.WriteLine("=======End of Error Message=============");
            }

            Console.Read();
        }

        private static void Show<T> (T t)
        {
            //TODO show an object.
        }
    }
}



 //string connS = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JasonExer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Console.WriteLine("====Data base access and query====");
            //using (SqlConnection conn = new SqlConnection(connS))
            //{
            //    SqlCommand command = new SqlCommand("select * from [User]", conn);
            //    conn.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    if (reader.Read()) // Means get data from database, start reading
            //    {
            //        Console.WriteLine("database is ok");
            //    }
            //}
