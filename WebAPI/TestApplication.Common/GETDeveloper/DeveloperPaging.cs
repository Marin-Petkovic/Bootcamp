using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common
{
    public class DeveloperPaging : IDeveloperPaging
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        
    }
}
