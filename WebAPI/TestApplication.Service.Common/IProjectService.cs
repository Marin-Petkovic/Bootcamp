using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model.Common;

namespace TestApplication.Service.Common
{
    public interface IProjectService
    {
        List<IProject> RetrieveProjectsAsync();

        IProject InsertProjectAsync();

        IProject UpdateProjectNameByIdAsync();

        IProject DeleteProjectById();
    }
}
