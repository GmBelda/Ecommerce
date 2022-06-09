using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Corriere
    {
        public Corriere()
        {
            Ordines = new HashSet<Ordine>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Ordine> Ordines { get; set; }
    }
}
