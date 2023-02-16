namespace ms_controle_financeiro.Model.DTOs.Output
{
    public class ReadOutputDTO
    {
        public Double Value { get; set; }

        public DateTime OutputDate { get; set; }

        public Boolean HasInterest { get; set; }
        public string ReferingTo { get; set; }

        public virtual Model.Entities.User User { get; set; }
    }
}