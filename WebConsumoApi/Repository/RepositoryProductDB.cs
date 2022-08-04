using WebConsumoApi.Models;
using System.Text.Json;
using System.Text;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebConsumoApi.Repository
{
    public class RepositoryProductDB : IProductDB
    {
        private readonly DbProdutosContext _context;
        public async Task<Products> CreateDatabase(ProductInsert product, RootobjectInsert root)
        {

            var Produto = await _context.Produtos.ToListAsync();
            var Produtos = Produto.Where<ProdutoDB>(p => p.Status == "0");

            var output = new List<ProdutoDB>();

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

            return null;
        }
    }
}
