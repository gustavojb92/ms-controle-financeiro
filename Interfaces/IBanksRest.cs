
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Interfaces
{
    public interface IBanksRest
    {
        Task<IEnumerable<Banks>> GetAll();

    }
}