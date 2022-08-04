using Microsoft.AspNetCore.Mvc;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;

namespace WebConsumoApi.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly IProduto _IProduto;
        public ProdutosController(IProduto IProduto)
        {
            _IProduto = IProduto;
        }

        // GET: ProdutosController
        public async Task<ActionResult> Index()
        {
            var products = await _IProduto.ListAsync(); 
            return View(products);
        }


        // GET: ProdutosController/Details/5
        public async Task<ActionResult> Details(string product)
        {
            var products = await _IProduto.GetOne(product);
            return View(products);

        }

        // GET: ProdutosController/Create
        public async Task<ActionResult> Create(string product)
        {
            var products = await _IProduto.GetOne(product);
            return View();

        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductInsert product, RootobjectInsert root)
        {
            try
            {
                _IProduto.Create(product, root);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public async Task<ActionResult> Edit(string product)
        {
            var products = await _IProduto.GetOne(product);
            return View(products);

        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string products, ProductInsert product, RootobjectInsert root)
        {
            try
            {
                _IProduto.Update(products, product, root);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(string product)
        {
            return View(_IProduto.GetOne(product));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, string product)
        {
            try
            {
                _IProduto.Delete(product);
                return RedirectToAction(nameof(Delete));
            }
            catch
            {
                return View();
            }
        }
    }
}
