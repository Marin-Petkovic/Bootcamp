using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Repository;
using TestApplicationModel;

namespace TestApplication.Service
{
    public class DeveloperService // used for additional business logic
    {
        public List<Developer> RetrieveDevs()
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.DeveloperList();
        }

        public List<Developer> DevsOnProject(int id)
        {
            DeveloperRepository devrep = new DeveloperRepository();

            return devrep.DevsOnProject(id);
        }
    }
}
