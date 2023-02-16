using AutoMapper;
using ms_controle_financeiro.Data;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Output;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Domain
{
    public class OutputDomain : IOutput
    {
        public readonly AppDBContext _context;

        public readonly IMapper _imapper;
        public readonly IBalance _IBalance;

        public OutputDomain(AppDBContext contex, IMapper imapper, IBalance iBalance)
        {
            _context = contex;
            _imapper = imapper;
            _IBalance = iBalance;
        }
        public IEnumerable<ReadOutputDTO> GetAll()
        {
            var outputs = _context.Outputs.ToList().OrderByDescending(x => x.Id);
            IEnumerable<ReadOutputDTO> outputsDTO = _imapper.Map<List<ReadOutputDTO>>(outputs);
            return outputsDTO;
        }

        public ReadOutputDTO GetById(int id)
        {
            var output = _context.Outputs.FirstOrDefault(x => x.Id == id);
            ReadOutputDTO outputDTO = _imapper.Map<ReadOutputDTO>(output);
            return outputDTO;
        }

        public ReadOutputDTO Post(AddOutputDTO obj)
        {
            Output output = _imapper.Map<Output>(obj);
            var balance = _context.Balances.FirstOrDefault(x => x.UserId == obj.UserId);
            var user = _context.Users.FirstOrDefault(x => x.Id == obj.UserId);
            var log = new Log();
            log.User = user.Name;
            log.Value = obj.Value;
            log.TransitionType = "Saída";
            log.TransitionDate = obj.OutputDate;
            balance.Value = balance.Value - obj.Value;
            _context.Outputs.Add(output);
            _context.Logs.Add(log);
            _context.SaveChanges();
            ReadOutputDTO outputDTO = _imapper.Map<ReadOutputDTO>(output);
            return outputDTO;
        }

        public ReadOutputDTO Put(int id, AddOutputDTO obj)
        {
            var output = _context.Outputs.FirstOrDefault(x => x.Id == id);

            if (output == null) return null;

            _imapper.Map(obj, output);
            _context.SaveChanges();
            ReadOutputDTO outputDTO = _imapper.Map<ReadOutputDTO>(output);
            return outputDTO;
        }
        public bool Delete(int Id)
        {
            var output = _context.Outputs.FirstOrDefault(x => x.Id == Id);
            if (output == null) return false;
            _context.Outputs.Remove(output);
            _context.SaveChanges();
            return true;
        }
    }
}