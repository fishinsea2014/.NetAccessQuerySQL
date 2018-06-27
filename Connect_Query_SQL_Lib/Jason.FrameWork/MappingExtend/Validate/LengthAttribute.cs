using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend.Validate
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LengthAttribute : AbstractValidateAttributes
    {

        private int _Min = 0;
        private int _Max = 0;
        public LengthAttribute(int min, int max)
        {
            this._Min = min;
            this._Max = max;
        }
        public override bool Validate(object value)//" "
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                int length = value.ToString().Length;
                if (length > this._Min && length < this._Max)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
