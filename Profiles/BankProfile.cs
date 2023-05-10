using AutoMapper;
using ms_controle_financeiro.Model.DTOs.Bank;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BanksDTO, Banks>();
            CreateMap<Banks, BanksDTO>();
        }
    }
}