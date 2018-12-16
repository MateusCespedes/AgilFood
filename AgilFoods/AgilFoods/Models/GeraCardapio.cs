using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgilFoods.Models
{
    public class GeraCardapio
    {
        public int Id { get; set; }
        public String DiaSemana { get; set; }
        public string ItemCardapio1 { get; set; }
        public string ItemCardapio2 { get; set; }
        public string ItemCardapio3 { get; set; }
        public string ItemCardapio4 { get; set; }
        public string ItemCardapio5 { get; set; }
        public string ItemCardapio6 { get; set; }
        public string ItemCardapio7 { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual int FornecedorId { get; set; }
        public virtual IEnumerable<Cardapio> Cardapios { get; set; }
    }
}