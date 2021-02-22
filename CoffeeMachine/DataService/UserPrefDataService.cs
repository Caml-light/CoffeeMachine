using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class UserPrefDataService : IUserPrefDataService
    {
        public UserPref GetUser(Guid? guid)
        {
            return SQLUsers.GetOne(guid);
        }

        public void SaveUser(UserPref pref)
        {
            SQLUsers.Save(pref);
        }

        public void Delete(UserPref pref)
        {
            SQLUsers.Delete(pref);
        }

    }
}
