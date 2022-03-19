using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface IUser
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string BorrowBook();
        
    }
}
