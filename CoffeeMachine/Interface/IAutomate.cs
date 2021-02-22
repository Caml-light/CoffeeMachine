using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    interface IAutomate
    {
        void Initilized();

        void ShutDown();

        void DeliverOrder(IOrder order);


    }
}
