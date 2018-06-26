using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class Venda
    {
        public int id { get; set; }
        public Produto produto { get; set; }
        public int qtd { get; set; }
        public double valorTotal { get; set; }
    }
}