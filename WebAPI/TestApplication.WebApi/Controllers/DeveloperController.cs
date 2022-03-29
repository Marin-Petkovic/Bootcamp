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

namespace TestApplication.WebApi.Controllers
{
    
    public class DeveloperController : ApiController
    {
        /*
        protected IDeveloperService service;

        public DeveloperController(IDeveloperService service)
        {
            this.service = service;
        }
        */

        
        [HttpGet]
        [Route("api/RetrieveAllDevs")]
        public async Task<HttpResponseMessage> RetrieveListOfDevelopersAsync()
        {
            DeveloperService service = new DeveloperService();
            List<Developer> developers = new List<Developer>();            

            developers = await service.RetrieveListOfDevelopersAsync();

            if (developers != null)
            {
                List<DeveloperRest> devsMapped = new List<DeveloperRest>();

                foreach (Developer developer in developers)
                {
                    DeveloperRest devRest = new DeveloperRest
                    {
                        Id = developer.Id,
                        FirstName = developer.FirstName,
                        LastName = developer.LastName,
                        ProjectId = developer.ProjectId
                    };

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
        public async Task<HttpResponseMessage> InsertDeveloperAsync(DeveloperRestInsert developerRestInsert)
        {
            if (developerRestInsert != null)
            {
                DeveloperService service = new DeveloperService();
                Developer newDeveloper = new Developer
                {
                    Id = developerRestInsert.Id,
                    FirstName = developerRestInsert.FirstName,
                    LastName = developerRestInsert.LastName,
                    ProjectId = developerRestInsert.ProjectId,
                    Salary = developerRestInsert.Salary
                };

                await service.InsertDeveloperAsync(newDeveloper);

                return Request.CreateResponse(HttpStatusCode.OK, $"Developer inserted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Invalid input");
            }
             
        }


        [HttpPut]
        [Route("api/UpdateDev")]
        public async Task<HttpResponseMessage> UpdateDeveloperProjectByIDAsync(int devId , int newProjectId)
        {
            DeveloperService service = new DeveloperService();           

            if (await service.UpdateDeveloperProjectByIdAsync(devId, newProjectId) != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Developer updated!");
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
            
            if (await service.DeleteDeveloperByIdAsync(devId) != null)
            {   
                return Request.CreateResponse(HttpStatusCode.OK, $"Developer deleted!");
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
            
            developers = await service.RetrieveDevelopersOnProjectAsync(projectId);

            if (developers != null)
            {
                List<DeveloperRest> developersMapped = new List<DeveloperRest>();

                foreach (Developer developer in developers)
                {
                    DeveloperRest devRest = new DeveloperRest
                    {
                        Id = developer.Id,
                        FirstName = developer.FirstName,
                        LastName = developer.LastName,
                        ProjectId = developer.ProjectId
                    };

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

    public class DeveloperRestInsert
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectId { get; set; }
        public int Salary { get; set; }
    }
    
}
