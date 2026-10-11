namespace System.LastTask.Entities
{
    public class OrderItem
    {
        public OrderItem(int ıd, int quantity, decimal price, int ticketId, int orderId, Ticket ticket, Order order)
        {
            Id = ıd;
            Quantity = quantity;
            Price = price;
            TicketId = ticketId;
            OrderId = orderId;
            Ticket = ticket;
            Order = order;
        }

        public OrderItem()
        {
            
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int TicketId { get; set; }

        public int OrderId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual Order Order { get; set; }
    }
}
