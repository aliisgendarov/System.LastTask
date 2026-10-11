using System.LastTask.Data;
using System.LastTask.Repository.Abstract;
using System.LastTask.Repository.Concrete;

namespace System.LastTask.UnitofWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly TicketDBContext _context;

        public ITicketRepository Tickets { get; }

        public IOrderRepository Orders { get; }

        public IOrderItemRepository OrderItems { get; }

        public UnitOfWork(TicketDBContext context)
        {
            _context = context;
            Tickets = new TicketRepository(_context);
            Orders = new OrderRepository(_context);
            OrderItems = new OrderItemRepository(_context); 
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
