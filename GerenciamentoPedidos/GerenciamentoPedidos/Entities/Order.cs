using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoPedidos.Entities.Enum;

namespace GerenciamentoPedidos.Entities
{
    internal class Order
    {
        public DateTime dateTime { get; set; } 
        public OrderStatus orderStatus { get; set; }

        public Client client { get; set; }
        public List<OrderItem> listOrderItem { get; set; } = new List<OrderItem>();
        public Order() { }
        public Order(OrderStatus orderStatus, Client client)
        {
            this.client = client;
            this.orderStatus = orderStatus;
            dateTime = DateTime.Now;
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
        
            sb.AppendLine("Momento do pedido: " + dateTime);
            sb.AppendLine("Status do pedido: " + orderStatus);
            sb.AppendLine($"Cliente: {client}");
            sb.AppendLine("Itens do pedido: ");

            foreach (OrderItem item in listOrderItem)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("Preco total: $" + Total());

            return sb.ToString();

        }

        public void AddItem(OrderItem orderItem)
        {
            listOrderItem.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            listOrderItem.Remove(orderItem);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem orderItem in listOrderItem)
            {
                sum += orderItem.SubTotal();
            }

            return sum;
        }
    }
}
