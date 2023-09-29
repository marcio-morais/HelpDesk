using Entities.Entidades;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface ITicketServices
    {
        Task AdicionarTicket(Ticket ticket);

        Task AtualizarTicket(Ticket ticket);
    }
}