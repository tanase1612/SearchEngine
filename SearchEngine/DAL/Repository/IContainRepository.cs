using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository
{
    public interface IContainRepository
    {
        IEnumerable<Contain> GetAllContains();

        Contain GetContain(int id);
        Contain CreateContain(Contain contain);
        //bool UpdateContain(Contain contain);

        void DeleteContain(int id);
    }
}
