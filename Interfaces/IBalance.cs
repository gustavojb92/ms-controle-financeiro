using ms_controle_financeiro.Model.DTOs.Balance;
namespace ms_controle_financeiro.Interfaces
{
    public interface IBalance : IBase<AddBalanceDTO, ReadBalanceDTO>, IUpdate<AddBalanceDTO, ReadBalanceDTO>
    {

    }
}