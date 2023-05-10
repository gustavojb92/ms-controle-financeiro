

using ms_controle_financeiro.Model.DTOs.Bank;

namespace ms_controle_financeiro.Interfaces
{
    public interface IBanks
    {
        Task<IEnumerable<BanksDTO>> GetAll();

    }
}