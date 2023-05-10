using System.Text.Json;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Rest
{
    public class GetBanksRest : IBanksRest
    {
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://brasilapi.com.br/api/")
        };
        public async Task<IEnumerable<Banks>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Banks>>("banks/v1");
        }
    }
}