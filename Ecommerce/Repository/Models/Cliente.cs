using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Repository.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ordines = new HashSet<Ordine>();
            Rubricas = new HashSet<Rubrica>();
        }

        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NumeroTel { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;

        public virtual ICollection<Ordine> Ordines { get; set; }
        public virtual ICollection<Rubrica> Rubricas { get; set; }
    }
}
