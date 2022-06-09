using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{

    public class ProdottoController : Controller
    {
        private readonly ProdottoServices _prodottoServices;

        public ProdottoController(ProdottoServices prodottoServices)
        {
            _prodottoServices = prodottoServices;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
