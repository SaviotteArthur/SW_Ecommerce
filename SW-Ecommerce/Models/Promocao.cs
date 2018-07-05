using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Ecommerce.Models
{
    public abstract class Promocao
    {
        public string desc { get; set; }
        public abstract double aplicaPromocao(Produto p, int quantidade);

        public Promocao(string descricao) { this.desc = descricao; }
    }
}
