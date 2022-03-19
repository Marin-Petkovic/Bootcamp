using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Student : User
    {

        public Guid StudentID { get; set; }

        private string StudentOIB;

        public string Major { get; set; }

        public override string BorrowBook() // overriden with appropriate data (e.g. major) which applies exclusively to students
        {
            return $"Student {FirstName} {LastName} (Major: {Major}, Email: {Email}) has borrowed a book.";
        }

        public void GetOIB()
        {
            Console.WriteLine("Enter OIB: ");
            StudentOIB = Console.ReadLine();
            
        }

        public string ReturnStudentOIB()
        {
            return StudentOIB;
        }
        
        public Guid ReturnStudentID()
        {
            return StudentID;
        }
        

   

    }
}
