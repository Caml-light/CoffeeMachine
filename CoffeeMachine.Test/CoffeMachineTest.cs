using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Test
{
    [TestFixture]
    public class CoffeeMachineTest
    { 
        [Test]
        public void GetUserTest()
        {
            CoffeeMachineMock automate = new(new UserPrefDataServiceMock());
            automate.Initialized();

            Guid? guid = Guid.NewGuid();
            automate.GetUser(guid);
            Assert.IsTrue(automate.UserPref is not null);
            Assert.AreEqual(guid, automate.UserPref.Guid);
        }

        [Test]
        public void ServeOrderTest()
        {

            #region ArgumentExceptions
            CoffeeMachineMock automate = new(new UserPrefDataServiceMock());
            var ex = Assert.Throws<ArgumentException>(() => automate.ServeOrder(null));
            Assert.AreEqual("Order argument is null", ex.Message);

            TestOrder order = new();

            var ex2 = Assert.Throws<ArgumentException>(() => automate.ServeOrder(order));
            Assert.AreEqual($"order argument if of type {order.GetType()}. CoffeeMachieOrder Type extepected", ex2.Message);
            #endregion

            CoffeeMachineOrder cmo = GetAnOrder();
            Assert.DoesNotThrow(() => automate.ServeOrder(cmo));

        }

        [Test]
        public void DeliverOrderTest()
        {
            CoffeeMachineMock automate = new(new UserPrefDataServiceMock());
            Assert.AreEqual(0, automate.UserPref.Balance);

            Guid? userId = Guid.NewGuid();
            UserPref pref = new();
            pref.Guid = userId;

            automate.UserPref = pref;
            automate.SaveUserPrefMock();

            var myOrder = GetAnOrder();

            automate.DeliverOrder(myOrder);
            Assert.IsNull(automate.UserPref);
        }

        #region privateHelper
        private CoffeeMachineOrder GetAnOrder()
        {
            Drink drink = new()
            {
                Name = DrinkNames.Coffee,
                Quantity = 10,
                Price = 10,
            };

            Topping topping = new()
            {
                Name = ToppingNames.Sugar,
                Quantity = 3,
                Price = 0,
            };

            Cup cup = new()
            {
                Price = 1,
                Quantity = 1,
            };

           return new(drink, topping, cup);
        }

        #endregion
    }

    public class TestOrder : IOrder
    {
        public IEnumerable<IProduit> Produtcs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
