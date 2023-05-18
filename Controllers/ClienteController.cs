using Microsoft.AspNetCore.Mvc;
using Vendas.Models;
using Vendas.Repositorios;

namespace Vendas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            var clientes = _clienteRepositorio.GetClientes();
            return View(clientes);
        }

        public IActionResult CreateClient()
        {
            return View();
        }

        public IActionResult UpdateClient(int id)
        {
            var cliente = _clienteRepositorio.GetClienteById(id);
            return View(cliente);
        }

        public IActionResult DeleteClient(int id)
        {
            var cliente = _clienteRepositorio.GetClienteById(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult CreateClient(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MessageSuccess"] = "Cliente Cadastrado Com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops! Não Foi Possível Cadastrar Esse Cliente! Detalhe: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult UpdateClient(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Update(cliente);
                    TempData["MessageSuccess"] = "Cliente Alterado Com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops! Não Foi Possível Alterar Esse Cliente! Detalhe: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int id)
        {
            try
            {
                _clienteRepositorio.Delete(id);
                TempData["MessageSuccess"] = "Cliente Deletado Com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageSuccess"] = $"Ops! Não Foi Possível Deletar Esse Cliente! Detalhe: {ex.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
