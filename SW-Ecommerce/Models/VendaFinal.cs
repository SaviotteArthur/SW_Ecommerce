using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class VendaFinal
    {
        public Venda venda { get; set; }

        public Promocao promocaoVenda { get; set; }

        public int ganhe { get; set; }
    }
}