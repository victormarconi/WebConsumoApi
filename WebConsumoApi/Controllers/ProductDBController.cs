using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebConsumoApi.DBContext;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;

namespace WebConsumoApi.Controllers
{
    public class ProductDBController : Controller
    {
        private readonly DbProdutosContext _context;
        private readonly IProductDB _IProduct;

        public ProductDBController(DbProdutosContext context, IProductDB IProduct)
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
              return View(Produto.Where<ProdutoDB>(p => p.Status == "0"));
        }
        public async Task<IActionResult> SendToConecta(string sku, string motivo, string status)
        {
            var Produtos = await _context.Produtos.Where<ProdutoDB>(p => p.Status == "0").ToListAsync();

            foreach (ProdutoDB produto in Produtos)
            {
                RootobjectInsert raiz = new RootobjectInsert()
                {
                    product = new ProductInsert()
                    {
                        name = produto.Name,
                        sku = produto.Sku,
                        active = produto.Active,
                        description = produto.Description,
                        price = Convert.ToSingle(produto.Price.Replace(',', '.')),
                        qty = Convert.ToInt32(produto.Qty),
                        ean = produto.Ean,
                        sku_manufacturer = produto.SkuManufacturer,
                        net_weight = Convert.ToSingle(produto.NetWeight),
                        gross_weight = Convert.ToSingle(produto.GrossWeight),
                        width = Convert.ToSingle(produto.Width),
                        height = Convert.ToSingle(produto.Height),
                        depth = Convert.ToSingle(produto.Depth),
                        items_per_package = 1,
                        guarantee = Convert.ToInt32(produto.Guarantee),
                        origin = Convert.ToInt32(produto.Origin),
                        unity = produto.Unity,
                        ncm = produto.Ncm,
                        manufacturer = produto.Manufacturer,
                        extra_operating_time = Convert.ToInt32(produto.ExtraOperatingTime),
                        category = produto.Category,
                        images = produto.Images,
                    }
                };

                string jsonObjeto = JsonSerializer.Serialize(raiz);
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
                    var responseBody = await res.Content.ReadAsStringAsync();
                    res.EnsureSuccessStatusCode();
                    var roots = JsonSerializer.Deserialize<Rootobject>(responseBody);
                    if (res.IsSuccessStatusCode == true)
                    {
                        AtualizaStatus atualiza = new AtualizaStatus();
                        produto.Status = "2";
                        atualiza.Atualiza_Status(produto);

                    }
                    else
                    {
                        AtualizaStatus atualiza = new AtualizaStatus();
                        produto.Status = "3";
                        produto.Motivo = res.Content.ReadAsStringAsync().ToString();
                        atualiza.Atualiza_Status(produto);
                    }
                }
                catch (Exception ex)
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
        public async Task<IActionResult> Create([Bind("Name,Sku,Active,Description,Price,Qty,Ean,SkuManufacturer,NetWeight,GrossWeight,Width,Height,Depth,Guarantee,Origin,Unity,Ncm,Manufacturer,ExtraOperatingTime,Category,Images, Status")] ProdutoDB produto)
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
        public IActionResult Edit(string id, [Bind("Name,Sku,Active,Description,Price,Qty,Ean,SkuManufacturer,NetWeight,GrossWeight,Width,Height,Depth,Guarantee,Origin,Unity,Ncm,Manufacturer,ExtraOperatingTime,Category,Images")] ProdutoDB produto)
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
