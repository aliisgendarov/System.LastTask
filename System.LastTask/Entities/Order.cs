namespace System.LastTask.Entities
{
    public class Order
    {
        public Order(int ıd, string? customerName, DateTime createdTime)
        {
            Id = ıd;
            CustomerName = customerName;
            CreatedTime = createdTime;
            OrderItems = new List<OrderItem>();
        }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nCustomer Name: {CustomerName}\nCreated Time: {CreatedTime}";
        }
    }
}
