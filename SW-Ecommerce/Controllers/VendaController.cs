using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SW_Ecommerce.Models;

namespace SW_Ecommerce.Controllers
{
    public class VendaController : Controller
    {
        private meuContexto db = new meuContexto();
        public static List<Venda> vendas = new List<Venda>();
        public static List<Promocao> promocoes = new List<Promocao>();
        // GET: Venda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Venda()
        {
            return View(vendas.ToList());
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "produto,qtd")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                Venda t = new Venda();
                Produto produto = db.Produtoes.Find(venda.produto.id);

                t.id = vendas.Count + 1;
                t.produto = produto;
                t.qtd = venda.qtd;
                t.valorTotal = (produto.preco * venda.qtd);

                vendas.Add(t);

                return RedirectToAction("Venda");
            }

            return View(vendas.ToList());
        }

        public ActionResult Final()
        {
            List<VendaFinal> finalList = new List<VendaFinal>();

            foreach (var item in vendas)
            {
                VendaFinal final = new VendaFinal();

                final.venda = item;

                foreach(var t in promocoes)
                {
                    if (t.produto.id == final.venda.produto.id)
                    {
                        int qtdAux = final.venda.qtd;
                        final.promocaoVenda = t;

                        for(int i=0; t.comprex<=qtdAux; i++)
                        {
                            final.ganhe += t.levex;
                            qtdAux = qtdAux - t.comprex;
                        }
                    }
                }

                finalList.Add(final);
            }

            return View(finalList.ToList());
        }

        public ActionResult PromocaoLista()
        {
            return View(promocoes.ToList());
        }

        public ActionResult Promocao()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Promocao([Bind(Include = "descricao,produto,comprex,levex")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                Promocao t = new Promocao();
                Produto produto = db.Produtoes.Find(promocao.produto.id);

                t.id = promocoes.Count + 1;
                t.descricao = promocao.descricao;
                t.produto = produto;
                t.comprex = promocao.comprex;
                t.levex = promocao.levex;

                promocoes.Add(t);

                return RedirectToAction("Venda");
            }

            return View(vendas.ToList());
        }

        public ActionResult DeleteVenda(int? id)
        {
            for(int i=0; i<vendas.Count; i++)
            {
                if (vendas[i].id == id)
                {

                    Venda t = new Venda();
                    vendas.Remove(vendas[i]);
                }
            }

            return RedirectToAction("Venda");
        }

        public ActionResult DeletePromocao(int? id)
        {
            for (int i = 0; i < promocoes.Count; i++)
            {
                if (promocoes[i].id == id)
                {

                    Promocao t = new Promocao();
                    promocoes.Remove(promocoes[i]);
                }
            }

            return RedirectToAction("PromocaoLista");
        }
    }
}