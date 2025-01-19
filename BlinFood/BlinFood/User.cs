using System;
using System.Collections.Generic;

namespace BlinFood
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Pancake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Pancake(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
    public class Donut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Donut(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity {get; set;}
        public object Item {get; set;}
        public decimal TotalPrice {get; set;}

        public OrderItem(int id, int quantity, object item, decimal price)
        {
            Id = id;
            Quantity = quantity;
            Item = item;
            TotalPrice = price;
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems {get; set;}
        public OrderStatus Status { get; set; }
        public Order(int id, User user)
        {
            Id = id;
            User = user;
            OrderItems = new List<OrderItem>();
            Status = OrderStatus.Pending;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Cooking,
        Ready
    }
}