using Vendas.Data;
using Vendas.Models;

namespace Vendas.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DataContext _dataContext;
        public ProdutoRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Produto Adicionar(Produto produto)
        {
            _dataContext.Produto.Add(produto);
            _dataContext.SaveChanges();
            return produto;
        }

        public bool Delete(int id)
        {
            var produtoDB = GetProdutoById(id);
            if (produtoDB == null)
                throw new Exception("Não foi possível deletar esse produto.");

            _dataContext.Produto.Remove(produtoDB);
            _dataContext.SaveChanges();
            return true;
        }

        public Produto GetProdutoById(int id)
        {
            return _dataContext.Produto.FirstOrDefault(x => x.Id == id);
        }

        public List<Produto> GetProdutos()
        {
            return _dataContext.Produto.ToList();
        }

        public Produto Update(Produto produto)
        {
            var produtoDB = GetProdutoById(produto.Id);
            if (produtoDB == null)
                throw new Exception("Não foi possível alterar esse produto.");

            produtoDB.Descricao = produto.Descricao;
            produtoDB.Valor = produto.Valor;

            _dataContext.Produto.Update(produtoDB);
            _dataContext.SaveChanges();
            return produtoDB;
        }
    }
}
