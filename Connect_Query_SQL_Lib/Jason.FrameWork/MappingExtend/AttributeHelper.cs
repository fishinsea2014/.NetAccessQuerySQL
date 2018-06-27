using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend
{
    //Access attributes
    public static class AttributeHelper
    {
        public static string GetColumnName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(columnAttribute),true))
            {
                columnAttribute attribute = (columnAttribute)prop.GetCustomAttribute(typeof(columnAttribute), true);
                return attribute.GetColumnName();
            }

            return prop.Name;
        }

    }
}
