using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exOrderT5.entities.Enums;

namespace exOrderT5.entities.Enums
{
    internal class Order
    {
        private DateTime moment;
        private OrderStatus orderStatus;
        private List<OrderItem> listaEncomendas = new List<OrderItem>();
        private Client client;

        public Order(DateTime moment, OrderStatus orderStatus, Client client)
        {
            this.moment = moment;
            this.orderStatus = orderStatus;
            this.client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            listaEncomendas.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            listaEncomendas.Remove(orderItem);
        }

        public double Total()
        {
            double vTotal = 0;
            foreach (OrderItem item in listaEncomendas)
                vTotal += item.SubTotal();
            return vTotal;
        }
        public override string ToString()
        {
            string descItems = "";
            foreach (OrderItem item in listaEncomendas)
                descItems += "\n\t" + item.ToString();


            return $"Dadps da encomenda: " +
                $"\n\tCliente: {client.ToString()}" +
               $"\n\tData/Hora:{moment.ToLongDateString()}" +
               $"{moment.ToLongTimeString()}" +
               $"Estado:{(OrderStatus)orderStatus} + " +
               $"\n\n\tITEMS ENCOMENDADOS:\n\t\t{descItems}";
        }
    }
}
