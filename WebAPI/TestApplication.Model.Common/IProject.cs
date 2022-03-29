using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model.Common
{
    public interface IProject
    {
        int Id { get; set; }
        string Name { get; set; }
        string ClientName { get; set; }
        int Budget { get; set; }
    }
}
