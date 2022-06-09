using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Ordine
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCorriere { get; set; }
        public string? Codice { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Corriere? IdCorriereNavigation { get; set; }
    }
}
