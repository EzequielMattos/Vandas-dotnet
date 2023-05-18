using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vendas.Models;
using Vendas.Repositorios;

namespace Vendas.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaRepositorio _vendaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public VendaController(IVendaRepositorio vendaRepositorio, IProdutoRepositorio produtoRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            var venda = _vendaRepositorio.GetVendas();
            return View(venda);
        }
        public IActionResult CreateVenda()
        {
            var produtos = _produtoRepositorio.GetProdutos();
            var produtosVenda = new List<Venda>();
            foreach (var produto in produtos)
            {
                var venda = new Venda();
                venda.Produto = produto;
                produtosVenda.Add(venda);
            }            

            var clientes = _clienteRepositorio.GetClientes();
            ViewBag.Clientes = clientes;

            return View(produtosVenda);
        }
        public void AdicionarCarrinho(int id)
        {
            var produto = _produtoRepositorio.GetProdutos();
            ViewBag.ProdutosAdicionados = produto;
        }
    }
}
