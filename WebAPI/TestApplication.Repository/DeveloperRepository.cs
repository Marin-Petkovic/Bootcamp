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

        public List<Developer> DeveloperList()
        { 
            SqlCommand command = new SqlCommand("SELECT * FROM Developer;", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Developer> listOfDevelopers1 = new List<Developer>();
            while (reader.Read())
            {
                Developer developer = new Developer();
                developer.DeveloperID = reader.GetInt32(0);
                developer.FirstName = reader.GetString(1);
                developer.LastName = reader.GetString(2);
                developer.ProjectID = reader.GetInt32(3);
                developer.Salary = reader.GetInt32(4);

                listOfDevelopers1.Add(developer);
            }
            connection.Close();
            return listOfDevelopers1;
        }


        public List<Developer> DevsOnProject(int id)
        {    
            SqlCommand command = new SqlCommand($"SELECT * FROM Developer WHERE ProjectID='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Developer> listOfDevs = new List<Developer>();
            while (reader.Read())
            {
                Developer developer = new Developer();
                developer.DeveloperID = reader.GetInt32(0);
                developer.FirstName = reader.GetString(1);
                developer.LastName = reader.GetString(2);
                developer.ProjectID = reader.GetInt32(3);
                developer.Salary = reader.GetInt32(4);

                listOfDevs.Add(developer);
            }
            connection.Close();
            return listOfDevs;
        }


        public Developer InsertDev(Developer developer)
        {
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO Developer (FirstName, LastName, ProjectID) VALUES ('{developer.FirstName}', '{developer.LastName}', {developer.ProjectID})", connection);
            adapter.InsertCommand.ExecuteNonQuery();

            connection.Close();
            return developer;
        }

        public Developer UpdateDevProjectByID(int devId, int projectId)
        {
            SqlCommand command1 = new SqlCommand($"SELECT * FROM Developer WHERE DeveloperID='{devId}'", connection);
            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows)
            {
                Developer newDev = new Developer();
                while (reader.Read())
                {
                    newDev.DeveloperID = reader.GetInt32(0);
                    newDev.FirstName = reader.GetString(1);
                    newDev.LastName = reader.GetString(2);
                    newDev.ProjectID = projectId;
                    newDev.Salary = reader.GetInt32(4);
                    
                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand($"UPDATE Developer SET ProjectID='{projectId}' WHERE DeveloperID='{devId}'", connection);
                adapter.UpdateCommand.ExecuteNonQuery();

                connection.Close();
                return newDev;
            }
            else
            {
                return null;
            }
        }

        public Developer DeleteDevByID(int devId)
        {
            SqlCommand command1 = new SqlCommand($"SELECT * from Developer WHERE DeveloperID={devId}", connection);
            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows)
            {
                Developer newDev = new Developer();
                while (reader.Read())
                {
                    newDev.DeveloperID = reader.GetInt32(0);
                    newDev.FirstName = reader.GetString(1);
                    newDev.LastName = reader.GetString(2);
                    newDev.ProjectID = reader.GetInt32(3);
                    newDev.Salary = reader.GetInt32(4);
                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = new SqlCommand($"DELETE FROM Developer WHERE DeveloperID={devId}", connection);
                adapter.DeleteCommand.ExecuteNonQuery();

                connection.Close();
                return newDev;
            }
            else
            {
                return null;
            }
        }
    }
}