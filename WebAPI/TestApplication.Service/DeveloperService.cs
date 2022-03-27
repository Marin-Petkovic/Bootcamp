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
        public List<Developer> RetrieveListOfDevelopers()
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.RetrieveListOfDevelopers();
        }
        

        public List<Developer> RetrieveDevelopersOnProject(int id)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.RetrieveDevelopersOnProject(id);
        }


        public Developer InsertDeveloper(Developer developer)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.InsertDeveloper(developer);
        }


        public Developer UpdateDeveloperProjectByID(int devId, int projectId)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.UpdateDeveloperProjectByID(devId, projectId);
        }


        public Developer DeleteDeveloperByID(int devId)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.DeleteDeveloperByID(devId);
        }
    }
}
