using System.Collections.Generic;
using System;
namespace Pierre.Models
{
    public class Order
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; }
        private static List<Order> _instances = new List<Order> { };
        private static int _idCounter = 1;

        public Order(string title, string description, double price, int quantity, string customerName, DateTime date, int id)
        {
            Title = title;
            Description = description;
            Price = price;
            Quantity = quantity;
            CustomerName = customerName;
            Date = date;
            Id = _idCounter;
            _idCounter++;
            _instances.Add(this);
        }

        public static List<Order> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
            _idCounter = 1; // Reset the ID counter to 1
        }
    }
}