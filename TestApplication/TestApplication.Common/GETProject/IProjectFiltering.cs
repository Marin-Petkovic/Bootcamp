using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common.GETProject
{
    public interface IProjectFiltering
    {
        string Id { get; set; }
        string Name { get; set; }
        string ClientName { get; set; }
        string Budget { get; set; }
    }
}
