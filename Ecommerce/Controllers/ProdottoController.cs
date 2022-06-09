using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Repository.Models;

namespace Ecommerce.Controllers
{

    public class ProdottoController : Controller
    {
        private readonly ProdottoServices _prodottoServices;
        private readonly ImmagineServices _immagineServices;

        public ProdottoController(ProdottoServices prodottoServices, ImmagineServices immagineServices)
        {
            _prodottoServices = prodottoServices;
            _immagineServices = immagineServices;
        }
        public IActionResult Index()
        {
            ViewBag.Immagine = _immagineServices.GetImgs();
            return View(_prodottoServices.GetProdottos());
        }

    }
}
