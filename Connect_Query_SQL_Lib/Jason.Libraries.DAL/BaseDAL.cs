using Jason.FrameWork;
using Jason.FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Libraries.DAL
{
    //Basic data access layer
    class BaseDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>


        public T Find<T>(int id) where T:BaseModel //The constraint is to ensure the right reference, int id.
        {
            Type type = typeof(T);
            //Generate a string like"[property name1], [property name2] ..."
            string columnString = string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"));
            string sql = $"SELECT {0} FROM [{type.Name}] WHERE Id={id}";  //Must us [User] instead of User table
            T t = (T) Activator.CreateInstance(type);

            //Using can release the connection at the end of the segment.
            using (SqlConnection conn = new SqlConnection(StaticContants.SqlServerConnString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) // Means get data from database, start reading
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, reader[prop.Name]);
                    }
                }
            }
            return default ( T );
        }
    }
}
