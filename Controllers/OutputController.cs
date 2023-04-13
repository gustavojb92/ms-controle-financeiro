
using Microsoft.AspNetCore.Mvc;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Output;

namespace ms_controle_financeiro.Controllers
{
    [Route("/api/output")]
    public class OutputController : ControllerBase
    {
        private readonly IOutput _IOutput;

        public OutputController(IOutput _Output)
        {
            _IOutput = _Output;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var outputs = _IOutput.GetAll();
            return outputs == null ? BadRequest("Não há registros") : Ok(outputs);
        }

        [HttpGet("{ID}")]
        public IActionResult Get(int ID)
        {
            var output = _IOutput.GetById(ID);
            return output == null ? BadRequest("Bão encontrado") : Ok(output);
        }

        [HttpGet("by-user/{ID}")]
        public IActionResult GetByUser(int ID)
        {
            var outputs = _IOutput.GetAllByUser(ID);
            return outputs == null ? BadRequest("Não encontrado!") : Ok(outputs);
        }

        [HttpGet("by-user={userId}/itens={page}/itens-per-page={itensPerPage}")]
        public IActionResult GetPaginatedByUser(string userId, int page, int itensPerPage)
        {
            var output = _IOutput.GetPaginatedByUser(userId, page, itensPerPage);
            return output == null ? BadRequest("Não encontrado!") : Ok(output);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOutputDTO outputDTO)
        {
            var output = _IOutput.Post(outputDTO);
            return output == null ? BadRequest("Não foi possivel salvar") : Ok(output);
        }

        [HttpPut("{ID}")]
        public IActionResult Put(int ID, AddOutputDTO outputDTO)
        {
            var output = _IOutput.Put(ID, outputDTO);
            return output == null ? BadRequest("Não foi possivel salvar") : Ok(output);
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var output = _IOutput.Delete(ID);
            return output ? NoContent() : BadRequest("Não Encontrado");
        }
    }
}