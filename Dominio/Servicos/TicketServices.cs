using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.Tickets;
using Entities.Entidades;

namespace Dominio.Servicos
{
    public class TicketServices : ITicketServices
    {
        private readonly InterfaceTicket _interfaceTicket;

        public TicketServices(InterfaceTicket interfaceTicket)
        {
            _interfaceTicket = interfaceTicket;
        }

        public async Task AdicionarTicket(Ticket ticket)
        {
            var valido = ticket.ValidarPropriedadeString(ticket.Descricao, "Descricao");
            if (valido)
                await _interfaceTicket.Add(ticket);
        }

        public async Task AtualizarTicket(Ticket ticket)
        {
            var valido = ticket.ValidarPropriedadeString(ticket.Descricao, "Descricao");
            if (valido)
                await _interfaceTicket.Update(ticket);
        }
    }
}