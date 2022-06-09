using Ecommerce.Repository;
using Ecommerce.Repository.Models;

namespace Ecommerce.Services
{
    public class ProdottoServices
    {
        private readonly ShopDbContext _dbContext;

        public ProdottoServices(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Prodotto> GetProdottos()
        {
            List<Prodotto> prodottos = _dbContext.Prodottos.ToList();
            return prodottos;
        }

        public void CreaProdotto(Prodotto prodotto)
        {
            var nuovoProdotto = new Prodotto();
            if (_dbContext.Prodottos.Count() == 0) nuovoProdotto.Id = 1; else nuovoProdotto.Id = (_dbContext.Clientes.Max(a => a.Id)) + 1;
            nuovoProdotto.Codice = prodotto.Codice;
            nuovoProdotto.Nome = prodotto.Nome;
            nuovoProdotto.DescBreve = prodotto.DescBreve;
            nuovoProdotto.Descrizione = prodotto.Descrizione;
            nuovoProdotto.Peso = prodotto.Peso;
            nuovoProdotto.Prezzo = prodotto.Prezzo;
            nuovoProdotto.IdCategoria = prodotto.IdCategoria;
            _dbContext.Prodottos.Add(nuovoProdotto);
            _dbContext.SaveChanges();
        }

        public void PopolaProdotto()
        {
            Prodotto Iphone13 = new Prodotto();
            Iphone13.Codice = "12121212121";
            Iphone13.Nome = "Iphone 13";


        }
    }
}
