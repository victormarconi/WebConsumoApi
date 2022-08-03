using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProductDB
    {
       Task<Products> CreateDatabase(ProductInsert product, RootobjectInsert root);
    }
}
