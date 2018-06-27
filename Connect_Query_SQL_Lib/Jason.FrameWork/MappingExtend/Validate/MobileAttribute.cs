using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend.Validate
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MobileAttribute : AbstractValidateAttributes
    {
        public override bool Validate(object oValue)
        {
            if (oValue == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(oValue.ToString(), @"^[1]+[3,5]+\d{9}");
            }
        }

    }
}
