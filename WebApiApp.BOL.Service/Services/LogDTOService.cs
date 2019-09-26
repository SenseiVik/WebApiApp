using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.BOL.DTO;
using WebApiApp.BOL.Service.Interfaces;
using WebApiApp.DAL.Entities;

namespace WebApiApp.BOL.Service.Services
{
    public class LogDTOService : IEntityService<LogDTO>
    {
        BaseRepository<Log> baseRepository;
        IMapper<Log, LogDTO> mapper;

        public LogDTOService(BaseRepository<Log> baseRepository, IMapper<Log, LogDTO> mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public LogDTO Add(LogDTO dto)
        {
            var entity = mapper.GetEntity(dto);
            var createdEntity = baseRepository.Create(entity);
            return mapper.GetDTO(createdEntity);
        }

        public void Delete(LogDTO dto)
        {
            var entity = mapper.GetEntity(dto);
            baseRepository.Delete(entity);
        }

        public LogDTO Get(int id)
        {
            var entity = baseRepository.Get(id);
            return mapper.GetDTO(entity);
        }

        public IEnumerable<LogDTO> GetAll()
        {
            List<LogDTO> logsDTO = new List<LogDTO>();
            List<Log> logs = baseRepository.GetAll().ToList();

            foreach (var log in logs)
            {
                var dto = mapper.GetDTO(log);
                logsDTO.Add(dto);
            }

            return logsDTO;
        }

        public void Save()
        {
            baseRepository.Save();
        }

        public void Update(LogDTO dto)
        {
            var entity = mapper.GetEntity(dto);
            baseRepository.Update(entity);
        }
    }
}
