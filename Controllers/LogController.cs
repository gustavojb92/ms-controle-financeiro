using Microsoft.AspNetCore.Mvc;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Log;

namespace ms_controle_financeiro.Controllers
{
    [Route("/api/log")]
    public class LogController : ControllerBase
    {
        private readonly ILog _ilog;

        public LogController(ILog log)
        {
            _ilog = log;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var logs = _ilog.GetAll();
            return logs == null ? BadRequest("Não há registros") : Ok(logs);
        }

        [HttpGet("{ID}")]
        public IActionResult Get(int ID)
        {
            var logs = _ilog.GetById(ID);
            return logs == null ? BadRequest("Não encontrado") : Ok(logs);
        }

        [HttpGet("by-user/{ID}")]
        public IActionResult GetByUser(int ID)
        {
            var logs = _ilog.GetAllByUser(ID);
            return logs == null ? BadRequest("Não encontrado!") : Ok(logs);
        }

        [HttpGet("by-user={userId}/itens={page}/itens-per-page={itensPerPage}")]
        public IActionResult GetPaginatedByUser(string userId, int page, int itensPerPage)
        {
            var logs = _ilog.GetPaginatedByUser(userId, page, itensPerPage);
            return logs == null ? BadRequest("Não encontrado!") : Ok(logs);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddLogDTO logDTO)
        {
            var log = _ilog.Post(logDTO);
            return log == null ? BadRequest("Não foi possivel realizar o cadastro") : Ok(logDTO);
        }

        [HttpPut("{ID}")]
        public IActionResult Put(int ID, AddLogDTO logDTO)
        {
            var log = _ilog.Put(ID, logDTO);
            return log == null ? BadRequest("Não foi possível realizar a edição ") : Ok(logDTO);
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var log = _ilog.Delete(ID);
            return log ? NoContent() : BadRequest("Não encontrado");
        }

        [HttpGet("/search/initial={initalDate}/final={finalDate}/user-id={id}")]
        public IActionResult Search(DateTime initalDate, DateTime finalDate, int id)
        {
            var dates = new FilterLogDTO();
            dates.InitialDate = initalDate;
            dates.FinalDate = finalDate;
            var logs = _ilog.Search(dates, id);
            return logs == null ? BadRequest("Não há registros para o periodo") : Ok(logs);
        }
    }
}