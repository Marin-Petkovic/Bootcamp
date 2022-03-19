using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class SubscribedUser : User
    {
        public void GetSubscriptionType()
        {
            do
            {
                Console.WriteLine("Enter subscription type (\"s\" for student or \"f\" for family): ");
                SubscriptionType = Console.ReadLine();
            }
            while (SubscriptionType.ToLower() != "s" && SubscriptionType.ToLower() != "f");
        }

        public string ReturnSubscriptionType()
        {
            return SubscriptionType;
        }
    }
}
