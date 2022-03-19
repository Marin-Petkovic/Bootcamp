using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Student : User
    {

        private string StudentIdentificationNumber;

        public string Major { get; set; }

        public override string BorrowBook() // overriden with appropriate data (e.g. major) which applies exclusively to students
        {
            return $"Student {FirstName} {LastName} (Major: {Major}, Email: {Email}) has borrowed a book.";
        }

        public string GetIdentificationNumber()
        {
            Console.WriteLine("Enter identification number: ");
            StudentIdentificationNumber = Console.ReadLine();
            return StudentIdentificationNumber;
        }
   

    }
}
