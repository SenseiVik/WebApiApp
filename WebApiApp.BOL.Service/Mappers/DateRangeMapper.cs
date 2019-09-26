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
    public class DateRangeMapper : IMapper<DateRange, DateRangeDTO>
    {
        public DateRangeDTO GetDTO(DateRange entity)
        {
            return new DateRangeDTO()
            {
                Id = entity.Id,
                From = entity.From,
                To = entity.To
            };
        }

        public DateRange GetEntity(DateRangeDTO dto)
        {
            return new DateRange()
            {
                Id = dto.Id,
                From = dto.From,
                To = dto.To
            };
        }
    }
}
