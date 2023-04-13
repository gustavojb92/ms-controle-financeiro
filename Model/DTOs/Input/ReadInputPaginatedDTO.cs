using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Model.DTOs.Input
{
    public class ReadInputPaginatedDTO
    {
        public ReadInputPaginatedDTO(
           List<ReadInputDTO> Inputs, int ActualPage, int TotalPages, int TotalItens
        )
        {
            this.Inputs = Inputs;
            this.ActualPage = ActualPage;
            this.TotalPages = TotalPages;
            this.TotalItens = TotalItens;
        }


        public virtual List<ReadInputDTO> Inputs { get; set; }

        public int ActualPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItens { get; set; }
    }
}