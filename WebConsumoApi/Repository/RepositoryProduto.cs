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
        private readonly string uprApi = "https://manairadigitalteste.conectala.com.br/";
        public Product Create(Product produto)
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

        public Product GetOne(string Codigo)
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

     /*   public async Task<List<Product>> ListAsync()
        {
            var retorno = new List<Product>();

            try
            {
                using (var client = new HttpClient())
                {

                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://manairadigitalteste.conectala.com.br/app/Api/V1/Products/list"))
                    {
                        client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
                        client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
                        client.DefaultRequestHeaders.Add("x-store-key", "3");
                        request.Content = new StringContent("Content-Type", Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Add("accept", "application/json;charset=UTF-8");

                        //var response = client.GetStringAsync(request.ToString());
                        //var response = client.GetStringAsync(uprApi + "app/Api/V1/Products/list");
                        //response.Wait();
                        var json = await client.GetStringAsync(uprApi + "app/Api/V1/Products/list");
                        var root = JsonSerializer.Deserialize<Rootobject>(json);
                        //retorno = JsonConvert.DeserializeObject<Product[]>(response.ToString()).ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        } */

        public async Task ListAsync()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://manairadigitalteste.conectala.com.br")
            };

            client.DefaultRequestHeaders.Add("x-user-email", "victor@manairadigital.com.br");
            client.DefaultRequestHeaders.Add("x-api-key", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjb2Rfc3RvcmUiOjMsImNvZF9jb21wYW55Ijo3fQ.E_sxhnwcmN5GtNGRYbVD66ciMi3JoJNjormS1q3mxYg");
            client.DefaultRequestHeaders.Add("x-store-key", "3");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "/app/Api/V1/Products/list");
            req.Content = new StringContent("Content-Type", Encoding.UTF8, "application/json");
            using var res = await client.SendAsync(req);
            res.EnsureSuccessStatusCode();
            var responseBody = await res.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<Product>(responseBody);
           
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
