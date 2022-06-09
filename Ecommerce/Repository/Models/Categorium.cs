using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Prodottos = new HashSet<Prodotto>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Icona { get; set; }
        public string? Descrizione { get; set; }

        public virtual ICollection<Prodotto> Prodottos { get; set; }
    }
}
