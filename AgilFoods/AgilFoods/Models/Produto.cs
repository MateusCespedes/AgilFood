using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgilFoods.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public virtual Fornecedor Fornecedor {get; set;}
        public virtual int FornecedorId { get; set; }
    }
}