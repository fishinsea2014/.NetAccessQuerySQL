using Jason.FrameWork;
using Jason.Libraries.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Libraries.Factory
{
    public class DALFactory
    {
        /// <summary>
        /// Make the program fit different kinds of database, e.g. Orcle, mySql...
        /// </summary>
        static DALFactory()
        {
            Assembly assembly = Assembly.Load(StaticContants.DALDllName);
            DALType = assembly.GetType(StaticContants.DALTypeName);
        }

        private static Type DALType = null;
        public static IBaseDAL CreateInstance ()
        {
            return (IBaseDAL)Activator.CreateInstance(DALType);
        }

        //static DALFactory()
        //{
        //    Assembly assembly = Assembly.Load(StaticConstant.DALDllName);
        //    DALType = assembly.GetType(StaticConstant.DALTypeName);
        //}
        //private static Type DALType = null;
        //public static IBaseDAL CreateInstance()
        //{
        //    return (IBaseDAL)Activator.CreateInstance(DALType);
        //}
    }
}
