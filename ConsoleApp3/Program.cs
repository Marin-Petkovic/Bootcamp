using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--BOOK INVENTORY SYSTEM--\n");

            Inventory inventory1 = new Inventory();
            inventory1.ListOfBooks = new List<Book>();

            string EscapeKey = "1";
            do
            {
                SubscribedUser subscribedUser1 = new SubscribedUser();
                Book book1 = new Book();

                Console.WriteLine("Enter book title: ");
                book1.Title = Console.ReadLine();

                Console.WriteLine("Enter book author: ");
                book1.Author = Console.ReadLine();

                // Checking for subscription type using a protected property
                // which primarily belongs to "User" class, but is inherited by "SubscribedUser" class
                subscribedUser1.GetSubscriptionType();

                if (subscribedUser1.ReturnSubscriptionType().ToLower() == "s")
                {
                    Student student1 = new Student();

                    Console.WriteLine("Enter student's first name: ");
                    student1.FirstName = Console.ReadLine();

                    Console.WriteLine("Enter student's last name: ");
                    student1.LastName = Console.ReadLine();

                    Console.WriteLine("Enter student's major: ");
                    student1.Major = Console.ReadLine();

                    Console.WriteLine("Enter student's email: ");
                    student1.Email = Console.ReadLine();

                    // As opposed to previous info, ID is taken through a method
                    // because it's private (in this case, confidential info)
                    student1.GetIdentificationNumber();

                    Console.WriteLine("\n");
                    Console.WriteLine(student1.BorrowBook());
                    Console.WriteLine("\n");
                }
                else if (subscribedUser1.ReturnSubscriptionType().ToLower() == "f") 
                {
  
                    Family family1 = new Family();

                    Console.WriteLine("Enter family's last name: ");
                    family1.LastName = Console.ReadLine();

                    Console.WriteLine("Enter family's email: ");
                    family1.Email = Console.ReadLine();

                    family1.GetIdentificationNumber();

                    Console.WriteLine("\n");
                    Console.WriteLine(family1.BorrowBook());
                    Console.WriteLine("\n");
                }



                inventory1.ListOfBooks.Add(book1);


                Console.WriteLine("Type 1 to end operation, or anything else to continue.");
                EscapeKey = Console.ReadLine();


            }
            while (EscapeKey != "1");

            Console.WriteLine("List of borrowed books:\n");

            foreach (Book book in inventory1.ListOfBooks)
            {
                Console.WriteLine(book.InfoAboutBook());
            }








        }
    }
}
