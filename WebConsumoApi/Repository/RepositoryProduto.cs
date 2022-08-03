using Microsoft.Net.Http.Headers;
using System.Data.Entity;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;
using WebConsumoApi.ViewModels;

namespace WebConsumoApi.Repository
{

    public class RepositoryProduto : IProduto
    {
        private readonly string uprApi = "https://manairadigitalteste.conectala.com.br";
        public async Task<Products> Create(ProductInsert product, RootobjectInsert root)
        {
            RootobjectInsert raiz = new RootobjectInsert() {
                    product = new ProductInsert() {
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
     
                }
                
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

                string jsonObjeto = JsonSerializer.Serialize(raiz);
                req.Content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                using var res = await client.SendAsync(req);
                //res.EnsureSuccessStatusCode();
                var responseBody = await res.Content.ReadAsStringAsync();
                var roots = JsonSerializer.Deserialize<Rootobject>(responseBody);     
            }
            catch(Exception)
            {
                throw;
            }
            //root?.result.data.ToList().ForEach(x => output.Add(x.product));
            return null;
        }
        public async Task<Products> Delete(string product)
        {
            ProductInsert produtocriado = new ProductInsert();
            produtocriado.sku = product;

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://manairadigitalteste.conectala.com.br")
            };
            string jsonObjeto = JsonSerializer.Serialize(product);
            client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
            client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
            client.DefaultRequestHeaders.Add("x-store-key", "3");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "/app/Api/V1/Products/trash" + product);

            req.Content = new StringContent("Content-type", Encoding.UTF8, "application/json");
            using var res = await client.SendAsync(req);
            res.EnsureSuccessStatusCode();
            var responseBody = await res.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<Rootobject>(responseBody);
            return root.result.product;
        }
        public async Task<Products> GetOne(string product)
        {
            ProductInsert produtocriado = new ProductInsert();
            produtocriado.sku = product;

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://manairadigitalteste.conectala.com.br")
            };
            string jsonObjeto = JsonSerializer.Serialize(product);
            client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
            client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
            client.DefaultRequestHeaders.Add("x-store-key", "3");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "/app/Api/V1/Products/" + product);

            req.Content = new StringContent("Content-type", Encoding.UTF8, "application/json");
            using var res = await client.SendAsync(req);
            res.EnsureSuccessStatusCode();
            var responseBody = await res.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<Rootobject>(responseBody);
            return root.result.product;

        }
        public async Task<IEnumerable<Products>> ListAsync()
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
                var output = new List<Products>();
                root?.result.data.ToList().ForEach(x => output.Add(x.product));
                return output;
            }
        public async Task<Products> Update(string products, ProductInsert product, RootobjectInsert root)
            {
            ProductInsert produtocriado = new ProductInsert();
            produtocriado.sku = products;

            RootobjectInsert raiz = new RootobjectInsert()
            {
                    product = new ProductInsert()
                {
                    sku = product.sku,
                    active = product.active,
                    price = product.price,
                    qty = product.qty
                }
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
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, "app/Api/V1/Products/" + product.sku);

                string jsonObjeto = JsonSerializer.Serialize(raiz);
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
            return null;
        }
        }
    }

