using System;

namespace BlinFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderRepository = new OrderRepository();
            var pancakeRepository = new PancakeRepository();
            var donutRepository = new DonutRepository();
            var orderService = new OrderService(orderRepository);
            var notificationService = new NotificationService();
            var cafeConsole = new CafeConsole(orderService, notificationService, pancakeRepository, donutRepository);

            cafeConsole.Run();
        }
    }
}