using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
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
        public async Task<ActionResult> Details(ProductInsert product)
        {
            var products = await _IProduto.GetOne(product);

            return View(products);

        }

        // GET: ProdutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductInsert collection)
        {
            try
            {
                _IProduto.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public ActionResult Edit(ProductInsert product)
        {
            return View(_IProduto.GetOne(product));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                _IProduto.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(ProductInsert product)
        {
            return View(_IProduto.GetOne(product));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Product collection)
        {
            try
            {
                _IProduto.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
