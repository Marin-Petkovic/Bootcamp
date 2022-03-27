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
                
                while (reader.Read())
                {
                    Project project = new Project();
                    project.ProjectID = reader.GetInt32(0);
                    project.ProjectName = reader.GetString(1);
                    project.ClientName = reader.GetString(2);
                    project.Budget = reader.GetInt32(3);

                    listOfProjects.Add(project);
                } 
                connection.Close();
                return listOfProjects;
            }
            else
            {
                return null;
            }
        }


        public Project InsertProject(Project project)
        { 
            SqlCommand command = new SqlCommand
                ($"INSERT INTO Project VALUES ({project.ProjectID}, '{project.ProjectName}', '{project.ClientName}', {project.Budget});", connection);

            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            connection.Close();
            return project;
        }


        public Project UpdateProjectNameByID(int id, string projectName)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Project WHERE ProjectID={id};", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Project newProject = new Project();

                while (reader.Read())
                {
                    newProject.ProjectID = reader.GetInt32(0);
                    newProject.ProjectName = projectName;
                    newProject.ClientName = reader.GetString(2);
                    newProject.Budget = reader.GetInt32(3);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE Project SET ProjectName='{projectName}' WHERE ProjectID={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
                adapter.UpdateCommand.ExecuteNonQuery();

                connection.Close();
                return newProject;
            }
            else
            {
                return null;
            }
        }

        public Project DeleteProjectByID(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Project WHERE ProjectID={id};", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Project newProject = new Project();

                while (reader.Read())
                {
                    newProject.ProjectID = reader.GetInt32(0);
                    newProject.ProjectName = reader.GetString(1);
                    newProject.ClientName = reader.GetString(2);
                    newProject.Budget = reader.GetInt32(3);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"DELETE FROM Project WHERE ProjectID={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = command2;
                adapter.DeleteCommand.ExecuteNonQuery();

                connection.Close();
                return newProject;               
            }
            else
            {
                return null;
            }

            

        }
    }
}
