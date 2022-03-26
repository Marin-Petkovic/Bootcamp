using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationModel;

namespace TestApplication.Repository
{
    public class ProjectRepository
    {
        static string connectionString = @"Data Source=MARIN\SQLEXPRESS01;Initial Catalog = master; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        public List<Project> RetrieveProjects()
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Project;", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<Project> listOfProjects = new List<Project>();
                Project project = new Project();
                while (reader.Read())
                {
                    project.ProjectID = reader.GetInt32(0);
                    project.ProjectName = reader.GetString(1);
                    project.ClientName = reader.GetString(2);
                }
                listOfProjects.Add(project);

                connection.Close();
                return listOfProjects;
            }
            else
            {
                return null;
            }
        }
    }
}
