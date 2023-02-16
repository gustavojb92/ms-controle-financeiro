using AutoMapper;
using ms_controle_financeiro.Model.DTOs.Log;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<AddLogDTO, Log>();
            CreateMap<Log, ReadLogDTO>();
        }

    }
}