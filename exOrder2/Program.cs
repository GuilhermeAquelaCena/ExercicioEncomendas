using exOrderT5.entities;
using exOrderT5.entities.Enums;
using System;
using System.ComponentModel.Design;
using exOrderT5.entities;
using System.Collections.Generic;
using System.Reflection;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace exOrderT5
{
    internal class Program
    {
        static public List<Client> listaClientes = new List<Client>();
        static public List<Product> listaProducts = new List<Product>();
        static public List<Order> ListaEncomdendas = new List<Order>();
        static void Main(string[] args)
        {

            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("MENU: ");
                Console.WriteLine("1. Criar Cliente");
                Console.WriteLine("2. Apresentar Cliente");
                Console.WriteLine("3. Inserir Cliente");
                Console.WriteLine("4. Apresentar Produto");
                Console.WriteLine("5. Inserir Encomenda");
                Console.WriteLine("6. Apresentar Encomendas");
                Console.WriteLine("7. Sair");
                Console.Write("Opção: ");
                string op = Console.ReadLine();


                switch (op)
                {
                    case "1":
                        InserirCliente();
                        break;
                    case "2":
                        ApresentarClientes();
                        break;
                    case "4":
                         ApresentarProdutos();
                        break;
                    case "5":
                        InserirEncomenda();
                        break;
                    case "6":
                        ApresentarEncomendas();
                        break;
                    case "7":
                        break;
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

        }
        static public void InserirCliente()
        {
            Console.Write("Nome: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("Email: ");
            string emailCliente = Console.ReadLine();
            Console.Write("Data de nascimento: ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());
            Client cliente = new Client(nomeCliente, emailCliente, dataNasc);
            listaClientes.Add(cliente);
            Console.WriteLine("Cliente inserido com sucesso!");

        }
        static public void ApresentarClientes()
        {
            Console.WriteLine("Lista de Cliente no Sistema");
            foreach (Client cl in listaClientes)
                Console.WriteLine(cl.ToString());
        }
        static public void InserirProdutos()
        {

            Console.Write("Nome do Produto: ");
            string nomeProduto = Console.ReadLine();

            Console.Write("Preço (PVP): ");
            double pvp = double.Parse(Console.ReadLine());
            Product produto = new Product(nomeProduto, pvp);
            listaProducts.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso");
        }
        static public void ApresentarProdutos()
        {
            Console.WriteLine("\n\nLista de Produtos no Sistema: ");
            foreach (Product pd in listaProducts)
                Console.WriteLine(pd.ToString());
        }
        static public void InserirEncomenda()
        {
            Console.WriteLine("\n\nInserir Dados da nova encomenda");
            Console.WriteLine("Estado da Encomenda");
            OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            DateTime dt = DateTime.Now;

            Console.WriteLine("\nSelecione o Cliente proprietário da encomenda: ");
            for (int i = 0; i < listaProducts.Count; i++)
                Console.WriteLine($"{i} - {listaClientes[i].Name}");
            Console.Write("Indice do cliente: ");
            int id =int.Parse(Console.ReadLine());
            if (id > 0 && id < listaProducts.Count)
            {
                Order order = new Order(dt, os, listaClientes[id]);
                ListaEncomdendas.Add(order);
                bool inserirItems = true;
                while (inserirItems)
                {
                    Console.WriteLine("\nSelecione o produto: ");
                    for (int i = 0; i < listaProducts.Count; i++)
                        Console.WriteLine($"{i} - {listaProducts[i].Name}");
                    Console.Write("Indice dos Produtos: ");
                    id = int.Parse(Console.ReadLine());
                    if (id >= 0 && id < listaProducts.Count)
                    {
                        Product p = listaProducts[id];
                        Console.Write("Quantidade: ");
                        int qt = int.Parse(Console.ReadLine());
                        Console.Write("Preço: ");
                        double preco = double.Parse(Console.ReadLine());
                        order.AddItem(new OrderItem(p, qt, preco));
                        Console.Write("Adicionar novo item? s/n: ");
                        if (Console.ReadLine().ToUpper() != "S") inserirItems = false;
                    }
                    else
                        Console.WriteLine("Indice do produto inválido!");
                }
            }
            else
                Console.WriteLine("Indice de cliente inválido");
        }
       
        static public void ApresentarEncomendas()
        {
            Console.WriteLine("\n\nLista de encomendas no sistema: ");
            foreach (Order or in ListaEncomdendas)
                Console.WriteLine(or.ToString());   
        }
    }
}