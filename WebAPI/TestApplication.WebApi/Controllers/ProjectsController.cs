using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {

        static List<Project> listOfProjects = new List<Project>();
     
        [HttpGet]
        [Route("api/RetrieveProject")]
        public HttpResponseMessage RetrieveProject(string id)
        {
            Project result = listOfProjects.Find(x => x.ProjectID == id);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Project not found");
            }
        }
        
        
        [HttpPost]
        [Route("api/AddProject")]
        public HttpResponseMessage AddProject(Project project)
        {
            listOfProjects.Add(project);
            return Request.CreateResponse(HttpStatusCode.OK, project);
        }
        

        [HttpPut]
        [Route()]
        public HttpResponseMessage UpdateNumberOfDevsWorking(string id, string number)
        {
            Project result = listOfProjects.Find(x => x.NumberOfDevsWorking == number);
            if (result != null)
            {
                result.NumberOfDevsWorking = number;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Project not found");
            }
        }
   

        [HttpDelete]
        public HttpResponseMessage DeleteByID(string id)
        {
            Project result = listOfProjects.Find(x => x.ProjectID == id);
            if (result != null)
            {
                listOfProjects.Remove(result);
                return Request.CreateResponse(HttpStatusCode.OK, listOfProjects);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Project not found");
            }
            
        }
    }

    public class Project
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Client { get; set; }
        public string NumberOfDevsWorking { get; set; }

    }
}
