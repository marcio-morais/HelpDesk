using Dominio.Interfaces.Tickets;
using Entities.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorios.Genericos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositoryTicket : RepositoryGenerics<Ticket>, InterfaceTicket
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryTicket()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Ticket>> ListarTickets(string status)
        {
            using (var banco = new ContextBase(_OptionBuilder))
            {
                return await
                    (from s in banco.Ticket where s.Status.Equals(status) select s).AsNoTracking().ToListAsync();
            }
        }
    }
}