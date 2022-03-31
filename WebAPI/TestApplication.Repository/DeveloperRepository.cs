using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common;
using TestApplication.Model.Common;
using TestApplication.Repository.Common;
using TestApplicationModel;

namespace TestApplication.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        static string connectionString = @"Data Source=MARIN\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        
        
        public async Task<List<IDeveloper>> RetrieveListOfDevelopersAsync(ISorting sorting, IPaging paging, IFiltering filtering)
        {
            StringBuilder queryString = new StringBuilder($"SELECT * FROM Developer ");

            if (filtering.Id != null)
            {
                queryString.Append($"WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(filtering.Id))
                {
                    queryString.Append($"AND Id='{filtering.Id}' ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.FirstName))
                {
                    queryString.Append($"AND FirstName LIKE '%{filtering.FirstName}'% ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.LastName))
                {
                    queryString.Append($"AND LastName LIKE '%{filtering.LastName}%' ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.ProjectId))
                {
                    queryString.Append($"AND ProjectId='{filtering.ProjectId}' ");
                }
                if (!string.IsNullOrWhiteSpace(filtering.Salary))
                {
                    queryString.Append($"AND Salary='{filtering.Salary}' ");
                }
            }
            

            if (sorting != null)
            {
                queryString.Append($"ORDER BY {sorting.SortBy} {sorting.SortOrder} ");
            }
            
            if (paging.PageNumber > 0 && paging.PageSize > 0)
            {
                queryString.Append($"OFFSET ({paging.PageNumber} - 1) * {paging.PageSize} ROWS FETCH NEXT {paging.PageSize} ROWS ONLY ");
            }
            

            
            SqlCommand command = new SqlCommand(queryString.ToString(), connection);

            await connection.OpenAsync();
            
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                List<IDeveloper> listOfDevelopers = new List<IDeveloper>();
                
                while (await reader.ReadAsync())
                {
                    Developer newDeveloper = new Developer();
                    newDeveloper.Id = reader.GetInt32(0);
                    newDeveloper.FirstName = reader.GetString(1);
                    newDeveloper.LastName = reader.GetString(2);
                    newDeveloper.ProjectId = reader.GetInt32(3);
                    newDeveloper.Salary = reader.GetInt32(4);

                    listOfDevelopers.Add(newDeveloper);
                }
                connection.Close();
                return listOfDevelopers;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        
        public async Task<List<IDeveloper>> RetrieveDevelopersOnProjectAsync(int projectId)
        {    
            SqlCommand command = new SqlCommand($"SELECT * FROM Developer WHERE ProjectId={projectId};", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();            

            if (reader.HasRows)
            {
                List<IDeveloper> listOfDevs = new List<IDeveloper>();

                while (await reader.ReadAsync())
                {
                    Developer developer = new Developer
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        ProjectId = reader.GetInt32(3),
                        Salary = reader.GetInt32(4)
                    };

                    listOfDevs.Add(developer);
                }
                connection.Close();
                return listOfDevs;
            }
            else
            {
                connection.Close();
                return null;
            }   
        }

        
        public async Task<IDeveloper> InsertDeveloperAsync(IDeveloper developer)
        {
            SqlCommand command = new SqlCommand
                ($"INSERT INTO Developer (FirstName, LastName, ProjectId, Salary) VALUES ('{developer.FirstName}', '{developer.LastName}', {developer.ProjectId}, {developer.Salary});", connection);

            await connection.OpenAsync();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            
            SqlCommand command2 = new SqlCommand($"SELECT TOP 1 * FROM Developer ORDER BY Id DESC;", connection);
            SqlDataReader reader = await command2.ExecuteReaderAsync();
            Developer insertedDev = new Developer();

            while (await reader.ReadAsync())
            {
                insertedDev.Id = reader.GetInt32(0);
                insertedDev.FirstName = reader.GetString(1);
                insertedDev.LastName = reader.GetString(2);
                insertedDev.ProjectId = reader.GetInt32(3);
                insertedDev.Salary = reader.GetInt32(4);
            }
            
            connection.Close();
            return insertedDev;
        }


        public async Task<IDeveloper> UpdateDeveloperProjectByIdAsync(int devId, int newProjectId)
        {
            SqlCommand command1 = new SqlCommand($"SELECT * FROM Developer WHERE Id={devId};", connection);
            await connection.OpenAsync();
            SqlDataReader reader = command1.ExecuteReader();

            if (reader.HasRows)
            {
                Developer updatedDev = new Developer();

                while (await reader.ReadAsync())
                {
                    updatedDev.Id = reader.GetInt32(0);
                    updatedDev.FirstName = reader.GetString(1);
                    updatedDev.LastName = reader.GetString(2);
                    updatedDev.ProjectId = newProjectId;
                    updatedDev.Salary = reader.GetInt32(4);
                    
                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand($"UPDATE Developer SET ProjectId={newProjectId} WHERE Id={devId};", connection);
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return updatedDev;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        
        public async Task<IDeveloper> DeleteDeveloperByIdAsync(int devId)
        {
            SqlCommand command1 = new SqlCommand($"SELECT * from Developer WHERE Id={devId}", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command1.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                Developer deletedDev = new Developer();

                while (await reader.ReadAsync())
                {
                    deletedDev.Id = reader.GetInt32(0);
                    deletedDev.FirstName = reader.GetString(1);
                    deletedDev.LastName = reader.GetString(2);
                    deletedDev.ProjectId = reader.GetInt32(3);
                    deletedDev.Salary = reader.GetInt32(4);
                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = new SqlCommand($"DELETE FROM Developer WHERE Id={devId}", connection);
                adapter.DeleteCommand.ExecuteNonQuery();

                connection.Close();
                return deletedDev;
            }
            else
            {
                connection.Close();
                return null;
            }
        }  
        
    }
}