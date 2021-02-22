using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IOrder
    {
        public IEnumerable<IProduit> Produtcs { get; set; }
        public double GetPrice();
    }
}
