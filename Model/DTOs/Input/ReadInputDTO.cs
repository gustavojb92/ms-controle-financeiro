

namespace ms_controle_financeiro.Model.DTOs.Input
{
    public class ReadInputDTO
    {
        public int Id { get; set; }
        public Double Value { get; set; }

        public DateTime InputDate { get; set; }

        public string ToBankAccount { get; set; }
        public virtual Model.Entities.User User { get; set; }
    }
}