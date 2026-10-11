namespace System.LastTask.Entities
{
    public class Ticket
    {
        public Ticket(int ıd, string name, decimal price, int stock)
        {
            Id = ıd;
            Name = name;
            Price = price;
            Stock = stock;
            OrderItems = new List<OrderItem>();
        }

        public Ticket()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nPrice: {Price}\nStock: {Stock}";
        }
    }
}
