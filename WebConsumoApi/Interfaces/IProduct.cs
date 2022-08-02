using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProduct
    {
       Task<Products> CreateDatabase(ProductInsert product, RootobjectInsert root);
    }
}
