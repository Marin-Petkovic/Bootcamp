using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model.Common;

namespace TestApplication.Repository.Common
{
    public interface IProjectRepository
    {
        List<IProject> RetrieveProjectsAsync();

        IProject InsertProjectAsync();

        IProject UpdateProjectNameById();

        IProject DeleteProjectById();
    }
}
