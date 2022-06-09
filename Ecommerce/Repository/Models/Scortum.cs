using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Scortum
    {
        public int Id { get; set; }
        public int IdMagazzino { get; set; }
        public int IdProdotto { get; set; }
        public int Quantita { get; set; }

        public virtual Magazzino IdMagazzinoNavigation { get; set; } = null!;
        public virtual Prodotto IdProdottoNavigation { get; set; } = null!;
    }
}
