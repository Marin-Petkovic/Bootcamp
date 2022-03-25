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
        static string connectionString = @"Data Source=ST-02\SQLEXPRESS;Initial Catalog = master; Integrated Security = True";
        // creates, retrieves, updates and deletes instances (or particular information) of developers in a company


        // reader only on select
        // use adapter for others


        [HttpGet]
        [Route("api/RetrieveListOfDevs")]
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



            


            // old code - partially transfered to repository
            /*
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM Developer;", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {               
                List<Developer> listOfDevelopers1 = new List<Developer>();
                while (reader.Read())
                {
                    Developer developer = new Developer();
                    developer.DeveloperID = reader.GetInt32(0);
                    developer.FirstName = reader.GetString(1);
                    developer.LastName = reader.GetString(2);
                    developer.ProjectID = reader.GetInt32(3);

                    listOfDevelopers1.Add(developer);
                }
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, listOfDevelopers1);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            */
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



            /*
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"SELECT * FROM Developer WHERE ProjectID='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {                
                List<Developer> listOfDevs = new List<Developer>();
                while (reader.Read())
                {
                    Developer developer = new Developer();
                    developer.DeveloperID = reader.GetInt32(0);
                    developer.FirstName = reader.GetString(1);
                    developer.LastName = reader.GetString(2);
                    developer.ProjectID = reader.GetInt32(3);

                    listOfDevs.Add(developer);
                }
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, listOfDevs);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Either no such project or no devs working on it");
            }
            */

        }

        [HttpPost]
        [Route("api/InsertDev")]
        public HttpResponseMessage InsertDeveloper(Developer developer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //SqlCommand command = new SqlCommand($"INSERT INTO Developer (FirstName, LastName, ProjectID) VALUES ('{developer.FirstName}', '{developer.LastName}', {developer.ProjectID})", connection);
            //connection.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //connection.Close();

            SqlDataAdapter adapter = new SqlDataAdapter
                ($"INSERT INTO Developer (FirstName, LastName, ProjectID) VALUES ('{developer.FirstName}', '{developer.LastName}', {developer.ProjectID})", connection);
            DataSet developers = new DataSet();
            adapter.Fill(developers, "Developer");

            return Request.CreateResponse(HttpStatusCode.OK, $"Inserted!");
        }

        
        [HttpPut]
        [Route("api/UpdateDeveloper")]
        public HttpResponseMessage UpdateDeveloperByID(int projectId, int devId) // change project on which developer is working
        {
            SqlConnection connection = new SqlConnection(connectionString);

            /*
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Developer;", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds); // data set filled with all rows from Developer table
            */



            
            SqlCommand command2 = new SqlCommand($"SELECT * FROM Developer WHERE DeveloperID='{devId}'", connection);
            connection.Open();
            SqlDataReader reader = command2.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                SqlCommand command = new SqlCommand($"UPDATE Developer SET ProjectID='{projectId}' WHERE DeveloperID='{devId}'", connection);
                reader = command.ExecuteReader();
                return Request.CreateResponse(HttpStatusCode.OK, $"Updated!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found");
            }
            
        }
        

        
        [HttpDelete]
        [Route("api/DeleteDev")]
        public HttpResponseMessage DeleteDeveloperByID(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"DELETE FROM Developer WHERE DeveloperID='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            connection.Close();
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted!");   
        }


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
    }

    
    public class DeveloperRest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int DeveloperID { get; set; }
        public int ProjectID { get; set; }     
    }
    
}
