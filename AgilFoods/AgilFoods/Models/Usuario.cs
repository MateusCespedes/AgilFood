using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgilFoods.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Setor { get; set; }
    }
}