using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Book : User
    {
        public string Title { get; set; }

        public string Author { get; set; }        

        public string InfoAboutBook()
        {
            return $"{Title}, {Author}";
        }






    }
}
