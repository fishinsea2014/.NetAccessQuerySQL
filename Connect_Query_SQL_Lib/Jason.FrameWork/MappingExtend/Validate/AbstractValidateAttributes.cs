using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend.Validate
{
    /// <summary>
    /// Base class for validating data.
    /// </summary>
    public abstract class AbstractValidateAttributes: Attribute
    {
        public abstract bool Validate(object value);
    }
}
