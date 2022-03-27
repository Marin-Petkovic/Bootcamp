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
    
    public class ValuesController : ApiController
    { 
        [HttpGet]
        [Route("api/RetrieveAllDevs")]
        public HttpResponseMessage RetrieveListOfDevelopers()
        {
            DeveloperService service = new DeveloperService();
            List<Developer> devs = new List<Developer>();
            List<DeveloperRest> devsMapped = new List<DeveloperRest>();

            devs = service.RetrieveListOfDevelopers();

            if (devs != null)
            {
                foreach (Developer developer in devs)
                {
                    DeveloperRest devRest = new DeveloperRest();
                    devRest.DeveloperID = developer.DeveloperID;
                    devRest.FirstName = developer.FirstName;
                    devRest.LastName = developer.LastName;
                    devRest.ProjectID = developer.ProjectID;

                    devsMapped.Add(devRest);
                }

                return Request.CreateResponse(HttpStatusCode.OK, devsMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, devs);
            }
        }                   

        
        [HttpPost]
        [Route("api/InsertDev")]
        public HttpResponseMessage InsertDeveloper(Developer developer)
        {
            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();            

            dev = service.InsertDeveloper(developer);
 
            DeveloperRest devRest = new DeveloperRest();
            devRest.DeveloperID = dev.DeveloperID;
            devRest.FirstName = dev.FirstName;
            devRest.LastName = dev.LastName;
            devRest.ProjectID = dev.ProjectID;

            return Request.CreateResponse(HttpStatusCode.OK, devRest);   
        }


        [HttpPut]
        [Route("api/UpdateDev")]
        public HttpResponseMessage UpdateDeveloperProjectByID(int devId , int projectId)
        {

            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();

            dev = service.UpdateDeveloperProjectByID(devId, projectId);

            if (dev != null)
            {
                DeveloperRest devRest = new DeveloperRest();
                devRest.DeveloperID = dev.DeveloperID;
                devRest.FirstName = dev.FirstName;
                devRest.LastName = dev.LastName;
                devRest.ProjectID = dev.ProjectID;

                return Request.CreateResponse(HttpStatusCode.OK, devRest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, dev);
            }

        }
        

        [HttpDelete]
        [Route("api/DeleteDev")]
        public HttpResponseMessage DeleteDeveloperByID(int devId)
        {
            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();

            dev = service.DeleteDeveloperByID(devId);
            
            if (dev != null)
            {
                DeveloperRest devRest = new DeveloperRest();
                devRest.DeveloperID = dev.DeveloperID;
                devRest.FirstName = dev.FirstName;
                devRest.LastName = dev.LastName;
                devRest.ProjectID = dev.ProjectID;

                return Request.CreateResponse(HttpStatusCode.OK, devRest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, dev);
            }


              
        }
        

        
        [HttpGet]
        [Route("api/RetrieveDevsOnProject")]
        public HttpResponseMessage RetrieveDevelopersOnProject(int projectId)
        {

            DeveloperService service = new DeveloperService();
            List<Developer> developers = new List<Developer>();
            List<DeveloperRest> developersMapped = new List<DeveloperRest>();

            developers = service.RetrieveDevelopersOnProject(projectId);

            if (developers != null)
            {
                foreach (Developer developer in developers)
                {
                    DeveloperRest devRest = new DeveloperRest();
                    devRest.DeveloperID = developer.DeveloperID;
                    devRest.FirstName = developer.FirstName;
                    devRest.LastName = developer.LastName;
                    devRest.ProjectID = developer.ProjectID;

                    developersMapped.Add(devRest);
                }

                return Request.CreateResponse(HttpStatusCode.OK, developersMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found");
            }
        }
    }

    
    public class DeveloperRest
    {
        public int DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectID { get; set; }     
    }
    
}
