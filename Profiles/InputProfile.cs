using AutoMapper;
using ms_controle_financeiro.Model.DTOs.Input;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Profiles
{
    public class InputProfile : Profile
    {
        public InputProfile()
        {
            CreateMap<AddInputDTO, Input>();
            CreateMap<Input, ReadInputDTO>();
        }
    }
}