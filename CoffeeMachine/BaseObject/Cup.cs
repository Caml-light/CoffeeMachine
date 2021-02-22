using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Cup : IProduit
    {
        private double _price;
        public int Quantity { get; set; }
        public double Price { get => Quantity == 0 ? 0 : _price; set => _price = value; }

        public string GetName()
        {
            return Quantity == 0 ? "personal recipient" : "recycled Cup";
        }
    }
}
