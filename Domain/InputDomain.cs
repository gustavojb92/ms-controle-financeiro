using AutoMapper;
using ms_controle_financeiro.Data;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Input;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Domain
{
    public class InputDomain : IInput
    {
        public readonly AppDBContext _context;

        public readonly IMapper _imapper;


        public InputDomain(AppDBContext contex, IMapper imapper)
        {
            _context = contex;
            _imapper = imapper;
        }
        public IEnumerable<ReadInputDTO> GetAll()
        {
            var inputs = _context.Inputs.ToList().OrderByDescending(x => x.Id);
            IEnumerable<ReadInputDTO> inputsDTO = _imapper.Map<List<ReadInputDTO>>(inputs);
            return inputsDTO;
        }

        public ReadInputDTO GetById(int id)
        {
            var input = _context.Inputs.FirstOrDefault(x => x.Id == id);
            ReadInputDTO inputDTO = _imapper.Map<ReadInputDTO>(input);
            return inputDTO;
        }

        public ReadInputDTO Post(AddInputDTO obj)
        {
            Input input = _imapper.Map<Input>(obj);
            var balance = _context.Balances.FirstOrDefault(x => x.UserId == obj.UserId);
            var user = _context.Users.FirstOrDefault(x => x.Id == obj.UserId);
            var log = new Log();
            log.User = user.Name;
            log.Value = obj.Value;
            log.TransitionType = "Entrada";
            log.TransitionDate = obj.InputDate;
            balance.Value = balance.Value + obj.Value;
            _context.Inputs.Add(input);
            _context.Logs.Add(log);
            _context.SaveChanges();
            ReadInputDTO inputDTO = _imapper.Map<ReadInputDTO>(input);
            return inputDTO;
        }

        public ReadInputDTO Put(int id, AddInputDTO obj)
        {
            var input = _context.Inputs.FirstOrDefault(x => x.Id == id);

            if (input == null) return null;

            _imapper.Map(obj, input);
            _context.SaveChanges();
            ReadInputDTO inputDTO = _imapper.Map<ReadInputDTO>(input);
            return inputDTO;
        }
        public bool Delete(int Id)
        {
            var input = _context.Inputs.FirstOrDefault(x => x.Id == Id);
            if (input == null) return false;
            _context.Inputs.Remove(input);
            _context.SaveChanges();
            return true;
        }
    }
}