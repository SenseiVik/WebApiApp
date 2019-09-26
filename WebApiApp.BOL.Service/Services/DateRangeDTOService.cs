using GenericRepository;
using System.Collections.Generic;
using System.Linq;
using WebApiApp.BOL.DTO;
using WebApiApp.BOL.Service.Interfaces;
using WebApiApp.DAL.Entities;

namespace WebApiApp.BOL.Service.Services
{
    public class DateRangeDTOService : IEntityService<DateRangeDTO>
    {
        BaseRepository<DateRange> baseRepository;
        IMapper<DateRange, DateRangeDTO> mapper;

        public DateRangeDTOService(BaseRepository<DateRange> baseRepository, IMapper<DateRange, DateRangeDTO> mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public DateRangeDTO Add(DateRangeDTO dto)
        {
            var entity = mapper.GetEntity(dto);
            var result = baseRepository.Create(entity);
            return mapper.GetDTO(result);
        }

        public void Delete(DateRangeDTO dto)
        {
            var entity = mapper.GetEntity(dto);
            baseRepository.Delete(entity);
        }

        public DateRangeDTO Get(int id)
        {
            var entity = baseRepository.Get(id);
            var dto = mapper.GetDTO(entity);
            return dto;
        }

        public IEnumerable<DateRangeDTO> GetAll()
        {
            List<DateRangeDTO> dateRangesDTO = new List<DateRangeDTO>();
            List<DateRange> dateRanges = baseRepository.GetAll().ToList();

            foreach(var dateRange in dateRanges)
            {
                var dto = mapper.GetDTO(dateRange);
                dateRangesDTO.Add(dto);
            }

            return dateRangesDTO;
        }

        public void Save()
        {
            baseRepository.Save();
        }

        public void Update(DateRangeDTO dto)
        {
            var entity = mapper.GetEntity(dto);
            baseRepository.Update(entity);
        }
    }
}
