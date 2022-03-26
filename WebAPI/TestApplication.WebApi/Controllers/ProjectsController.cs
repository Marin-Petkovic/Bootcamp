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
        // delete later
        static string connectionString = @"Data Source=MARIN\SQLEXPRESS01;Initial Catalog = master; Integrated Security = True";



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
        public HttpResponseMessage InsertProject(ProjectRest project)
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

    public class ProjectRest
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }

    }
}