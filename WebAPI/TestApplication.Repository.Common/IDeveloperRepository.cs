using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common;
using TestApplication.Model.Common;

namespace TestApplication.Repository.Common
{
    public interface IDeveloperRepository
    {
        Task<List<IDeveloper>> RetrieveListOfDevelopersAsync(IDeveloperSorting sort, IDeveloperPaging paging, IDeveloperFiltering filtering);        
        
        Task<IDeveloper> InsertDeveloperAsync(IDeveloper developer);

        Task<IDeveloper> UpdateDeveloperProjectByIdAsync(int devId, int newProjectId);

        Task<IDeveloper> DeleteDeveloperByIdAsync(int devId);        

        
    }
}
