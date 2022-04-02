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
using TestApplication.Common;

namespace TestApplication.WebApi.Controllers
{
    
    public class DeveloperController : ApiController
    {
        
        protected IDeveloperService Service { get; set; }
        
        
        public DeveloperController(IDeveloperService service)
        {
            Service = service;               
        }



        [HttpGet]
        [Route("api/RetrieveAllDevs")]
        public async Task<HttpResponseMessage> RetrieveListOfDevelopersAsync
            ([FromUri]DeveloperSortingRest sortInfo, [FromUri]DeveloperPagingRest pageInfo, [FromUri]DeveloperFilteringRest filterInfo)   
        {
            IDeveloperSorting sorting = sortInfo;
            IDeveloperPaging paging = pageInfo;
            IDeveloperFiltering filtering = filterInfo;

            List<IDeveloper> developerList = await Service.RetrieveListOfDevelopersAsync(sorting, paging, filtering);

            if (developerList != null)
            {
                var devsMapped = new List<DeveloperRest>();
                foreach (Developer developer in developerList)
                {
                    var devRest = new DeveloperRest();
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
        public async Task<HttpResponseMessage> InsertDeveloperAsync(DeveloperRestInsert developerRestInsert)
        {
            if (developerRestInsert != null)
            {
                Developer newDeveloper = new Developer
                {
                    Id = developerRestInsert.Id,
                    FirstName = developerRestInsert.FirstName,
                    LastName = developerRestInsert.LastName,
                    ProjectId = developerRestInsert.ProjectId,
                    Salary = developerRestInsert.Salary
                };

                await Service.InsertDeveloperAsync(newDeveloper);

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
            if (await Service.UpdateDeveloperProjectByIdAsync(devId, newProjectId) != null)
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
            if (await Service.DeleteDeveloperByIdAsync(devId) != null)
            {   
                return Request.CreateResponse(HttpStatusCode.OK, $"Developer deleted!");
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

    public class DeveloperSortingRest : IDeveloperSorting
    {
        public string SortBy { get; set; }

        public string SortOrder { get; set; }


    }

    public class DeveloperPagingRest : IDeveloperPaging
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }


    }

    public class DeveloperFilteringRest : IDeveloperFiltering
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectId { get; set; }
        public string Salary { get; set; }

    }

}
