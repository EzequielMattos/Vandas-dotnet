using Vendas.Models;

namespace Vendas.Repositorios
{
    public interface IVendaRepositorio
    {
        List<Venda> GetVendas();
        Venda Adicionar(Venda venda);
        Venda GetVendaById(int id);
        Venda Update(Venda venda);
        bool Delete(int id);
    }
}
