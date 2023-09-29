using Dominio.Interfaces.Genericas;
using Entities.Entidades;

namespace Dominio.Interfaces.Tickets
{
    public interface InterfaceTicket : InterfaceGenerics<Ticket>
    {
        Task<IList<Ticket>> ListarTickets(string status);
    }
}