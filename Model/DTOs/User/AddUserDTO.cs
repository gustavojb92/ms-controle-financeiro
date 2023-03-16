using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Model.DTOs.User
{
    public class AddUserDTO
    {
        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Work { get; set; }

        public Double ExpectedSalary { get; set; }
        public Double Balances { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


    }
}