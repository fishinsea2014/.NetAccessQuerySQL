using Jason.FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jason.FrameWork.MappingExtend;

namespace Jason.Libraries.DAL
{
    public class TSqlHelper<T> where T: BaseModel
    {
        static TSqlHelper()
        {
            Type type = typeof(T);
            string columnString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetColumnName()}]"));
            FindSqlStr = $"SELECT {columnString} FROM [{type.Name}] WHERE Id =";
            FindAllSqlStr = $"SELECT {columnString} FROM [{type.Name}]";
        }

        public static string FindSqlStr = null;
        public static string FindAllSqlStr = null;
        //TODO Add delete, update, insert...

    }
}
