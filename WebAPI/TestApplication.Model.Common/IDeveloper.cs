using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model.Common
{
    public interface IDeveloper
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int projectId { get; set; }
        int salary { get; set; }
    }
}
