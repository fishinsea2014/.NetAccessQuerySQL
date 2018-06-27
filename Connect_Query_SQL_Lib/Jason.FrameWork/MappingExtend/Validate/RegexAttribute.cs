using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend.Validate
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RegexAttribute : AbstractValidateAttributes
    {
        private string _RegexExpression = string.Empty;
        public RegexAttribute(string regex)
        {
            this._RegexExpression = regex;
        }

        public override bool Validate(object oValue)
        {
            if (oValue == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(oValue.ToString(), _RegexExpression);
            }
        }
    }
}
