using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProduto
    {
        Task<IEnumerable<Products>> ListAsync();
        Task<Products> Create(ProductInsert product, RootobjectInsert root);
        Task<Products> Update(string products, ProductInsert product, RootobjectInsert root);
        Task<Products> GetOne(string product);
        Task<Products> Delete(string product);

    }
}
