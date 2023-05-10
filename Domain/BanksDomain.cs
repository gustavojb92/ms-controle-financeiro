using AutoMapper;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Bank;

namespace ms_controle_financeiro.Domain
{
    public class BanksDomain : IBanks
    {
        public readonly IBanksRest _iBanksRest;
        public readonly IMapper _imapper;

        public BanksDomain(IBanksRest iBanksRest, IMapper imapper)
        {
            _iBanksRest = iBanksRest;
            _imapper = imapper;
        }

        public async Task<IEnumerable<BanksDTO>> GetAll()
        {
            var result = await _iBanksRest.GetAll();

            return _imapper.Map<List<BanksDTO>>(result);
        }

    }
}