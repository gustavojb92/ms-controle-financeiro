namespace ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.User;
public interface ILogin<in T, out A>
{
    ReadUserDTO Login(T userLogin);
}
