using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Family : User
    {
        public Guid FamilyID { get; set; }
 
        private string FamilyOIB;

        public override string BorrowBook() // overriden with appropriate data (no first name) which applies exclusively to families
        {
            return $"Family {LastName} (Email: {Email}) has borrowed a book.";
        }

        public void GetOIB()
        {
            Console.WriteLine("Enter OIB: ");
            FamilyOIB = Console.ReadLine();
        }

        public string ReturnFamilyOIB()
        {
            return FamilyOIB;
        }

        public Guid ReturnID()
        {
            return FamilyID;
        }



    }
}
