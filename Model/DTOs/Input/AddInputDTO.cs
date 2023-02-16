namespace ms_controle_financeiro.Model.DTOs.Input
{
    public class AddInputDTO
    {

        public Double Value { get; set; }

        public DateTime InputDate { get; set; }

        public string ToBankAccount { get; set; }
        public int UserId { get; set; }

    }
}