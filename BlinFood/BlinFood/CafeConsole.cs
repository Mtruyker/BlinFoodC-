using System;

namespace BlinFood
{
    public class CafeConsole
{
    private readonly OrderService _orderService;
    private readonly NotificationService _notificationService;
    private readonly PancakeRepository _pancakeRepository;
    private readonly DonutRepository _donutRepository;
    public CafeConsole(OrderService orderService, NotificationService notificationService, PancakeRepository pancakeRepository, DonutRepository donutRepository)
    {
        _orderService = orderService;
        _notificationService = notificationService;
        _pancakeRepository = pancakeRepository;
        _donutRepository = donutRepository;
    }

    public void Run()
    {
         Console.WriteLine("Добро пожаловать в наше кафе пончиков и блинов!");

         while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Сделать заказ");
            Console.WriteLine("2. Проверить статус заказа");
            Console.WriteLine("3. Выход");

            Console.Write("Введите номер действия: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlaceOrder();
                    break;
                case "2":
                   CheckOrderStatus();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    break;
            }
        }
    }
   private void PlaceOrder()
    {
      Console.Write("Введите ваше имя: ");
       var userName = Console.ReadLine();
       var user = new User(new Random().Next(1,1000), userName);
       var order = _orderService.PlaceOrder(user);
        while(true)
        {
            Console.WriteLine("\nВыберите позицию для добавления в заказ:");
            Console.WriteLine("1. Добавить блин");
            Console.WriteLine("2. Добавить пончик");
            Console.WriteLine("3. Закончить заказ");
            Console.Write("Введите номер действия: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPancakeToOrder(order);
                    break;
                case "2":
                   AddDonutToOrder(order);
                    break;
                case "3":
                  CompleteOrder(order);
                 return;
                 default:
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    break;
           }
        }
    }

    private void AddPancakeToOrder(Order order)
    {
      Console.WriteLine("\nДоступные блины:");
      var pancakes = _pancakeRepository.GetAllPancakes();
      foreach (var pancake in pancakes)
        {
            Console.WriteLine($"{pancake.Id}. {pancake.Name} - {pancake.Price} руб.");
        }
       Console.Write("Выберите номер блина: ");
        if (!int.TryParse(Console.ReadLine(), out var pancakeId))
        {
            Console.WriteLine("Неверный номер блина. Попробуйте еще раз.");
            return;
        }
       var selectedPancake = _pancakeRepository.GetPancakeById(pancakeId);
       if (selectedPancake == null)
        {
         Console.WriteLine("Неверный номер блина. Попробуйте еще раз.");
           return;
        }
         Console.Write("Введите количество блинов: ");
        if (!int.TryParse(Console.ReadLine(), out var quantity))
        {
          Console.WriteLine("Неверное количество. Попробуйте еще раз.");
            return;
        }

       _orderService.AddItemToOrder(order, selectedPancake, quantity);
    }
    private void AddDonutToOrder(Order order)
    {
        Console.WriteLine("\nДоступные пончики:");
      var donuts = _donutRepository.GetAllDonuts();
       foreach (var donut in donuts)
        {
           Console.WriteLine($"{donut.Id}. {donut.Name} - {donut.Price} руб.");
        }
      Console.Write("Выберите номер пончика: ");

        if (!int.TryParse(Console.ReadLine(), out var donutId))
        {
          Console.WriteLine("Неверный номер пончика. Попробуйте еще раз.");
            return;
        }
        var selectedDonut = _donutRepository.GetDonutById(donutId);
       if (selectedDonut == null)
        {
         Console.WriteLine("Неверный номер пончика. Попробуйте еще раз.");
           return;
        }
        Console.Write("Введите количество пончиков: ");
        if (!int.TryParse(Console.ReadLine(), out var quantity))
        {
             Console.WriteLine("Неверное количество. Попробуйте еще раз.");
             return;
        }
         _orderService.AddItemToOrder(order, selectedDonut, quantity);
    }

    private void CompleteOrder(Order order)
    {
       Console.WriteLine($"Заказ №{order.Id} принят. Ваш заказ будет приготовлен.");
       // Имитируем время приготовления
       System.Threading.Thread.Sleep(2000);

        _orderService.UpdateOrderStatus(order.Id, OrderStatus.Ready);
       _notificationService.SendNotification(order);
    }

     private void CheckOrderStatus()
    {
        Console.Write("Введите номер вашего заказа: ");
        if (!int.TryParse(Console.ReadLine(), out var orderId))
        {
            Console.WriteLine("Неверный номер заказа.");
             return;
        }

        var order = _orderService.GetOrder(orderId);
        if (order == null)
        {
            Console.WriteLine("Заказ не найден.");
            return;
        }

        Console.WriteLine($"Статус заказа №{order.Id}: {order.Status}");
    }
}
}