using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Model.Common;
using TestApplication.Repository;
using TestApplication.Repository.Common;
using TestApplicationModel;

namespace TestApplication.Service
{
    public class ProjectService
    {
        protected IProjectRepository ProjectRepository { get; set; }

        public ProjectService(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }

        public async Task<List<IProject>> RetrieveProjectsAsync()
        {


            return await ProjectRepository.RetrieveProjectsAsync();
        }


        public async Task<IProject> InsertProjectAsync(IProject project)
        {

            return await ProjectRepository.InsertProjectAsync(project);
        }


        public async Task<IProject> UpdateProjectNameByIdAsync(int id, string projectName)
        {

            return await ProjectRepository.UpdateProjectNameByIdAsync(id, projectName);
        }


        public async Task<IProject> DeleteProjectByIdAsync(int id)
        {

            return await ProjectRepository.DeleteProjectByIdAsync(id);
        }
    }
}
