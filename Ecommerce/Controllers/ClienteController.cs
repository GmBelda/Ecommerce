using Microsoft.AspNetCore.Mvc;
using Ecommerce.Services;
using Ecommerce.Repository.Models;

namespace Ecommerce.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteServices _clienteServices;

        public ClienteController(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public IActionResult Index()
        {
            return View("Form");
        }

        public IActionResult CreaCliente()
        {
            return View("Form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaCliente(Cliente cliente)
        {
                ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _clienteServices.CreaCliente(cliente);
                return RedirectToAction("Index","Prodotto");
            }
            return View("Form");
        }

    }
}
