using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Repository.Models;

namespace Ecommerce.Controllers
{

    public class ProdottoController : Controller
    {
        private readonly ProdottoServices _prodottoServices;
        private readonly ImmagineServices _immagineServices;
        private readonly CategoriaServices _categoriaServices;

        public ProdottoController(ProdottoServices prodottoServices, ImmagineServices immagineServices,CategoriaServices categoriaServices)
        {
            _prodottoServices = prodottoServices;
            _immagineServices = immagineServices;
            _categoriaServices = categoriaServices;
        }
        public IActionResult Index()
        {
            ViewBag.Categoria = _categoriaServices.GetCategorie();
            ViewBag.Immagine = _immagineServices.GetImgs();
            return View(_prodottoServices.GetProdottos());
        }

        public async Task<IActionResult> GetProdotto(int id)
        {
            Prodotto prodotto = _prodottoServices.GetProdotto(id);
            List<Immagine> immagini = _immagineServices.GetImgs().Where(x => x.IdProdotto == id).ToList();
            ViewBag.Immagini = immagini;
            return View("View", prodotto);
        }

        public IActionResult AddToCart(int id)
        {

        }
    }
}
