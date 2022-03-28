using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationModel;

namespace TestApplication.Repository
{
    public class DeveloperRepository
    {
        static string connectionString = @"Data Source=MARIN\SQLEXPRESS01;Initial Catalog = master; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);

        public async Task<List<Developer>> RetrieveListOfDevelopersAsync()
        { 
            SqlCommand command = new SqlCommand("SELECT * FROM Developer;", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                List<Developer> listOfDevelopers = new List<Developer>();

                while (await reader.ReadAsync())
                {
                    Developer developer = new Developer();
                    developer.Id = reader.GetInt32(0);
                    developer.FirstName = reader.GetString(1);
                    developer.LastName = reader.GetString(2);
                    developer.ProjectId = reader.GetInt32(3);
                    developer.Salary = reader.GetInt32(4);

                    listOfDevelopers.Add(developer);
                }
                connection.Close();
                return listOfDevelopers;
            }
            else
            {
                return null;
            }

            
        }


        public async Task<List<Developer>> RetrieveDevelopersOnProjectAsync(int projectId)
        {    
            SqlCommand command = new SqlCommand($"SELECT * FROM Developer WHERE ProjectId={projectId};", connection);

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();            

            if (reader.HasRows)
            {
                List<Developer> listOfDevs = new List<Developer>();

                while (await reader.ReadAsync())
                {
                    Developer developer = new Developer();
                    developer.Id = reader.GetInt32(0);
                    developer.FirstName = reader.GetString(1);
                    developer.LastName = reader.GetString(2);
                    developer.ProjectId = reader.GetInt32(3);
                    developer.Salary = reader.GetInt32(4);

                    listOfDevs.Add(developer);
                }
                connection.Close();
                return listOfDevs;
            }
            else
            {
                return null;
            }

            
        }

        
        public async Task<Developer> InsertDeveloperAsync(Developer developer)
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


        public async Task<Developer> UpdateDeveloperProjectByIDAsync(int devId, int newProjectId)
        {
            SqlCommand command1 = new SqlCommand($"SELECT * FROM Developer WHERE Id={devId};", connection);
            await connection.OpenAsync();
            SqlDataReader reader = await command1.ExecuteReaderAsync();

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
                return null;
            }
        }

        
        public async Task<Developer> DeleteDeveloperByIDAsync(int devId)
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
                await adapter.DeleteCommand.ExecuteNonQueryAsync();

                connection.Close();
                return deletedDev;
            }
            else
            {
                return null;
            }
        }
    }
}