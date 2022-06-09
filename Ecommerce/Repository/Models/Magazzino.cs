using System;
using System.Collections.Generic;

namespace Ecommerce.Repository.Models
{
    public partial class Magazzino
    {
        public Magazzino()
        {
            Scorta = new HashSet<Scortum>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Scortum> Scorta { get; set; }
    }
}
