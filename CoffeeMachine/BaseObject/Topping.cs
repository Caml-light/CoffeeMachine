using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Topping : IProduit
    {
        public ToppingNames Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public string GetName()
        {
            return Name.ToString();
        }
    }
}
