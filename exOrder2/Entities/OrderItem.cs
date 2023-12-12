using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exOrderT5.entities.Enums
{
    internal class OrderItem
    {
        private Product produto;
        private int quantity;
        private double price;

        public OrderItem(Product produto, int quantity, double price)
        {
            this.produto = produto;
            this.quantity = quantity;
            this.price = price;
        }
        public double SubTotal()
        {
            return quantity * price;
        }
        public override string ToString()
        {
            return $"\nDados do item encomendado" +
                $"\n{produto.ToString()}," +
                $"\nQuantidade:{quantity}," +
                $"\nSubtotal: {SubTotal().ToString("F2")} Euros";
        }
    }
}
