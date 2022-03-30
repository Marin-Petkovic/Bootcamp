using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model.Common;

namespace TestApplication.Repository.Common
{
    public interface IDeveloperRepository
    {
        Task<List<IDeveloper>> RetrieveListOfDevelopersAsync();        
        
        Task<IDeveloper> InsertDeveloperAsync(IDeveloper developer);

        Task<IDeveloper> UpdateDeveloperProjectByIdAsync(int devId, int newProjectId);

        Task<IDeveloper> DeleteDeveloperByIdAsync(int devId);        

        Task<List<IDeveloper>> RetrieveDevelopersOnProjectAsync(int projectId);
        
    }
}
