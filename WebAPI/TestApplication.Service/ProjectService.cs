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
        public List<Project> RetrieveProjects()
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return projectRepo.RetrieveProjects();
        }


        public Project InsertProject(Project project)
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return projectRepo.InsertProject(project);
        }


        public Project UpdateProjectNameByID(int id, string projectName)
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return projectRepo.UpdateProjectNameByID(id, projectName);
        }


        public Project DeleteProjectByID(int id)
        {
            ProjectRepository projectRepo = new ProjectRepository();

            return projectRepo.DeleteProjectByID(id);
        }
    }
}
