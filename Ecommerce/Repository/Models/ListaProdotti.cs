using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class ListaProdotti
    {
        public int Id { get; set; }
        public int IdOrdine { get; set; }
        public int IdProdotto { get; set; }
        public int Quantita { get; set; }

        public virtual Ordine IdOrdineNavigation { get; set; } = null!;
        public virtual Prodotto IdProdottoNavigation { get; set; } = null!;
    }
}
