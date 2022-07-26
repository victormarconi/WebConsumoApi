using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProduto
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> Create(ProductInsert product);
        Product Update(Product produto);
        Task<Product> GetOne(ProductInsert product);
        Product Delete(string Codigo);

    }
}
