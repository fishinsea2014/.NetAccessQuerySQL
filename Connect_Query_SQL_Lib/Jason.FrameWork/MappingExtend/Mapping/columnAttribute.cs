using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.FrameWork.MappingExtend
{
    [AttributeUsage(AttributeTargets.Property)] // Only decorate properties
    //Set an alias to a column when create corresponding object.
    public class columnAttribute :Attribute
    {
        

        public columnAttribute(string name)
        {
            this._Name = name;
        }

        private string _Name = null;

        public string GetColumnName()
        {
            return this._Name;
        }
    }
}
