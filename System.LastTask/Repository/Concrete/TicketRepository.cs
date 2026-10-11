using Microsoft.EntityFrameworkCore;
using System.LastTask.Data;
using System.LastTask.Entities;
using System.LastTask.Repository.Abstract;

namespace System.LastTask.Repository.Concrete
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDBContext _context;

        public TicketRepository(TicketDBContext context)
        {
            _context = context;   
        }

        public void Add(Ticket entity)
        {
            _context.Tickets.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.SingleOrDefaultAsync(t => t.Id == id);
        }

        public void Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
        }
    }
}
