using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW_Ecommerce.Models
{
    public class LeveDoisPagueUm : Promocao
    {
        public override double aplicaPromocao(Produto p, int quantidade)
        {
            return p.preco * quantidade / 2;
        }

        public LeveDoisPagueUm(string mensagemErro)
           : base(mensagemErro) { }
    }

    public class TresPorDez : Promocao
    {
        public override double aplicaPromocao(Produto p, int quantidade)
        {
            int aux = quantidade;
            double valorTeste = 0;
            double valorTesteFinal = 0;

            for (int i = 1; i <= aux; i++)
            {
                if (i % 3 == 0)
                {
                    valorTeste += 10;
                    valorTesteFinal = valorTeste;
                }
                else
                {
                    valorTesteFinal += p.preco;
                }
            }

            return valorTesteFinal;
        }

        public TresPorDez(string mensagemErro)
           : base(mensagemErro) { }
    }
}