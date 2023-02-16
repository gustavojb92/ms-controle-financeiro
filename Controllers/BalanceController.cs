

using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.Balance;

namespace ms_controle_financeiro.Controllers
{
    [Route("api/balance")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalance _iBalance;

        public BalanceController(IBalance iBalance)
        {
            _iBalance = iBalance;
        }

        public static IEnumerable<String> messageException(Result result)
        {
            return result.Reasons.Select(reason => reason.Message);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var balances = _iBalance.GetAll();
            return balances == null ? NotFound("Ainda não há registros de Balanços") : Ok(balances);
        }

        [HttpGet("{ID}")]
        public IActionResult Get(int ID)
        {
            var balance = _iBalance.GetById(ID);
            return balance == null ? BadRequest(error: "Não encontrado") : Ok(balance);

        }

        [HttpPost]
        public IActionResult Post([FromBody] AddBalanceDTO balanceDTO)
        {
            var balance = _iBalance.Post(balanceDTO);
            return balance == null ? BadRequest("Não foi possivel realizar o cadastro") : Ok(balance);
        }

        [HttpPut("{ID}")]
        public IActionResult Put(int ID, AddBalanceDTO balanceDTO)
        {
            var balance = _iBalance.Put(ID, balanceDTO);
            return balance == null ? BadRequest("Balanço não encontrado") : Ok(balance);
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var balance = _iBalance.Delete(ID);
            return balance ? NoContent() : BadRequest("Não encontrado");
        }
    }
}