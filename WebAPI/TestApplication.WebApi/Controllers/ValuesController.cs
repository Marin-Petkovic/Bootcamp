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
            List<Developer> developers = new List<Developer>();
            List<DeveloperRest> developersMapped = new List<DeveloperRest>();

            developers = service.RetrieveDevs();

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
     
        
        [HttpGet]
        [Route("api/RetrieveDevsOnProject")]
        public HttpResponseMessage RetrieveDevelopersOnProject(int id)
        {

            DeveloperService service = new DeveloperService();
            List<Developer> developers = new List<Developer>();
            List<DeveloperRest> developersMapped = new List<DeveloperRest>();

            developers = service.DevsOnProject(id);

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


        [HttpPost]
        [Route("api/InsertDev")]
        public HttpResponseMessage InsertDeveloper(Developer developer)
        {
            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();            

            dev = service.InsertDev(developer);

            //mapping - transfer specific data to devRest (data to be displayed to the user), in this case developerID is omitted
 
            DeveloperRest devRest = new DeveloperRest();
            devRest.DeveloperID = dev.DeveloperID;
            devRest.FirstName = dev.FirstName;
            devRest.LastName = dev.LastName;
            devRest.ProjectID = dev.ProjectID;

            return Request.CreateResponse(HttpStatusCode.OK, devRest);   
        }


        [HttpPut]
        [Route("api/UpdateDev")]
        public HttpResponseMessage UpdateDeveloperByID(int devId , int projectId)
        {

            DeveloperService service = new DeveloperService();
            Developer dev = new Developer();

            dev = service.UpdateDevProjectByID(devId, projectId);

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

            dev = service.DeleteDevByID(devId);
            
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


        /*
        [HttpGet]
        [Route("api/RetrieveDev")]
        public HttpResponseMessage RetrieveDeveloperInfoByID(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"SELECT * FROM Developer WHERE DeveloperID='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Developer developer = new Developer();
                while (reader.Read())
                { 
                    developer.DeveloperID = reader.GetInt32(0);
                    developer.FirstName = reader.GetString(1);
                    developer.LastName = reader.GetString(2);
                    developer.ProjectID = reader.GetInt32(3);
                }
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, developer);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }
        */
    }

    
    public class DeveloperRest
    {
        public int DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectID { get; set; }     
    }
    
}
