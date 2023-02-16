
namespace ms_controle_financeiro.Model.DTOs.Balance
{
    public class ReadBalanceDTO
    {
        public int Id { get; set; }
        public Double Value { get; set; }

        public DateTime LastUpdate { get; set; }
        public virtual Model.Entities.User User { get; set; }
    }
}