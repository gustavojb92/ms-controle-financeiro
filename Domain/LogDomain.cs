using AutoMapper;
using ms_controle_financeiro.Data;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Log;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Domain
{
    public class LogDomain : ILog
    {
        public readonly AppDBContext _context;

        public readonly IMapper _imapper;

        public LogDomain(AppDBContext contex, IMapper imapper)
        {
            _context = contex;
            _imapper = imapper;
        }

        public IEnumerable<ReadLogDTO> GetAll()
        {
            var logs = _context.Logs.ToList().OrderByDescending(x => x.Id);
            IEnumerable<ReadLogDTO> logsDTOs = _imapper.Map<List<ReadLogDTO>>(logs);
            return logsDTOs;

        }

        public ReadLogDTO GetById(int id)
        {
            var log = _context.Logs.FirstOrDefault(x => x.Id == id);
            ReadLogDTO logDTO = _imapper.Map<ReadLogDTO>(log);
            return logDTO;
        }

        public ReadLogDTO Post(AddLogDTO obj)
        {
            Log log = _imapper.Map<Log>(obj);
            _context.Logs.Add(log);
            _context.SaveChanges();
            ReadLogDTO logDTO = _imapper.Map<ReadLogDTO>(log);
            return logDTO;
        }

        public ReadLogDTO Put(int id, AddLogDTO obj)
        {
            var log = _context.Logs.FirstOrDefault(x => x.Id == id);

            if (log == null) return null;

            _imapper.Map(obj, log);
            _context.SaveChanges();
            ReadLogDTO logDTO = _imapper.Map<ReadLogDTO>(log);
            return logDTO;
        }

        public bool Delete(int Id)
        {
            var log = _context.Logs.FirstOrDefault(x => x.Id == Id);
            if (log == null) return false;
            _context.Logs.Remove(log);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ReadLogDTO> Search(FilterLogDTO period)
        {
            var logs = _context.Logs.Where(log => log.TransitionDate > period.InitialDate && log.TransitionDate < period.FinalDate).ToList().OrderByDescending(log => log.TransitionDate);
            IEnumerable<ReadLogDTO> logsDTO = _imapper.Map<List<ReadLogDTO>>(logs);
            return logsDTO;
        }
    }
}