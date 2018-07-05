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
        public static List<ProdutoPromocao> prodpromo = new List<ProdutoPromocao>();
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
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Selecione um Produto", Value = "" });

            foreach (var item in db.Produtoes.ToList())
            {
                items.Add(new SelectListItem { Text = item.nome.Trim(), Value = item.id.ToString().Trim() });
            }

            ViewBag.Produtos = items;

            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Cadastro([Bind(Include = "produto,qtd")] Venda venda)
        public ActionResult Cadastro(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int prodId = int.Parse(form["Produtos"]);
                int qtd = int.Parse(form["qtd"]);

                Venda t = new Venda();
                Produto produto = db.Produtoes.Find(prodId);

                t.id = vendas.Count + 1;
                t.produto = produto;
                t.qtd = qtd;
                t.valorTotal = (produto.preco * qtd);

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

                final.Qtd = item.qtd;

                final.ValorTotal = item.valorTotal;

                //Tive que criar uma lista de prodPromo, por que não consegui criar a promoção dentro do produto
                foreach(var promo in prodpromo)
                {
                    if (item.produto.id == promo.produto.id)
                    {
                        final.Promocao = promo.promocao.desc;
                        final.ValorTotal = promo.promocao.aplicaPromocao(item.produto, item.qtd);
                    }
                }

                /*Essa seria a forma de buscar se a promoção fosse dentro do produto*/
                //if (item.produto.promocao != null)
                //{
                //    final.ValorTotal = item.produto.promocao.aplicaPromocao(item.produto, item.qtd);
                //}
                //else
                //{
                //    final.ValorTotal = item.valorTotal;
                //}

                finalList.Add(final);
            }

            return View(finalList.ToList());
        }

        //public ActionResult PromocaoLista()
        //{
        //    return View(promocoes.ToList());
        //}

        public ActionResult Promocao()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Selecione um Produto", Value = "" });

            foreach (var item in db.Produtoes.ToList())
            {
                items.Add(new SelectListItem { Text = item.nome.Trim(), Value = item.id.ToString().Trim() });
            }

            ViewBag.Produtos = items;

            List<SelectListItem> items2 = new List<SelectListItem>();

            items2.Add(new SelectListItem { Text = "Selecione uma Promoção", Value = "" });

            items2.Add(new SelectListItem { Text = "Pague 1 e Leve 2", Value = "1" });
            items2.Add(new SelectListItem { Text = "3 por 10", Value = "2" });

            ViewBag.Promocoes = items2;

            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Promocao(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string prod = form["Produtos"];
                int promo = int.Parse(form["Promocoes"]);

                Produto produto = db.Produtoes.Find(int.Parse(prod));

                ProdutoPromocao p = new ProdutoPromocao();
                p.produto = produto;
                if (promo == 1)
                {
                    p.promocao = new LeveDoisPagueUm("Pague 1 e Leve 2");
                }
                else
                {
                    p.promocao = new TresPorDez("3 por 10");
                }
                prodpromo.Add(p);

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
            //for (int i = 0; i < promocoes.Count; i++)
            //{
            //    if (promocoes[i].id == id)
            //    {

            //        LeveDoisPagueUm t = new LeveDoisPagueUm();
            //        promocoes.Remove(promocoes[i]);
            //    }
            //}

            return RedirectToAction("PromocaoLista");
        }
    }
}