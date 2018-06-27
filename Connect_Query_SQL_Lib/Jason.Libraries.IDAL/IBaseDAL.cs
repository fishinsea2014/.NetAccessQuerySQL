using Jason.FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Libraries.IDAL
{
    /// <summary>
    /// Constraintion is for right reference
    /// </summary>
    public interface IBaseDAL
    {
        //find method must has int id.
        T Find<T>(int id) where T : BaseModel;

        List<T> FindAll<T>() where T : BaseModel;

        void Update<T> (T t) where T : BaseModel;

        
    }
}
