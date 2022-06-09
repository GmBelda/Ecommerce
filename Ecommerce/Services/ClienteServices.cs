using Ecommerce.Repository;
using Ecommerce.Repository.Models;

namespace Ecommerce.Services
{
    public class ClienteServices
    {
        private readonly ShopDbContext _dbContext;

        public ClienteServices(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            List<Cliente> listaCliente = _dbContext.Clientes.ToList();
            return listaCliente;
        }

        public void CreaCliente(Cliente cliente)
        {
            var nuovoCliente = new Cliente();
            if (_dbContext.Clientes.Count() == 0) nuovoCliente.Id = 1; else nuovoCliente.Id = (_dbContext.Clientes.Max(a => a.Id)) + 1; //a.Id;
            nuovoCliente.Username = cliente.Username;
            nuovoCliente.Password = cliente.Password;
            nuovoCliente.Email = cliente.Email;
            nuovoCliente.NumeroTel = cliente.NumeroTel;
            nuovoCliente.Nome = cliente.Nome;
            nuovoCliente.Cognome = cliente.Cognome;
            _dbContext.Clientes.Add(nuovoCliente);
            _dbContext.SaveChanges();
        }
    }
}
