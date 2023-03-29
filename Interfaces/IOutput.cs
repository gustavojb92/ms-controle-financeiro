using ms_controle_financeiro.Model.DTOs.Output;

namespace ms_controle_financeiro.Interfaces
{
    public interface IOutput : IBase<AddOutputDTO, ReadOutputDTO>, IUpdate<AddOutputDTO, ReadOutputDTO>
    {
        IEnumerable<ReadOutputDTO> GetAllByUser(int userId);
    }
}