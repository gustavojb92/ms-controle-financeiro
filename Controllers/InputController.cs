using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Input;

namespace ms_controle_financeiro.Controllers
{
    [Route("api/input")]
    public class InputController : ControllerBase
    {
        private readonly IInput _IInput;

        public InputController(IInput input)
        {
            _IInput = input;
        }

        public static IEnumerable<String> messageException(Result result)
        {
            return result.Reasons.Select(reason => reason.Message);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var inputs = _IInput.GetAll();
            return inputs == null ? BadRequest("Não há registros") : Ok(inputs);
        }

        [HttpGet("{ID}")]
        public IActionResult Get(int ID)
        {
            var input = _IInput.GetById(ID);
            return input == null ? BadRequest("Não encontrado!") : Ok(input);
        }

        [HttpGet("by-user/{ID}")]
        public IActionResult GetByUser(int ID)
        {
            var input = _IInput.GetAllByUser(ID);
            return input == null ? BadRequest("Não encontrado!") : Ok(input);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddInputDTO inputDTO)
        {
            var input = _IInput.Post(inputDTO);
            return input == null ? BadRequest("Não foi possível salvar.") : Ok(input);
        }

        [HttpPut("{ID}")]
        public IActionResult Put(int ID, AddInputDTO inputDTO)
        {
            var input = _IInput.Put(ID, inputDTO);
            return input == null ? BadRequest("Não encontrado") : Ok(input);
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var input = _IInput.Delete(ID);
            return input ? NoContent() : BadRequest("Não fopi possível excluir.");
        }

    }
}