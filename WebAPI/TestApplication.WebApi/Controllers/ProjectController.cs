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
using TestApplication.Service.Common;
using TestApplication.Model.Common;

namespace TestApplication.WebApi.Controllers
{
    public class ProjectController : ApiController
    {

        protected IProjectService Service { get; set; }


        public ProjectController(IProjectService service)
        {
            Service = service;
        }


        [HttpGet]
        [Route("api/RetrieveProjects")]
        public async Task<HttpResponseMessage> RetrieveProjectsAsync()
        {
            var listOfProjects = await Service.RetrieveProjectsAsync();

            if (listOfProjects != null)
            {
                List<ProjectRest> projectsMapped = new List<ProjectRest>();

                foreach (Project project in listOfProjects)
                {
                    ProjectRest projectRest = new ProjectRest
                    {
                        Id = project.Id,
                        Name = project.Name,
                        ClientName = project.ClientName
                    };

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
        public async Task<HttpResponseMessage> InsertProjectAsync(ProjectRestInsert projectRestInsert)
        { 
            if (projectRestInsert != null)
            {
                Project newProject = new Project
                {
                    Id = projectRestInsert.Id,
                    Name = projectRestInsert.Name,
                    ClientName = projectRestInsert.ClientName,
                    Budget = projectRestInsert.Budget
                };

                await Service.InsertProjectAsync(newProject);

                return Request.CreateResponse(HttpStatusCode.OK, $"Project inserted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Invalid input");
            }
        }

        
        [HttpPut]
        [Route("api/UpdateProject")]
        public async Task<HttpResponseMessage> UpdateProjectNameByIdAsync(int id, string newProjectName)
        {

            if (await Service.UpdateProjectNameByIdAsync(id, newProjectName) != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Project updated!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }     
        
        
        [HttpDelete]
        [Route("api/DeleteProject")]
        public async Task<HttpResponseMessage> DeleteProjectByIdAsync(int id)
        {

            if (await Service.DeleteProjectByIdAsync(id) != null)
            {    
                return Request.CreateResponse(HttpStatusCode.OK, $"Project deleted!");
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

    public class ProjectRestInsert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public int Budget { get; set; }
    }
}