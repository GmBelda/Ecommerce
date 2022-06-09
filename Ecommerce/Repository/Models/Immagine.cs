using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Immagine
    {
        public int Id { get; set; }
        public int IdProdotto { get; set; }
        public string Link { get; set; } = null!;

        public virtual Prodotto IdProdottoNavigation { get; set; } = null!;
    }
}
