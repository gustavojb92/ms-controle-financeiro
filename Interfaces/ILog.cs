using ms_controle_financeiro.Model.DTOs.Log;

namespace ms_controle_financeiro.Interfaces
{
    public interface ILog : IBase<AddLogDTO, ReadLogDTO>, IUpdate<AddLogDTO, ReadLogDTO>, ISearchLog<FilterLogDTO, ReadLogDTO>
    {

    }
}