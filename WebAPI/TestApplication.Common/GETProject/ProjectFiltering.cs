using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.GETProject
{
    public class ProjectFiltering : IProjectFiltering
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Budget { get; set; }
    }
}
