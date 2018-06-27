using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Jason.FrameWork
{
    /// <summary>
    ///Store the static contant in the project.
    /// </summary>
    public class StaticContants
    {
        public static string SqlServerConnString = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;


        private static string DALTypeDll = ConfigurationManager.AppSettings["DALTypeDll"];
        public static string DALDllName = DALTypeDll.Split(',')[1];
        public static string DALTypeName = DALTypeDll.Split(',')[0];


    }
}
