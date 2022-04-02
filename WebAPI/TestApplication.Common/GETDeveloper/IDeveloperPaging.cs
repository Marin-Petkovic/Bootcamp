using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Common
{
    public interface IDeveloperPaging
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}
