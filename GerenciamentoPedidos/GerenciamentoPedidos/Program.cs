using System;
using GerenciamentoPedidos.Entities;
using GerenciamentoPedidos.Entities.Enum;

namespace MyApp { 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bem vindo ao Gerenciador De Pedidos!\nDigite os dados do Cliente:\nNome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data aniversário (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name,email,birthDate);

            Console.Write("Digite os dados do Pedido:\nStatus:\n1)PENDING_PAYMENT\n2)PROCESSING\n3)SHIPPED\n4)DELIVERED\nDigite o Status: ");
            string status = Console.ReadLine();

            OrderStatus orderStatus = Enum.Parse<OrderStatus>(status.ToUpper());

            Order order = new Order(orderStatus, client);

            Console.Write("Quantos itens vai ter nesse pedido? ");
            int itens = int.Parse(Console.ReadLine());

            for (int i = 1; i <= itens; i++)
            {
                Console.WriteLine($"Digite os dados do {i}° pedido. ");
                Console.Write("Nome produto: ");
                name = Console.ReadLine();
                Console.Write("Digite o preço do produto (Use vírgula para decimais) $: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Digite o quantidade do produto: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(name,price);
                OrderItem orderItem = new OrderItem(quantity,price,product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("Resumo do pedido: " );
            Console.WriteLine(order);



        }
    }
}