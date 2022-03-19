using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class SubscribedUser : User
    {
        protected string SubscriptionType { get; set; }

        public void GetSubscriptionType()
        {
            Console.WriteLine("Enter subscription type (\"s\" for student or \"f\" for family): ");
            SubscriptionType = Console.ReadLine();
        }

        public string ReturnSubscriptionType()
        {
            return SubscriptionType;
        }
    }
}
