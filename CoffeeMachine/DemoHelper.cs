using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public static class DemoHelper
    {
        public static  string[] UserBadges = 
        {
            "1449aa14-165f-4327-8e88-c405b711733e",
            "7ca35958-c9da-48e5-8885-56f4def34ba7",
            "7c1c63a0-7c33-40fb-af44-a83c8b13ab7b",
            "ed38e0d4-96bc-4608-9dd8-644ff44a28fe",
            "8648bafe-9302-4beb-8bc7-afcb4030895b",
            "fd4fe4ac-aaaf-4ae3-8e74-a3036369df81",
            "7eb2e0b3-43a3-4763-9255-404e60c7e81f",
            "99246752-826c-4df8-bcf3-a20d7914ce3d",
            "e832743a-dd57-4802-aaf4-abb94e70adb1",
            "a2df6b75-b88c-460f-80d4-d14ffdf887a0"
        };

        public static Guid randUserBadge()
        {
            Random random = new Random();
            int userNumber = random.Next(10);

            if (userNumber == 10) // simulate no badge
                return Guid.Empty;
            else
                return Guid.Parse(UserBadges[userNumber]);
        }

        public static void Log(string msg)
        {
            //not implemented
        }
    }
}
