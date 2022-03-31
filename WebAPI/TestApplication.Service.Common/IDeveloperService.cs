using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common;
using TestApplication.Model.Common;

namespace TestApplication.Service.Common
{
    public interface IDeveloperService
    {
        Task<List<IDeveloper>> RetrieveListOfDevelopersAsync(ISorting sorting, IPaging paging, IFiltering filtering);
        
        Task<IDeveloper> InsertDeveloperAsync(IDeveloper developer);

        Task<IDeveloper> UpdateDeveloperProjectByIdAsync(int devId, int projectId);

        Task<IDeveloper> DeleteDeveloperByIdAsync(int devId);

        Task<List<IDeveloper>> RetrieveDevelopersOnProjectAsync(int id);
        
    }
}
