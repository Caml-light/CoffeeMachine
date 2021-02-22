using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class SQLUsers
    {
        public static UserPref GetOne(Guid? guid)
        {
            if (guid is null)
                return null;
            else
            throw new NotSupportedException();
        }

        public static void Save(UserPref pref)
        {
            Delete(pref);
            Create(pref);
        }

        public static void Delete(UserPref pref)
        {
            throw new NotSupportedException();
        }


        private static void Create(UserPref pref)
        {
            throw new NotSupportedException();
        }
    }
}
