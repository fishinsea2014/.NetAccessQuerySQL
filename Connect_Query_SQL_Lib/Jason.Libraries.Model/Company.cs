using Jason.FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Libraries.Model
{
    public class Company : BaseModel
    {
        public string Name { get; set; }

        public int CreatorId { get; set; }

        public DateTime CreateTime { get; set; }


        // ? means it could be empty. Use it to fit the data table
        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }
    }
}
