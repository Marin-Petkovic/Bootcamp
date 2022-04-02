using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.GETProject
{
    public class ProjectPaging : IProjectPaging
    {
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }
    }
}
