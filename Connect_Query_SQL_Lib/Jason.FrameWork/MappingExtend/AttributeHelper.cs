using Jason.FrameWork.MappingExtend.Validate;
using Jason.FrameWork.Model;
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

        public static bool Validate<T>(this T tModel) where T : BaseModel
        {
            Type type = tModel.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttributes),true))
                {
                    object[] attributeArray = prop.GetCustomAttributes(typeof(AbstractValidateAttributes), true);
                    foreach (AbstractValidateAttributes attribute in attributeArray)
                    {
                        if (!attribute.Validate(prop.GetValue(tModel)))
                        {
                            return false;
                            //throw new Exception($"{prop.Name} 's value-{prop.GetValue(tModel)} is incorrect."); //Tips where is the error.
                        }
                    }
                }
            }
            return true;
        }

    }
}
