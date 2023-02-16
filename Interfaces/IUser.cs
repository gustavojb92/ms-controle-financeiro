using ms_controle_financeiro.Model.DTOs.User;

namespace ms_controle_financeiro.Interfaces;
public interface IUser : IBase<AddUserDTO, ReadUserDTO>, IUpdate<AddUserDTO, ReadUserDTO>, ILogin<UserLoginDTO, Boolean>
{

}
