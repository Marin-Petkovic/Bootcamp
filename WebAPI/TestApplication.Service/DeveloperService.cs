using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Repository;
using TestApplicationModel;

namespace TestApplication.Service
{
    public class DeveloperService 
    {
        public async Task<List<Developer>> RetrieveListOfDevelopersAsync()
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return await devrep.RetrieveListOfDevelopersAsync();
        }        
        

        public async Task<Developer> InsertDeveloperAsync(Developer developer)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return await devrep.InsertDeveloperAsync(developer);
        }


        public async Task<Developer> UpdateDeveloperProjectByIdAsync(int devId, int projectId)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return await devrep.UpdateDeveloperProjectByIDAsync(devId, projectId);
        }

        
        public async Task<Developer> DeleteDeveloperByIdAsync(int devId)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return await devrep.DeleteDeveloperByIDAsync(devId);
        }


        public async Task<List<Developer>> RetrieveDevelopersOnProjectAsync(int id)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return await devrep.RetrieveDevelopersOnProjectAsync(id);
        }
    }
}
