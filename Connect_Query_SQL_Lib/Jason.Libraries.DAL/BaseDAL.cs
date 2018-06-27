using Jason.FrameWork;
using Jason.FrameWork.MappingExtend;
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
    public class BaseDAL
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
            string columnString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetColumnName()}]"));
            string sql = $"SELECT {columnString} FROM [{type.Name}] WHERE Id={id}";  //Must us [User] instead of User table
            T t = (T) Activator.CreateInstance(type);

            //Using can release the connection at the end of the segment.
            using (SqlConnection conn = new SqlConnection(StaticContants.SqlServerConnString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<T> list = this.ReaderToList<T>(reader);
                //t =  list !=null && list.Count>0 ? list[0] : null;
                t = list.FirstOrDefault();

                //if (reader.Read()) // Means get data from database, start reading
                //{
                //    foreach (var prop in type.GetProperties())
                //    {
                //        prop.SetValue(t, reader[prop.Name] is DBNull? null : reader[prop.Name] )
                //            ;
                //    }
                //}
            }
            return t;
        }

        public List<T> FindAll<T>() where T:BaseModel
        {
            Type type = typeof(T);
            //Generate a string like"[property name1], [property name2] ..."
            string columnString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetColumnName()}]"));
            string sql = $"SELECT {columnString} FROM [{type.Name}]";  //Must us [User] instead of User table
            List<T> list = new List<T>();

            //Using can release the connection at the end of the segment.
            using (SqlConnection conn = new SqlConnection(StaticContants.SqlServerConnString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                list = this.ReaderToList<T>(reader);
            }
            return list;
        }
        #region PrivateMethod
        private List<T> ReaderToList<T>(SqlDataReader reader) where T : BaseModel
        {
            List<T> list = new List<T>();
            while (reader.Read()) // Means get data from database, start reading
            {
                Type type = typeof(T);
                T t = (T)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    object oValue = reader[prop.GetColumnName()];
                    if (oValue is DBNull) oValue = null;
                    prop.SetValue(t, oValue);
                }

                //TODO : Enum and GUID type.
                list.Add(t);
            }
            return list;

        }

        #endregion
    }
}
