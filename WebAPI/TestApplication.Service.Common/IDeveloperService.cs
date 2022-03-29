using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model.Common;

namespace TestApplication.Service.Common
{
    public interface IDeveloperService
    {
        List<IDeveloper> RetrieveListOfDevelopersAsync();

        IDeveloper InsertDeveloperAsync();

        IDeveloper UpdateDeveloperProjectByIdAsync();

        IDeveloper DeleteDeveloperByIdAsync();

        List<IDeveloper> RetrieveDevelopersOnProjectAsync();
    }
}
