using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Model.DTOs.User
{
    public class ReadUserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Work { get; set; }

        public Double ExpectedSalary { get; set; }
        public Double Balances { get; set; }

    }
}