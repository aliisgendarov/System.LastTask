using Microsoft.EntityFrameworkCore;
using System.LastTask.Data;
using System.LastTask.Entities;
using System.LastTask.Repository.Abstract;

namespace System.LastTask.Repository.Concrete
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TicketDBContext _context;

        public OrderItemRepository(TicketDBContext context)
        {
            _context = context;
        }

        public void Add(OrderItem entity)
        {
            _context.OrderItems.Add(entity);
        }

        public void Delete(OrderItem entity)
        {
            _context.OrderItems.Remove(entity);
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems.SingleOrDefaultAsync(ot => ot.Id == id);
        }

        public void Update(OrderItem entity)
        {
            _context.OrderItems.Update(entity);
        }
    }
}
