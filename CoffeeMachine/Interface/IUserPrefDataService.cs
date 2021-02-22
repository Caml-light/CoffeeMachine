using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public interface IUserPrefDataService
    {
        #region UserPref
        public UserPref GetUser(Guid? guid);
        public void SaveUser(UserPref pref);
        public void Delete(UserPref pref);
        #endregion
    }
}
