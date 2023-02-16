using AutoMapper;
using ms_controle_financeiro.Model.DTOs.User;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDTO, User>();
            CreateMap<User, ReadUserDTO>();
        }

    }
}