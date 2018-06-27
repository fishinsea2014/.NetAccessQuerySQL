using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend.Validate
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LongAttribute : AbstractValidateAttributes
    {
        private long _Min = 0;
        private long _Max = 0;
        public LongAttribute(long min, long max)
        {
            this._Min = min;
            this._Max = max;
        }
        public override bool Validate(object value)//" "
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (long.TryParse(value.ToString(), out long lResult))
                {
                    if (lResult > this._Min && lResult < this._Max)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
