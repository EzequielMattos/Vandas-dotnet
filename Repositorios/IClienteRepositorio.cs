using Vendas.Models;

namespace Vendas.Repositorios
{
    public interface IClienteRepositorio
    {
        List<Cliente> GetClientes();
        Cliente Adicionar(Cliente venda);
        Cliente GetClienteById(int id);
        Cliente Update(Cliente venda);
        bool Delete(int id);
    }
}
