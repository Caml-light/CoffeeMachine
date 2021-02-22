using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IProduit
    {
        string GetName();
        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
