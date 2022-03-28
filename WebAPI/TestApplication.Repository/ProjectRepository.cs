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
        

        public async Task<List<Project>> RetrieveProjectsAsync()
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Project;", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                List<Project> listOfProjects = new List<Project>();
                
                while (await reader.ReadAsync())
                {
                    Project project = new Project();
                    project.Id = reader.GetInt32(0);
                    project.Name = reader.GetString(1);
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


        public async Task<Project> InsertProjectAsync(Project project)
        { 
            SqlCommand command = new SqlCommand
                ($"INSERT INTO Project VALUES ({project.Id}, '{project.Name}', '{project.ClientName}', {project.Budget});", connection);

            await connection.OpenAsync();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return project;
        }


        public async Task<Project> UpdateProjectNameByIdAsync(int projectId, string projectName)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Project WHERE Id={projectId};", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Project updatedProject = new Project();

                while (await reader.ReadAsync())
                {
                    updatedProject.Id = reader.GetInt32(0);
                    updatedProject.Name = projectName;
                    updatedProject.ClientName = reader.GetString(2);
                    updatedProject.Budget = reader.GetInt32(3);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE Project SET Name='{projectName}' WHERE Id={projectId};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return updatedProject;
            }
            else
            {
                return null;
            }
        }


        public async Task<Project> DeleteProjectByIdAsync(int projectId)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Project WHERE Id={projectId};", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Project deletedProject = new Project();

                while (await reader.ReadAsync())
                {
                    deletedProject.Id = reader.GetInt32(0);
                    deletedProject.Name = reader.GetString(1);
                    deletedProject.ClientName = reader.GetString(2);
                    deletedProject.Budget = reader.GetInt32(3);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"DELETE FROM Project WHERE Id={projectId};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = command2;
                await adapter.DeleteCommand.ExecuteNonQueryAsync();

                connection.Close();
                return deletedProject;               
            }
            else
            {
                return null;
            }

            

        }
    }
}
