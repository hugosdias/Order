using Pedido.Entities;
using Pedido.Entities.Enums;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter cliente data: ");

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Birth date (DD/MM/YYYY): ");
        DateTime birthDate= DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Order Data: ");
        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Client client = new Client(name, email, birthDate);
        Order order = new Order(DateTime.Now, status, client);

        Console.Write("How many items to this order: ");

        int n = int.Parse(Console.ReadLine());

        for(int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} item data: ");
            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.Write("Product Price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product product = new Product(productName, price);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderItem orderItem = new OrderItem(quantity, price, product);

            order.Additem(orderItem);
        }
        Console.WriteLine();
        Console.WriteLine("ORDER SUMARY: ");
        Console.WriteLine(order);
    }
}