using System.LastTask.Data;
using System.LastTask.Entities;
using System.LastTask.UnitofWork;

namespace System.LastTask.Services
{
    public class OrderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly object _locker = new();

        public int SuccessfulOrders { get; private set; }

        public OrderService(TicketDBContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public async Task BuyAsync(string customerName, int ticketId)
        {
            await _semaphore.WaitAsync();

            try
            {
                var ticket = await _unitOfWork.Tickets.GetByIdAsync(ticketId);

                if (ticket is null)
                {
                    Console.WriteLine("Bilet tapılmadı.");
                    return;
                }

                if (ticket.Stock <= 0)
                {
                    Console.WriteLine($"{customerName} Bilet ala bilmedi cunki bilet stokda yoxdur.");
                    return;
                }

                ticket.Stock--;

                var order = new Order()
                {
                    CustomerName = customerName,
                    CreatedTime = DateTime.Now
                };

                var orderItem = new OrderItem
                {
                    Order = order,
                    Ticket = ticket,
                    Quantity = 1
                };

                _unitOfWork.Orders.Add(order);
                _unitOfWork.OrderItems.Add(orderItem);

                await _unitOfWork.SaveChangesAsync();

                lock (_locker)
                {
                    SuccessfulOrders++;
                }

                Console.WriteLine($"{customerName} bilet aldi");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
