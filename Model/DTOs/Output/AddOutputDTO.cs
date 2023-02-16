using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Model.DTOs.Output
{
    public class AddOutputDTO
    {
        public int UserId { get; set; }

        public Double Value { get; set; }

        public DateTime OutputDate { get; set; }

        public Boolean HasInterest { get; set; }
        public string ReferingTo { get; set; }
    }
}