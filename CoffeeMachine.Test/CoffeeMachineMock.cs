using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Test
{
    public class CoffeeMachineMock : CoffeeMachine
    {
        public UserPref UserPref { get => _userPref; set => _userPref = value; }
        public IList<IProduit> Stock { get => _stock; set => _stock = value; }

        public CoffeeMachineMock(IUserPrefDataService ds) : base(ds)
        { 
        }

        public void SaveUserPrefMock()
        {
            SaveUserPref();
        }
    }
}
