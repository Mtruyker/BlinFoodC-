using System.Collections.Generic;
using System.Linq;

namespace BlinFood
{
    public class OrderRepository
    {
        private List<Order> _orders = new List<Order>();
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
        public int GetNextId()
        {
            return _orders.Count + 1;
        }
        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }
    }

    public class PancakeRepository
    {
        private List<Pancake> _pancakes = new List<Pancake>();
        public PancakeRepository()
        {
            _pancakes.Add(new Pancake(1, "Блин с вареньем", 5.00m));
            _pancakes.Add(new Pancake(2, "Блин со сметаной", 6.00m));
            _pancakes.Add(new Pancake(3, "Блин с шоколадом", 7.00m));
        }
        public List<Pancake> GetAllPancakes()
        {
            return _pancakes;
        }
        public Pancake GetPancakeById(int id)
        {
            return _pancakes.FirstOrDefault(p => p.Id == id);
        }
    }
    public class DonutRepository
    {
        private List<Donut> _donuts = new List<Donut>();
        public DonutRepository()
        {
            _donuts.Add(new Donut(1, "Пончик с глазурью", 4.00m));
            _donuts.Add(new Donut(2, "Пончик с начинкой", 5.00m));
            _donuts.Add(new Donut(3, "Пончик с посыпкой", 4.50m));
        }
        public List<Donut> GetAllDonuts()
        {
            return _donuts;
        }
        public Donut GetDonutById(int id)
        {
            return _donuts.FirstOrDefault(d => d.Id == id);
        }
    }
}