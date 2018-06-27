using Jason.FrameWork.MappingExtend;
using Jason.FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Libraries.Model
{
    public class User: BaseModel
    {
        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        //public int State { get; set; }

            //Mapping to the state column in database.
        [columnAttribute("state")]
        public int Status { get; set; }

        public int UserType { get; set; }

        public DateTime LastLoginTime { get; set; }

        public int CreatorId { get; set; }
        public DateTime CreateTime { get; set; }

        public int LastModifierId { get; set; }

        public DateTime LastModifyTime { get; set; }
    }
}
