using System;
using System.Collections.Generic;
using System.Text;
using CoffeeMachine;

namespace CoffeeMachine.Test
{
    public class UserPrefDataServiceMock : IUserPrefDataService
    {
        Dictionary<Guid, UserPref> userPrefs = new();

        public void Delete(UserPref pref)
        {
            if(pref?.Guid is not null)
            {
                userPrefs.Remove(pref.Guid.Value);
            }
        }

        public UserPref GetUser(Guid? guid)
        {
            if (guid is not null)
            {
                if (userPrefs.TryGetValue(guid.Value, out var pref))
                {
                    return pref;
                }
            }

            return new UserPref();
        }

        public void SaveUser(UserPref pref)
        {
            if(pref?.Guid is not null)
            {
                Delete(pref);
                userPrefs.Add(pref.Guid.Value, pref);
            }
        }
    }
}
