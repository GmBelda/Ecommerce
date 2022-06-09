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

        public Prodotto? GetProdotto(int id)
        {
            return _dbContext.Prodottos.First(p => p.Id == id);
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
            Iphone13.Id = 1;
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
            _dbContext.Add(Iphone13);

            Prodotto Apple = new Prodotto();
            Apple.Id = 2;
            Apple.Codice = "32232323232";
            Apple.Nome = "Fresh Apple";
            Apple.DescBreve = "La frutta piu buona e raccomandata dai dottori!";
            Apple.Descrizione = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad " +
                "minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea " +
                "commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse " +
                "cillum dolore eu fugiat nulla pariatur. ";
            Apple.Peso = 10;
            Apple.Prezzo = 1.90m;
            Apple.IdCategoria = 2;
            _dbContext.Add(Apple);

            Prodotto AppleShirt = new Prodotto();
            AppleShirt.Id = 3;
            AppleShirt.Codice = "45455445454";
            AppleShirt.Nome = "Maglietta Apple";
            AppleShirt.DescBreve = "Apple-T shirt, realizzato con 70% cotone e 30% Satin";
            AppleShirt.Descrizione = "La maglietta, t - shirt o semplicemente tee è un capo di abbigliamento di stoffa, senza bottoni e senza colletto, che ricopre il torso di chi la indossa.Può essere confezionata a maniche lunghe o a maniche corte, in tessuti naturali come il cotone, od in fibre sintetiche.";
            AppleShirt.Peso = 150;
            AppleShirt.Prezzo = 34.99m;
            AppleShirt.IdCategoria = 3;
            _dbContext.Add(AppleShirt);

            Prodotto temp;
            int count = _dbContext.Prodottos.Count();
            int id = 4;
            for (int j = 1; j < 4; j++)
            {
                for (int i = count+1; i < count+3; i++)
                {
                    temp = new Prodotto(); 
                    temp.Id = id++; 
                    temp.Nome = "Prodotto #" + id; 
                    temp.DescBreve = "Descrizione del prodotto : " + id; 
                    temp.Peso = id*3; 
                    temp.Descrizione = "la mia descrizione è, id:" + id;
                    temp.IdCategoria = j; 
                    temp.Codice = "ay37121ja" + id; 
                    _dbContext.Prodottos.Add(temp);
                }
            }
                    _dbContext.SaveChanges();
        }
    }
}
