using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class CoffeeMachine : Automate
    {
        #region constructor
        public CoffeeMachine(IUserPrefDataService ds) : base(ds)
        {
        }

        public CoffeeMachine() : base()
        {
        }

        #endregion

        public void Initialized()
        {
            ScreenDisplay("The coffee machine is starting");
        }

        public override void ShutDown()
        {
            Console.WriteLine("The coffee machine is shuting down");
        }

        public void DeliverOrder(IOrder order)
        {
            try
            {
                if(CheckOrder(order) && PayOrder(order))
                {
                    SQLUsers.Save(_userPref);
                    ServeOrder(order);

                    ScreenDisplay("Thank you for your order");                    
                }
                else
                {
                    ScreenDisplay("No Stock for the selected order");
                }                
            }
            catch(Exception ex)
            {
                DemoHelper.Log(ex.Message) ;
            }
            finally
            {
                _userPref = null;
            }
        }

        public override void ServeOrder(IOrder order)
        {
            if(order is null)
            {
                throw new ArgumentException("Order argument is null");
            }

            if(order is not CoffeeMachineOrder)
            {
                throw new ArgumentException($"order argument if of type {order.GetType()}. CoffeeMachieOrder Type extepected");
            }

            CoffeeMachineOrder myOrder = order as CoffeeMachineOrder;

            foreach(var product in myOrder.Produtcs)
            {
                switch(product)
                {
                    case Drink d:
                        SendDrinkInfoToController(d);
                        break;
                    case Topping t:
                        SendToppingInfoToController(t);
                        break;
                    case Cup c:
                        SendCupInfoToController(c.Quantity != 0);
                        break;
                    default:
                        throw new ArgumentException("order include type of product not reconized");
                }
            }

            
        }

        private void SendCupInfoToController(bool isCupNeeded)
        {
            //not implemented
        }

        private void SendDrinkInfoToController(Drink drink)
        {
            //not implemented
        }

        private void SendToppingInfoToController(Topping topping)
        {
            //not implemented
        }
    }
}
