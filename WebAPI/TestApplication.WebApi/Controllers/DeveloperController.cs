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
    
    public class DeveloperController : ApiController
    { 
        [HttpGet]
        [Route("api/RetrieveAllDevs")]
        public async Task<HttpResponseMessage> RetrieveListOfDevelopersAsync()
        {
            DeveloperService service = new DeveloperService();
            List<Developer> devs = new List<Developer>();            

            devs = await service.RetrieveListOfDevelopersAsync();

            if (devs != null)
            {
                List<DeveloperRest> devsMapped = new List<DeveloperRest>();

                foreach (Developer developer in devs)
                {
                    DeveloperRest devRest = new DeveloperRest();
                    devRest.Id = developer.Id;
                    devRest.FirstName = developer.FirstName;
                    devRest.LastName = developer.LastName;
                    devRest.ProjectId = developer.ProjectId;

                    devsMapped.Add(devRest);
                }

                return Request.CreateResponse(HttpStatusCode.OK, devsMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There are no developers currently");
            }
        }                   

        
        [HttpPost]
        [Route("api/InsertDev")]
        public async Task<HttpResponseMessage> InsertDeveloperAsync(Developer developer)
        {
            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();            

            dev = await service.InsertDeveloperAsync(developer);
 
            DeveloperRest devRest = new DeveloperRest();
            devRest.Id = dev.Id;
            devRest.FirstName = dev.FirstName;
            devRest.LastName = dev.LastName;
            devRest.ProjectId = dev.ProjectId;

            return Request.CreateResponse(HttpStatusCode.OK, devRest);   
        }


        [HttpPut]
        [Route("api/UpdateDev")]
        public async Task<HttpResponseMessage> UpdateDeveloperProjectByIDAsync(int devId , int newProjectId)
        {
            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();

            dev = await service.UpdateDeveloperProjectByIDAsync(devId, newProjectId);

            if (dev != null)
            {
                DeveloperRest devRest = new DeveloperRest();
                devRest.Id = dev.Id;
                devRest.FirstName = dev.FirstName;
                devRest.LastName = dev.LastName;
                devRest.ProjectId = dev.ProjectId;

                return Request.CreateResponse(HttpStatusCode.OK, devRest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }
        

        [HttpDelete]
        [Route("api/DeleteDev")]
        public async Task<HttpResponseMessage> DeleteDeveloperByIDAsync(int devId)
        {
            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();

            dev = await service.DeleteDeveloperByIDAsync(devId);
            
            if (dev != null)
            {
                DeveloperRest devRest = new DeveloperRest();
                devRest.Id = dev.Id;
                devRest.FirstName = dev.FirstName;
                devRest.LastName = dev.LastName;
                devRest.ProjectId = dev.ProjectId;

                return Request.CreateResponse(HttpStatusCode.OK, devRest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }            
        }
        
        
        [HttpGet]
        [Route("api/RetrieveDevsOnProject")]
        public async Task<HttpResponseMessage> RetrieveDevelopersOnProjectAsync(int projectId)
        {
            DeveloperService service = new DeveloperService();
            List<Developer> developers = new List<Developer>();
            List<DeveloperRest> developersMapped = new List<DeveloperRest>();

            developers = await service.RetrieveDevelopersOnProjectAsync(projectId);

            if (developers != null)
            {
                foreach (Developer developer in developers)
                {
                    DeveloperRest devRest = new DeveloperRest();
                    devRest.Id = developer.Id;
                    devRest.FirstName = developer.FirstName;
                    devRest.LastName = developer.LastName;
                    devRest.ProjectId = developer.ProjectId;

                    developersMapped.Add(devRest);
                }

                return Request.CreateResponse(HttpStatusCode.OK, developersMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }
    }

    
    public class DeveloperRest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectId { get; set; }     
    }
    
}
