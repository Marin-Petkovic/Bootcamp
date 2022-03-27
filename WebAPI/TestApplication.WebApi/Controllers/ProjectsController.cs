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

namespace TestApplication.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        [HttpGet]
        [Route("api/RetrieveProjects")]
        public HttpResponseMessage RetrieveProjects()
        {
            ProjectService service = new ProjectService();
            List<Project> listOfProjects = new List<Project>();

            listOfProjects = service.RetrieveProjects();

            if (listOfProjects != null)
            {
                List<ProjectRest> projectsMapped = new List<ProjectRest>();
                foreach (Project project in listOfProjects)
                {
                    ProjectRest projectRest = new ProjectRest();
                    projectRest.ProjectID = project.ProjectID;
                    projectRest.ProjectName = project.ProjectName;
                    projectRest.ClientName = project.ClientName;

                    projectsMapped.Add(projectRest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, projectsMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }        
        }
        


        [HttpPost]
        [Route("api/InsertProject")]
        public HttpResponseMessage InsertProject(Project project)
        {
            ProjectService service = new ProjectService();
            Project newProject = new Project();

            newProject = service.InsertProject(project);

            ProjectRest projectRest = new ProjectRest();
            projectRest.ProjectID = newProject.ProjectID;
            projectRest.ProjectName = newProject.ProjectName;
            projectRest.ClientName = newProject.ClientName;

            return Request.CreateResponse(HttpStatusCode.OK, projectRest);
        }



        
        [HttpPut]
        [Route("api/UpdateProject")]
        public HttpResponseMessage UpdateProjectNameByID(int id, string projectName)
        {
            ProjectService service = new ProjectService();
            Project newProject = new Project();
            newProject = service.UpdateProjectNameByID(id, projectName);

            if (newProject != null)
            {
                ProjectRest projectMapped = new ProjectRest();
                projectMapped.ProjectID = newProject.ProjectID;
                projectMapped.ProjectName = newProject.ProjectName;
                projectMapped.ClientName = newProject.ClientName;

                return Request.CreateResponse(HttpStatusCode.OK, projectMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found"); // could return newProject, which is null (?)
            }
        }
        
        

        [HttpDelete]
        [Route("api/DeleteProject")]
        public HttpResponseMessage DeleteProjectByID(int id)
        {
            ProjectService service = new ProjectService();
            Project newProject = new Project();

            newProject = service.DeleteProjectByID(id);

            if (newProject != null)
            {
                ProjectRest projectMapped = new ProjectRest();
                projectMapped.ProjectID = newProject.ProjectID;
                projectMapped.ProjectName = newProject.ProjectName;
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
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }

    }
}