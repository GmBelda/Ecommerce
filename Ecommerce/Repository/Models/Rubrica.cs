using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Rubrica
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Via { get; set; } = null!;
        public string Citta { get; set; } = null!;
        public string Cap { get; set; } = null!;

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
