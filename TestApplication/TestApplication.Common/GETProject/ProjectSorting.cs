using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.GETProject
{
    public class ProjectSorting : IProjectSorting
    {
        public string SortBy { get; set; }

        public string SortOrder { get; set; }
    }
}
