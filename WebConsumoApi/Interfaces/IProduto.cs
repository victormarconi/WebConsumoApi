using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProduto
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> Create(ProductInsert product, RootobjectInsert root);
        Task<Product> Update(string products, ProductInsert product, RootobjectInsert root);
        Task<Product> GetOne(string product);
        Task<Product> Delete(string product);

    }
}
