using AutoMapper;
using ms_controle_financeiro.Data;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Balance;
using ms_controle_financeiro.Model.Entities;


namespace ms_controle_financeiro.Domain
{
    public class BalanceDomain : IBalance
    {
        public readonly AppDBContext _context;

        public readonly IMapper _imapper;

        public BalanceDomain(AppDBContext contex, IMapper imapper)
        {
            _context = contex;
            _imapper = imapper;
        }
        public IEnumerable<ReadBalanceDTO> GetAll()
        {
            var balances = _context.Balances.ToList().OrderByDescending(x => x.Id);
            IEnumerable<ReadBalanceDTO> balanceDTO = _imapper.Map<List<ReadBalanceDTO>>(balances);
            return balanceDTO;

        }

        public ReadBalanceDTO GetById(int id)
        {
            var balance = _context.Balances.FirstOrDefault(x => x.Id == id);
            ReadBalanceDTO balanceDTO = _imapper.Map<ReadBalanceDTO>(balance);
            return balanceDTO;
        }

        public ReadBalanceDTO Post(AddBalanceDTO obj)
        {
            Balance balance = _imapper.Map<Balance>(obj);
            _context.Balances.Add(balance);
            _context.SaveChanges();
            ReadBalanceDTO balanceDTO = _imapper.Map<ReadBalanceDTO>(balance);
            return balanceDTO;
        }
        public ReadBalanceDTO Put(int id, AddBalanceDTO obj)
        {
            var balance = _context.Balances.FirstOrDefault(X => X.Id == id);
            if (balance == null) return null;

            _imapper.Map(obj, balance);
            _context.SaveChanges();
            ReadBalanceDTO balanceDTO = _imapper.Map<ReadBalanceDTO>(balance);
            return balanceDTO;
        }

        public bool Delete(int Id)
        {
            var deleteBalance = _context.Balances.FirstOrDefault(x => x.Id == Id);
            if (deleteBalance == null) return false;

            _context.Balances.Remove(deleteBalance);
            _context.SaveChanges();
            return true;
        }
    }
}