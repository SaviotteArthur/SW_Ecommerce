using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class ProdutoPromocao
    {
        public Produto produto { get; set; }
        public Promocao promocao { get; set; }
    }
}