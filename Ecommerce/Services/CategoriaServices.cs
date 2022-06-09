using Ecommerce.Repository;
using Ecommerce.Repository.Models;

namespace Ecommerce.Services
{
    public class CategoriaServices
    {
        private readonly ShopDbContext _dbContext;

        public CategoriaServices(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Categorium> GetCategorie()
        {
            List<Categorium> listaCategoria = _dbContext.Categoria.ToList();
            return listaCategoria;
        }

        public void CreaCategoria(Categorium categoria)
        {
            var nuovoCategoria = new Categorium();
            if (_dbContext.Categoria.Count() == 0) nuovoCategoria.Id = 1; else nuovoCategoria.Id = (_dbContext.Categoria.Max(a => a.Id)) + 1; //a.Id;
            nuovoCategoria.Nome = categoria.Nome;
            nuovoCategoria.Icona = categoria.Icona;
            nuovoCategoria.Descrizione = categoria.Descrizione;
            _dbContext.Categoria.Add(nuovoCategoria);
            _dbContext.SaveChanges();
        }

        public void PopolaCategoria()
        {
            Categorium Elettronica = new Categorium();
            Elettronica.Id = 1;
            Elettronica.Nome = "Elettronica";
            Elettronica.Icona = "elettronica.png";
            Elettronica.Descrizione = "Prodotti di Elettronica";
            _dbContext.Categoria.Add(Elettronica);
            Categorium Alimentare = new Categorium();
            Alimentare.Id = 2;
            Alimentare.Nome = "Alimentare";
            Alimentare.Icona = "alimentare.png";
            Alimentare.Descrizione = "Prodotti di tipo Cibo e Bevande";
            _dbContext.Categoria.Add(Alimentare);
            Categorium Abbigliamento = new Categorium();
            Abbigliamento.Id = 3;
            Abbigliamento.Nome = "Abbigliamento";
            Abbigliamento.Icona = "abbigliamento.png";
            Abbigliamento.Descrizione = "Prodotti di Abbigliamento";
            _dbContext.Categoria.Add(Abbigliamento);
            _dbContext.SaveChanges();
        }
    }
}
