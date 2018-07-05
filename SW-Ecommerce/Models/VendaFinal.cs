using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class VendaFinal
    {
        public Venda venda { get; set; }

        public double ValorTotal { get; set; }

        public int Qtd { get; set; }

        public string Promocao { get; set; }
    }
}