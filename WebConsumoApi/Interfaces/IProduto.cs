using WebConsumoApi.Models;

namespace WebConsumoApi.Interfaces
{
    public interface IProduto
    {
        Task ListAsync();

        Product Create(Product produto);
        Product Update(Product produto);
        Product GetOne(string Codigo);
        Product Delete(string Codigo);

    }
}
