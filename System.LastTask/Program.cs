using System.LastTask.Data;
using System.LastTask.Entities;
using System.LastTask.Services;
using System.LastTask.UnitofWork;

namespace System.LastTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new TicketDBContext())
            {
                UnitOfWork uf = new UnitOfWork(context);
                OrderService os = new OrderService(context);

                var t1 = new Ticket()
                {
                    Name = "Ticket1",
                    Price = 12,
                    Stock = 3
                };
                var t2 = new Ticket()
                {
                    Name = "Ticket2",
                    Price = 7,
                    Stock = 2
                };
                var t3 = new Ticket()
                {
                    Name = "Ticket3",
                    Price = 3,
                    Stock = 1
                };
                var t4 = new Ticket()
                {
                    Name = "Ticker4",
                    Price = 25,
                    Stock = 4
                };
                var t5 = new Ticket()
                {
                    Name = "Tiket5",
                    Price = 10,
                    Stock = 7
                };

                uf.Tickets.Add(t1);
                uf.Tickets.Add(t2);
                uf.Tickets.Add(t3);
                uf.Tickets.Add(t4);
                uf.Tickets.Add(t5);

                var check1 = await uf.SaveChangesAsync();

                Console.WriteLine($"Add Row affected: {check1}");

                var ticket1 = await uf.Tickets.GetByIdAsync(1);

                ticket1!.Name = "T1";

                uf.Tickets.Update(ticket1);

                var check2 = await uf.SaveChangesAsync();

                Console.WriteLine($"Update Row affected: {check2}");

                var ticket5 = await uf.Tickets.GetByIdAsync(5);

                uf.Tickets.Delete(ticket5!);

                var check3 = await uf.SaveChangesAsync();

                Console.WriteLine($"Delete Row affected: {check3}");

                Console.WriteLine("\nRead:");

                var tickets = await uf.Tickets.GetAllAsync();

                tickets.ForEach(t => Console.WriteLine(t));

                await os.BuyAsync("Veli Semedov", 2);
                await os.BuyAsync("Semedov Veli", 2);
                await os.BuyAsync("Mahmud Mahmudlu", 2);
            }
        }
    }
}
