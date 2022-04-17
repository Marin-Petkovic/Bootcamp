using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common
{
    public interface IDeveloperFiltering
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string ProjectId { get; set; }
        string Salary { get; set; }
    }
}
