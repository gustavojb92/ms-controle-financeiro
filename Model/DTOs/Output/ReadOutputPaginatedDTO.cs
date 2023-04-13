using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Model.DTOs.Output
{
    public class ReadOutputPaginatedDTO
    {
        public ReadOutputPaginatedDTO(
           List<ReadOutputDTO> Outputs, int ActualPage, int TotalPages, int TotalItens
       )
        {
            this.Outputs = Outputs;
            this.ActualPage = ActualPage;
            this.TotalPages = TotalPages;
            this.TotalItens = TotalItens;
        }


        public virtual List<ReadOutputDTO> Outputs { get; set; }

        public int ActualPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItens { get; set; }
    }
}