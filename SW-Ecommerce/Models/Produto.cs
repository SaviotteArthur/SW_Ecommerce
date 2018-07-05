using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }

        /*Não consegui criar uma promoção dentro do produto, por que o banco de dados é gerado automatico,
        e com isso não criava a foregein key promoção, por que não existia uma tabela de promoções.*/
        //public int promocao { get; set; }
        
        //public Promocao promocao { get; set; }
    }
}