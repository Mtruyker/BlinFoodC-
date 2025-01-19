using System;
using System.Collections.Generic;

namespace BlinFood
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order PlaceOrder(User user)
        {
            var orderId = _orderRepository.GetNextId();
            var order = new Order(orderId, user);
            _orderRepository.AddOrder(order);
            return order;
        }
        public void AddItemToOrder(Order order, object item, int quantity)
        {
            var itemId = order.OrderItems.Count + 1;
            decimal itemPrice = 0;
            if (item is Pancake pancake)
            {
                itemPrice = pancake.Price;
            }
            else if (item is Donut donut)
            {
                itemPrice = donut.Price;
            }
            decimal totalPrice = itemPrice * quantity;
            var orderItem = new OrderItem(itemId, quantity, item, totalPrice);
            order.OrderItems.Add(orderItem);
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order != null)
            {
                order.Status = status;
            }
        }
        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }

    }
    public class NotificationService
    {
        public void SendNotification(Order order)
        {
            Console.WriteLine($"Заказ №{order.Id} для {order.User.Name} готов! Подходите за вашим заказом!");
        }
    }
}