using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;
using WebConsumoApi.ViewModels;

namespace WebConsumoApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbProdutosContext _context;
        private readonly IProduct _IProduct;

        public ProductController(DbProdutosContext context, IProduct IProduct)
        {
            _IProduct = IProduct;
            _context = context;
        }


        // GET: Product
        public async Task<IActionResult> Index()
        {
              return _context.Produtos != null ? 
                          View(await _context.Produtos.ToListAsync()) :
                          Problem("Entity set 'DbProdutosContext.Produtos'  is null.");
        }

        public async Task<IActionResult> Index1()
        {
            var Produto = await _context.Produtos.ToListAsync();
              return View(Produto.Where<Produto>(p => p.Status == 0));
        }
        public async Task<ActionResult> CreateDatabase(ProductInsert product, RootobjectInsert root)
        {
            var Produto = await _context.Produtos.ToListAsync();
            var Produtos = Produto.Where<Produto>(p => p.Status == 0);

            var output = new List<Produto>();

            foreach (var item in Produtos)
            {
                string jsonObjeto = JsonSerializer.Serialize(Produtos);
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://manairadigitalteste.conectala.com.br")
                };
                try
                {
                    client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
                    client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
                    client.DefaultRequestHeaders.Add("x-store-key", "3");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "app/Api/V1/Products");


                    req.Content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    using var res = await client.SendAsync(req);
                    //res.EnsureSuccessStatusCode();
                    var responseBody = await res.Content.ReadAsStringAsync();
                    var roots = JsonSerializer.Deserialize<Rootobject>(responseBody);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }

            // GET: Product/Details/5
            public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Sku == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Sku,Active,Description,Price,Qty,Ean,SkuManufacturer,NetWeight,GrossWeight,Width,Height,Depth,Guarantee,Origin,Unity,Ncm,Manufacturer,ExtraOperatingTime,Category,Images")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Sku,Active,Description,Price,Qty,Ean,SkuManufacturer,NetWeight,GrossWeight,Width,Height,Depth,Guarantee,Origin,Unity,Ncm,Manufacturer,ExtraOperatingTime,Category,Images")] Produto produto)
        {
            if (id != produto.Sku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Sku))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Sku == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'DbProdutosContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(string id)
        {
          return (_context.Produtos?.Any(e => e.Sku == id)).GetValueOrDefault();
        }
    }
}
