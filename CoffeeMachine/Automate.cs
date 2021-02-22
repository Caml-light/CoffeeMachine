using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public abstract class Automate
    {

        private  readonly IUserPrefDataService _dataService;
        protected UserPref _userPref { get; set; }

        protected IList<IProduit> _stock { get; set; }

        public Automate (IUserPrefDataService ds)
        {
            UserPref userPref = new();
            _dataService = ds;
        }

        public Automate()
        {
            UserPref userPref = new();
            _dataService = new UserPrefDataService();
        }

        public virtual void Initilized(IUserPrefDataService ds)
        {
            throw new NotImplementedException();
        }

        protected Guid ReadBadge()
        {
            //read the badge of the user
            return DemoHelper.randUserBadge();
        }

        public void GetUser(Guid? guid)
        {
            if (guid is null)
            {
                _userPref = new();
            }
            else
            {
                _userPref = _dataService.GetUser(guid);
            }
        }

        protected void SaveUserPref()
        {
            _dataService.SaveUser(_userPref);
        }

        public void AddCash(double coin)
        {
            _userPref.Balance += coin;
        }

        public bool PayOrder(IOrder order)
        {
            double orderPrice = order.GetPrice();
            if (_userPref.Balance > orderPrice)
            {
                _userPref.Balance -= orderPrice;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RetrieveCoin()
        {
            if (_userPref.IsUserDetected && (_userPref.Balance > 0))
            {
                ScreenDisplay($"Refund of {_userPref.Balance}");
                
                _userPref.Balance = 0.0;
            }
        }


        protected void ScreenDisplay(string msg)
        {
            Console.WriteLine(msg);
        }

        public virtual void ShutDown()
        {
            throw new NotImplementedException();
        }

        public bool CheckOrder(IOrder order)
        {
            if(Stocks.CheckStock(order))
            {
                Stocks.DecreaseStock(order);
                return true;
            }
            else
            { 
                return false;
            }
        }

        public abstract void ServeOrder(IOrder order);
    }
}
