using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using TestApplication.Service;
using TestApplicationModel;
using System.Threading.Tasks;

namespace TestApplication.WebApi.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        [Route("api/RetrieveProjects")]
        public async Task<HttpResponseMessage> RetrieveProjectsAsync()
        {
            ProjectService service = new ProjectService();
            List<Project> listOfProjects = new List<Project>();

            listOfProjects = await service.RetrieveProjectsAsync();

            if (listOfProjects != null)
            {
                List<ProjectRest> projectsMapped = new List<ProjectRest>();

                foreach (Project project in listOfProjects)
                {
                    ProjectRest projectRest = new ProjectRest();
                    projectRest.Id = project.Id;
                    projectRest.Name = project.Name;
                    projectRest.ClientName = project.ClientName;

                    projectsMapped.Add(projectRest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, projectsMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There are no projects currently");
            }        
        }
        

        [HttpPost]
        [Route("api/InsertProject")]
        public async Task<HttpResponseMessage> InsertProjectAsync(Project project)
        {
            ProjectService service = new ProjectService();
            Project newProject = new Project();

            newProject = await service.InsertProjectAsync(project);

            ProjectRest projectRest = new ProjectRest();
            projectRest.Id = newProject.Id;
            projectRest.Name = newProject.Name;
            projectRest.ClientName = newProject.ClientName;

            return Request.CreateResponse(HttpStatusCode.OK, projectRest);
        }

        
        [HttpPut]
        [Route("api/UpdateProject")]
        public async Task<HttpResponseMessage> UpdateProjectNameByIdAsync(int id, string newProjectName)
        {
            ProjectService service = new ProjectService();
            Project newProject = new Project();

            newProject = await service.UpdateProjectNameByIdAsync(id, newProjectName);

            if (newProject != null)
            {
                ProjectRest projectMapped = new ProjectRest();
                projectMapped.Id = newProject.Id;
                projectMapped.Name = newProject.Name;
                projectMapped.ClientName = newProject.ClientName;

                return Request.CreateResponse(HttpStatusCode.OK, projectMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }     
        
        
        [HttpDelete]
        [Route("api/DeleteProject")]
        public async Task<HttpResponseMessage> DeleteProjectByIDAsync(int id)
        {
            ProjectService service = new ProjectService();
            Project newProject = new Project();

            newProject = await service.DeleteProjectByIdAsync(id);

            if (newProject != null)
            {
                ProjectRest projectMapped = new ProjectRest();
                projectMapped.Id = newProject.Id;
                projectMapped.Name = newProject.Name;
                projectMapped.ClientName = newProject.ClientName;

                return Request.CreateResponse(HttpStatusCode.OK, projectMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        } 
    }


    public class ProjectRest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }

    }
}