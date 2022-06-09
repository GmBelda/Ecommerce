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
            Iphone13.DescBreve = "Smartphone Apple di ultima generazione";
            Iphone13.Descrizione = "Per ridurre ancora di più l’impatto ambientale di Apple, " +
                "iPhone 13 e iPhone 13 mini non includono né l’alimentatore né gli EarPods. " +
                "Nella confezione trovi un cavo da USB‑C a Lightning per la ricarica veloce, " +
                "compatibile con alimentatori e porte di tipo USB‑C. Per questi modelli di " +
                "iPhone puoi continuare a utilizzare gli alimentatori e gli auricolari che già possiedi." +
                "Ma se vuoi, puoi sempre acquistare separatamente nuovi alimentatori o auricolari Apple.";
            Iphone13.Peso = 186;
            Iphone13.Prezzo = 1289;
            Iphone13.IdCategoria = 1;
            CreaProdotto(Iphone13);

            Prodotto temp;
            int id = 2;
            for (int j = 1; j < 4; j++)
            {
                for (int i = 2; i < 7; i++)
                {
                    temp = new Prodotto(); 
                    temp.Id = id++; 
                    temp.Nome = "Oggetto id: " + i; 
                    temp.DescBreve = "Descrizione oggetto id: " + i; 
                    temp.Peso = i; 
                    temp.Descrizione = "la mia descrizione è, id:" + i;
                    temp.IdCategoria = j; 
                    temp.Codice = "ay37121ja" + id; 
                    _dbContext.Prodottos.Add(temp);
                }
                    _dbContext.SaveChanges();
            }
        }
    }
}
