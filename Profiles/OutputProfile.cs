using AutoMapper;
using ms_controle_financeiro.Model.DTOs.Output;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Profiles
{
    public class OutputProfile : Profile
    {
        public OutputProfile()
        {
            CreateMap<AddOutputDTO, Output>();
            CreateMap<Output, ReadOutputDTO>();
        }

    }
}