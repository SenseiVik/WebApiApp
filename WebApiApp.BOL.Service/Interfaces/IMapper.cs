using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.BOL.Service.Interfaces
{
    public interface IMapper<Entity, DTO> where Entity : class, new() 
                                where DTO : class,new()
    {
        DTO GetDTO(Entity entity);
        Entity GetEntity(DTO dto);
    }
}
