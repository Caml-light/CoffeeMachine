using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoffeeMachine
{
    public class CoffeeMachineOrder : IOrder
    {
        public IEnumerable<IProduit> Produtcs { get; set; }

        public CoffeeMachineOrder(IProduit drink, IProduit topping, IProduit cup)
        {
            Produtcs = new IProduit[]{ drink, topping, cup };
        }

        public double GetPrice()
        {
            return Produtcs.Sum(p => p.Price);
        }


    }
}
