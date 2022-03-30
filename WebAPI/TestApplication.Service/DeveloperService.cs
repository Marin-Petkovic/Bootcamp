using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model.Common;
using TestApplication.Repository;
using TestApplication.Repository.Common;
using TestApplication.Service.Common;
using TestApplicationModel;

namespace TestApplication.Service
{
    public class DeveloperService : IDeveloperService
    {
        public IDeveloperRepository DeveloperRepository;

        // Constructor
        public DeveloperService(IDeveloperRepository developerRepository)
        {
            this.DeveloperRepository = developerRepository;
        }       
        
        
        public async Task<List<IDeveloper>> RetrieveListOfDevelopersAsync()
        {
            return await DeveloperRepository.RetrieveListOfDevelopersAsync();
        }
        

        public async Task<IDeveloper> InsertDeveloperAsync(IDeveloper developer)
        {
            return await DeveloperRepository.InsertDeveloperAsync(developer);
        }

        
        public async Task<IDeveloper> UpdateDeveloperProjectByIdAsync(int devId, int projectId)
        {
            return await DeveloperRepository.UpdateDeveloperProjectByIdAsync(devId, projectId);
        }

        
        public async Task<IDeveloper> DeleteDeveloperByIdAsync(int devId)
        {
            return await DeveloperRepository.DeleteDeveloperByIdAsync(devId);
        }
        

        public async Task<List<IDeveloper>> RetrieveDevelopersOnProjectAsync(int id)
        {
            return await DeveloperRepository.RetrieveDevelopersOnProjectAsync(id);
        }
        
    }
}
