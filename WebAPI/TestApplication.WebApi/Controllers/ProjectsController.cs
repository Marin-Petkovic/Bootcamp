using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace TestApplication.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        static string connectionString = @"Data Source=ST-02\SQLEXPRESS;Initial Catalog = master; Integrated Security = True";

           //static List<Project> listOfProjects = new List<Project>();

        [HttpGet]
        [Route("api/RetrieveProjects")]
        public HttpResponseMessage RetrieveProjects()
        {
            SqlConnection connection = new SqlConnection(connectionString);


            SqlCommand command = new SqlCommand("SELECT * FROM Project;", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<Project> listOfProjects = new List<Project>();
                while (reader.Read())
                {
                    Project project = new Project();
                    project.ProjectID = reader.GetInt32(0);
                    project.ProjectName = reader.GetString(1);
                    project.ClientName = reader.GetString(2);
                    

                    listOfProjects.Add(project);
                }
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, listOfProjects);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There are no projects");
            }
        }
        


        [HttpPost]
        [Route("api/InsertProject")]
        public HttpResponseMessage InsertProject(Project project)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"INSERT INTO Project (ProjectID, ProjectName, ClientName) VALUES ({project.ProjectID}, '{project.ProjectName}', '{project.ClientName}')", connection);
            connection.Open();


            

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();


            connection.Close();
            return Request.CreateResponse(HttpStatusCode.OK, $"Inserted!");
        }



        /*
        [HttpPut]
        [Route("api/UpdateProject")]
        public HttpResponseMessage UpdateNumberOfDevsWorking(int id, string number)
        {
            Project result = listOfProjects.Find(x => x.ProjectID == id);
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
        */
        


        [HttpDelete]
        [Route("api/DeleteProject")]
        public HttpResponseMessage DeleteProjectByID(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"DELETE FROM Project WHERE ProjectID='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            connection.Close();

            return Request.CreateResponse(HttpStatusCode.OK, $"Project deleted!");
        } 
    }

    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }

    }
}
