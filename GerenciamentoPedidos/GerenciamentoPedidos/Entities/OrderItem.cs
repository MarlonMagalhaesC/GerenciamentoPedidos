using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPedidos.Entities
{
    internal class OrderItem
    {
        public int quantity {  get; set; }
        public double price { get; set; }

        public Product product { get; set; }

        public OrderItem() { }
        public OrderItem(int quantity, double price, Product product)
        {
            this.quantity = quantity;
            this.price = price;
            this.product = product;
        }

        public override string ToString()
        {
            return $"Produto: {product.name}, Quantidade: {quantity}, Preço: {price}, SubTotal: {SubTotal()}";
        }


        public double SubTotal()
        {
            return price * quantity;
        }


        


    }
}
