using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // creates, retrieves, updates and deletes instances (or particular information) of developers in a company

        static List<Developer> listOfDevelopers = new List<Developer>();
        

        [HttpPost]
        [Route("api/AddDeveloper")]
        public HttpResponseMessage CreateDeveloper(Developer developer)
        {
            listOfDevelopers.Add(developer);
            
            return Request.CreateResponse(HttpStatusCode.OK, developer);
        }
        
        
        [HttpGet]
        [Route("api/RetrieveDevsOnProject")]
        public HttpResponseMessage RetrieveDevelopersOnProject(string projectWorked)
        {
            List<Developer> developersWorking = new List<Developer>();
            
            foreach (Developer developer in listOfDevelopers)
            {
                if (developer.WorkingOnProject == projectWorked)
                    {
                        developersWorking.Add(developer);
                    }
                }
            if (developersWorking.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, developersWorking);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No one is currently working on this project");
            }
        }

        [HttpPut]
        [Route("api/UpdateDeveloper")]
        public HttpResponseMessage UpdateDeveloperProjectByID(string id, string projectWorked)
        {
            Developer result = listOfDevelopers.Find(x => x.DeveloperID == id);
            if (result != null)
            {
                result.WorkingOnProject = projectWorked;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Developer not found");
            }     
        }

        
        [HttpDelete]
        [Route("api/DeleteDeveloper")]
        public HttpResponseMessage DeleteDeveloperByID(Developer developer)
        {
            Developer result = listOfDevelopers.Find(x => x.DeveloperID == developer.DeveloperID);
            
            if (result != null)
            {
                listOfDevelopers.Remove(result);
                return Request.CreateResponse(HttpStatusCode.OK,result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Developer not found");
            }            
        }

        

        [HttpGet]
        [Route("api/RetrieveList")]
        public HttpResponseMessage RetrieveList()
        {
            if (listOfDevelopers.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, listOfDevelopers);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"List is empty");
            }            
        }

        [HttpGet]
        [Route("api/RetrieveDeveloper")]
        public HttpResponseMessage RetrieveDeveloperInfoByID([FromUri] Developer developer)
        {
            Developer result = listOfDevelopers.Find(x => x.DeveloperID == developer.DeveloperID);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Developer not found");
            }
        }
    }


    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeveloperID { get; set; }
        public string WorkingOnProject { get; set; }
        public string InfoAboutEmployee()
        {
            return $"ID: {DeveloperID} {FirstName} {LastName}, Branch: {WorkingOnProject} ";
        }        
    }
}
