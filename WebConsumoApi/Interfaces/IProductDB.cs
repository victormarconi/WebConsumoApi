using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProductDB
    {
        Task<ProdutoDB> SendToConecta(string sku, string motivo, string status);
    }
}
