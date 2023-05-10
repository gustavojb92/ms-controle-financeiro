using Microsoft.AspNetCore.Mvc;
using ms_controle_financeiro.Interfaces;

namespace ms_controle_financeiro.Controllers
{
    [Route("api/banks")]
    public class BanksController : ControllerBase
    {
        private readonly IBanks _ibanks;

        public BanksController(IBanks ibanks)
        {
            _ibanks = ibanks;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ibanks.GetAll();
            return result == null ? BadRequest("Falha ao solicitar Bancos") : Ok(result);
        }


    }
}