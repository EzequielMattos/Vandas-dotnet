using Microsoft.AspNetCore.Mvc;
using Vendas.Models;
using Vendas.Repositorios;

namespace Vendas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            var produtos = _produtoRepositorio.GetProdutos();
            return View(produtos);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult UpdateProduct(int id)
        {
            var produto = _produtoRepositorio.GetProdutoById(id);
            return View(produto);
        }

        public IActionResult DeleteProduct(int id)
        {
            var produto = _produtoRepositorio.GetProdutoById(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult CreateProduct(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Adicionar(produto);
                    TempData["MessageSuccess"] = "Produto Cadastrado Com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops! Não Foi Possível Cadastrar Esse Produto! Detalhe: {ex.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult UpdateProduct(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Update(produto);
                    TempData["MessageSuccess"] = "Produto Alterado Com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception ex) 
            {
                TempData["MessageError"] = $"Ops! Não Foi Possível Alterar Esse Produto! Detalhe: {ex.Message}";
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _produtoRepositorio.Delete(id);
                TempData["MessageSuccess"] = "Produto Deletado Com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageSuccess"] = $"Ops! Não Foi Possível Deletar Esse Produto! Detalhe: {ex.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
