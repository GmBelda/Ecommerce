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
        private readonly ClienteServices _clienteServices;

        public ProdottoController(ProdottoServices prodottoServices, ImmagineServices immagineServices,CategoriaServices categoriaServices,ClienteServices clienteServices)
        {
            _prodottoServices = prodottoServices;
            _immagineServices = immagineServices;
            _categoriaServices = categoriaServices;
            _clienteServices = clienteServices;
        }
        public IActionResult Index()
        {
            ViewBag.Carrello = _prodottoServices.GetCarrello();
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
            List<Prodotto> carrello = _prodottoServices.AddToCart(id).ToList();
            return RedirectToAction(nameof(Index),carrello);
        }

        public IActionResult AumentaCarrello(int id)
        {
            List<Prodotto> carrello = _prodottoServices.AddToCart(id).ToList();
            return RedirectToAction(nameof(Checkout), carrello);
        }

        public IActionResult RiduciCarrello(int id)
        {
            List<Prodotto> carrello = _prodottoServices.RemoveFromCart(id).ToList();
            return RedirectToAction(nameof(Checkout), carrello);
        }

        public IActionResult Empty()
        {
            _prodottoServices.Empty();
            return View(Index);
        }

        public IActionResult Checkout()
        {
            Cliente cliente = _clienteServices.GetCliente();
            if (cliente!=null)
            {
                ViewBag.Carrello = _prodottoServices.GetCarrello();
                ViewBag.Cliente = cliente;
                return View();
            }
            return RedirectToAction("CreaCliente","Cliente");
        }
    }
}
