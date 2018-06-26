using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class Promocao
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public Produto produto { get;set; }

        public int comprex { get; set; }
        public int levex { get; set; }
    }
}