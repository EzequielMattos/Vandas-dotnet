using Vendas.Data;
using Vendas.Models;

namespace Vendas.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly DataContext _dataContext;

        public VendaRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Venda Adicionar(Venda venda)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Venda GetVendaById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venda> GetVendas()
        {
            return _dataContext.Venda.ToList();
        }

        public Venda Update(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}
