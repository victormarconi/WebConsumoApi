using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;

namespace WebConsumoApi.Repository
{
    public class RepositoryProduto : IProduto
    {
        private readonly string uprApi = "https://manairadigitalteste.conectala.com.br";
        private List<Product> Products = new List<Product>();
        private string e;

        public async Task<Product> Create(ProductInsert product)
        {
            ProductInsert produto = new ProductInsert()
            { 
                sku = product.sku,
                name = product.name,
                description = product.description,
                active = product.active,
                qty = product.qty,
                price = product.price,
                sku_manufacturer = product.sku_manufacturer,
                net_weight = product.net_weight,
                gross_weight = product.gross_weight,
                height = product.height,
                width = product.width,
                depth = product.depth,
                items_per_package = product.items_per_package,
                manufacturer = product.manufacturer,
                ean = product.ean,
                ncm = product.ncm,
                category = product.category,
                extra_operating_time = product.extra_operating_time,
                images = product.images,
                guarantee = product.guarantee,
                origin = product.origin,
                unity = product.unity
            };





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

                string jsonObjeto = JsonSerializer.Serialize(produto);
                req.Content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                using var res = await client.SendAsync(req);
                //res.EnsureSuccessStatusCode();
                var responseBody = await res.Content.ReadAsStringAsync();
                var root = JsonSerializer.Deserialize<Rootobject>(responseBody);
                var output = new Product();
            }
            catch(Exception ex)
            {
                e = ex.Message;
            }
            //root?.result.data.ToList().ForEach(x => output.Add(x.product));
            return null;
        }

        public Product Delete(string Codigo)
        {
            var produtoCriado = new Product();
            produtoCriado.sku = Codigo;
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonSerializer.Serialize(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(uprApi + "app/Api/V1/Products/list", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonSerializer.Deserialize<Product>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return produtoCriado;
        }

        public async Task<Product> GetOne(ProductInsert product)
        {
            
            //var produtoCriado = Products.Find(x => x.sku == sku);
            ProductInsert produto = new ProductInsert()
            {
                sku = product.sku
        };
                

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://manairadigitalteste.conectala.com.br")
            };
            string jsonObjeto = JsonSerializer.Serialize(produto.sku);
            client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
            client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
            client.DefaultRequestHeaders.Add("x-store-key", "3");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "/app/Api/V1/Products/" + produto.sku);

            // string jsonObjeto = JsonSerializer.Serialize(produtoCriado);
            req.Content = new StringContent("Content-type", Encoding.UTF8, "application/json");
            using var res = await client.SendAsync(req);
            //res.EnsureSuccessStatusCode();
            var responseBody = await res.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<Rootobject>(responseBody);
            var output = new List<Product>();
            root?.result.data.ToList().ForEach(x => output.Add(x.product));
            return null;

        }
        public async Task<IEnumerable<Product>> ListAsync()
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://manairadigitalteste.conectala.com.br")
                };

                client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
                client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
                client.DefaultRequestHeaders.Add("x-store-key", "3");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using var req = new HttpRequestMessage(HttpMethod.Get, "/app/Api/V1/Products/list");
                req.Content = new StringContent("Content-type", Encoding.UTF8, "application/json");
                using var res = await client.SendAsync(req);
                res.EnsureSuccessStatusCode();
                var responseBody = await res.Content.ReadAsStringAsync();
                var root = JsonSerializer.Deserialize<Rootobject>(responseBody);
                var output = new List<Product>();
                root?.result.data.ToList().ForEach(x => output.Add(x.product));
                return output;
            }

            public Product Update(Product produto)
            {
                var produtoCriado = new Product();
                try
                {
                    using (var client = new HttpClient())
                    {
                        string jsonObjeto = JsonSerializer.Serialize(produto);
                        var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                        var response = client.PostAsync(uprApi + "app/Api/V1/Products/list", content);
                        response.Wait();
                        if (response.Result.IsSuccessStatusCode)
                        {
                            var retorno = response.Result.Content.ReadAsStringAsync();
                            produtoCriado = JsonSerializer.Deserialize<Product>(retorno.Result);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return produtoCriado;
            }
        }
    }

