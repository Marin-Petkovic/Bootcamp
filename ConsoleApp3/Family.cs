using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Family : User
    {
 
        private string FamilyIdentificationNumber;

        public override string BorrowBook() // overriden with appropriate data (no first name) which applies exclusively to families
        {
            return $"Family {LastName} (Email: {Email}) has borrowed a book.";
        }

        public string GetIdentificationNumber()
        {
            Console.WriteLine("Enter identification number: ");
            FamilyIdentificationNumber = Console.ReadLine();
            return FamilyIdentificationNumber;
        }



    }
}
