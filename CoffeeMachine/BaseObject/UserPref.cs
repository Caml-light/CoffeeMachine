using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class UserPref
    {
        public Guid? Guid { get; set; }
        public double Balance { get; set; }
        public IOrder LastOrder { get; set; }

        public UserPref()
        {
            Balance = 0.0;
            Guid = null;
        }

        public bool IsUserDetected
        {
            get => Guid is not null;
        }
    }
}

