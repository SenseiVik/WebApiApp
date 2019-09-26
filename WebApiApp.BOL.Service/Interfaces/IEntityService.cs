using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.BOL.Service.Interfaces
{
    interface IEntityService<DtoObj> where DtoObj : class, new()
    {
        IEnumerable<DtoObj> GetAll();
        DtoObj Get(int id);
        DtoObj Add(DtoObj dto);

        void Update(DtoObj dto);
        void Delete(DtoObj dto);
        void Save();
    }
}
