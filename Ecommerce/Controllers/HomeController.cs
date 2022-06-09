using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ecommerce.Services;
using Ecommerce.Repository.Models;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoriaServices _categoriaServices;
        private readonly ProdottoServices _prodottoServices;
        private readonly ImmagineServices _immagineServices;

        public HomeController(ILogger<HomeController> logger, CategoriaServices categoriaServices,ProdottoServices prodottoServices,ImmagineServices immagineServices)
        {
            _logger = logger;
            _categoriaServices = categoriaServices;
            _prodottoServices = prodottoServices;
            _immagineServices = immagineServices;
        }

        public IActionResult Index()
        {
            List<Categorium> categorie = _categoriaServices.GetCategorie();
            if (categorie.Count() == 0)
            {
                _categoriaServices.PopolaCategoria();
                _prodottoServices.PopolaProdotto();
                _immagineServices.UploadImg();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}