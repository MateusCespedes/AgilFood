using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgilFoods.Models
{
    public class Cardapio
    {
        public int Id { get; set; }
        public string DescricaoItem { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual int FornecedorId { get; set; }
    }
}