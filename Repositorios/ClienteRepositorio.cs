using Vendas.Data;
using Vendas.Models;

namespace Vendas.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DataContext _dataContext;
        public ClienteRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            _dataContext.Cliente.Add(cliente);
            _dataContext.SaveChanges();
            return cliente;
        }

        public bool Delete(int id)
        {
            var clienteDB = GetClienteById(id);
            if (clienteDB == null)
                throw new Exception("Não foi possível deletar esse cliente.");

            _dataContext.Cliente.Remove(clienteDB);
            _dataContext.SaveChanges();
            return true;
        }

        public Cliente GetClienteById(int id)
        {
            return _dataContext.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> GetClientes()
        {
            return _dataContext.Cliente.ToList();
        }

        public Cliente Update(Cliente cliente)
        {
            var clienteDB = GetClienteById(cliente.Id);
            if (clienteDB == null)
                throw new Exception("Não foi possível alterar esse cliente.");

            clienteDB.Nome = cliente.Nome;  
            clienteDB.Cidade = cliente.Cidade;

            _dataContext.Cliente.Update(clienteDB);
            _dataContext.SaveChanges();
            return clienteDB;
        }
    }
}
