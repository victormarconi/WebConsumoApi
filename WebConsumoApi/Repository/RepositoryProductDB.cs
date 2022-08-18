using WebConsumoApi.Models;
using System.Text.Json;
using System.Text;
using WebConsumoApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using WebConsumoApi.DBContext;

namespace WebConsumoApi.Repository
{
    public class RepositoryProductDB : IProductDB
    {
        private readonly DbProdutosContext _context;
        public async Task<ProdutoDB> SendToConecta(string sku, string motivo, string status)
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
                    client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjQsImNvZF9jb21wYW55Ijo3fQ.BTIw_8-pomUDe8j5aPaH7ejf0b0JGE1_ZNavReXjfn4");
                    client.DefaultRequestHeaders.Add("x-store-key", "4");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "app/Api/V1/Products");


                    req.Content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    using var res = await client.SendAsync(req);
                    res.EnsureSuccessStatusCode();
                    var responseBody = await res.Content.ReadAsStringAsync();
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
            return null;
        }
    }
}


