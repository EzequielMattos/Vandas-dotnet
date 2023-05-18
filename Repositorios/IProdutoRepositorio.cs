using Vendas.Models;

namespace Vendas.Repositorios
{
    public interface IProdutoRepositorio
    {
        List<Produto> GetProdutos();
        Produto Adicionar(Produto produto);
        Produto GetProdutoById(int id);
        Produto Update(Produto produto);
        bool Delete(int id);
    }
}
