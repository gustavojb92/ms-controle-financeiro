using AutoMapper;
using ms_controle_financeiro.Model.DTOs.Balance;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<AddBalanceDTO, Balance>();
            CreateMap<Balance, ReadBalanceDTO>();
        }
    }
}