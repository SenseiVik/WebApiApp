using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.BOL.DTO;
using WebApiApp.BOL.Service.Interfaces;
using WebApiApp.DAL.Entities;

namespace WebApiApp.BOL.Service.Mappers
{
    public class LogMapper : IMapper<Log, LogDTO>
    {
        public LogDTO GetDTO(Log entity)
        {
            return new LogDTO()
            {
                Id = entity.Id,
                Date = entity.Date,
                Request = entity.Request,
                RequestMethod = entity.RequestMethod,
                ResponseDataCount = entity.ResponseDataCount,
                ResponseStatus = entity.ResponseStatus
            };
        }

        public Log GetEntity(LogDTO dto)
        {
            return new Log()
            {
                Id = dto.Id,
                Date = dto.Date,
                Request = dto.Request,
                RequestMethod = dto.RequestMethod,
                ResponseDataCount = dto.ResponseDataCount,
                ResponseStatus = dto.ResponseStatus
            };
        }
    }
}
