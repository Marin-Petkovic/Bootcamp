using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.GETProject;
using TestApplication.Model.Common;
using TestApplication.Repository.Common;
using TestApplicationModel;

namespace TestApplication.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        static string connectionString = @"Data Source=ST-02\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        public async Task<List<IProject>> RetrieveProjectsAsync(IProjectSorting sorting, IProjectPaging paging, IProjectFiltering filtering)
        {
            StringBuilder queryString = new StringBuilder($"SELECT * FROM Project ");

            if (filtering != null)
            {
                queryString.Append($"WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(filtering.Id))
                {
                    queryString.Append($"AND Id='{filtering.Id}' ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.Name))
                {
                    queryString.Append($"AND Name LIKE '{filtering.Name}' ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.ClientName))
                {
                    queryString.Append($"AND ClientName LIKE '{filtering.ClientName}' ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.Budget))
                {
                    queryString.Append($"AND Budget='{filtering.Budget}' ");
                }
            }

            if (sorting != null)
            {
                queryString.Append($"ORDER BY {sorting.SortBy} {sorting.SortOrder} ");
            }

            if (paging != null && paging.PageNumber > 0 && paging.PageSize > 0)
            {
                queryString.Append($"OFFSET ({paging.PageNumber} - 1) * {paging.PageSize} ROWS FETCH NEXT {paging.PageSize} ROWS ONLY ");
            }

            SqlCommand command = new SqlCommand(queryString.ToString(), connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                List<IProject> listOfProjects = new List<IProject>();
                
                while (await reader.ReadAsync())
                {
                    Project project = new Project
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ClientName = reader.GetString(2),
                        Budget = reader.GetInt32(3)
                    };

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


        public async Task<IProject> InsertProjectAsync(IProject project)
        { 
            SqlCommand command = new SqlCommand
                ($"INSERT INTO Project (Name, ClientName, Budget) VALUES ('{project.Name}', '{project.ClientName}', {project.Budget});", connection);

            await connection.OpenAsync();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return project;
        }


        public async Task<IProject> UpdateProjectNameByIdAsync(int projectId, string projectName)
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

        
        public async Task<IProject> DeleteProjectByIdAsync(int projectId)
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
