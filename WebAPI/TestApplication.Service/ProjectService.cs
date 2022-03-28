using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Repository;
using TestApplicationModel;

namespace TestApplication.Service
{
    public class ProjectService
    {
        public async Task<List<Project>> RetrieveProjectsAsync()
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return await projectRepo.RetrieveProjectsAsync();
        }


        public async Task<Project> InsertProjectAsync(Project project)
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return await projectRepo.InsertProjectAsync(project);
        }


        public async Task<Project> UpdateProjectNameByIdAsync(int id, string projectName)
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return await projectRepo.UpdateProjectNameByIdAsync(id, projectName);
        }


        public async Task<Project> DeleteProjectByIdAsync(int id)
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return await projectRepo.DeleteProjectByIdAsync(id);
        }
    }
}
