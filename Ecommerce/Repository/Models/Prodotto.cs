using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Prodotto
    {
        public Prodotto()
        {
            Immagines = new HashSet<Immagine>();
            Scorta = new HashSet<Scortum>();
        }

        public int Id { get; set; }
        public string Codice { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string DescBreve { get; set; } = null!;
        public string? Descrizione { get; set; }
        public decimal Peso { get; set; }
        public decimal Prezzo { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<Immagine> Immagines { get; set; }
        public virtual ICollection<Scortum> Scorta { get; set; }
    }
}
