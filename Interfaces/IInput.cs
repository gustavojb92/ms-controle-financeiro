using ms_controle_financeiro.Model.DTOs.Input;

namespace ms_controle_financeiro.Interfaces
{
    public interface IInput : IBase<AddInputDTO, ReadInputDTO>, IUpdate<AddInputDTO, ReadInputDTO>
    {
        IEnumerable<ReadInputDTO> GetAllByUser(int userId);

        ReadInputPaginatedDTO GetPaginatedByUser(string userId, int page, int itensPerPage);
    }
}