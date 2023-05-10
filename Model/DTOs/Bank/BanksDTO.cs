using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Model.DTOs.Bank
{
    public class BanksDTO
    {
        public string? Ispb { get; set; }

        public string? NomeAbreviado { get; set; }

        public int? Codigo { get; set; }

        public string? NomeCompleto { get; set; }
    }
}