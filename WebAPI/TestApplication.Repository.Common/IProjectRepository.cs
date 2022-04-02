using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.GETProject;
using TestApplication.Model.Common;

namespace TestApplication.Repository.Common
{
    public interface IProjectRepository
    {
        Task<List<IProject>> RetrieveProjectsAsync(IProjectSorting sorting, IProjectPaging paging, IProjectFiltering filtering);

        Task<IProject> InsertProjectAsync(IProject project);

        Task<IProject> UpdateProjectNameByIdAsync(int projectId, string projectName);

        
        Task<IProject> DeleteProjectByIdAsync(int projectId);
        
    }
}
