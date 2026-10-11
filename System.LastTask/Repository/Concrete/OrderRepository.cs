using Microsoft.EntityFrameworkCore;
using System.LastTask.Data;
using System.LastTask.Entities;
using System.LastTask.Repository.Abstract;

namespace System.LastTask.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketDBContext _context;

        public OrderRepository(TicketDBContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
