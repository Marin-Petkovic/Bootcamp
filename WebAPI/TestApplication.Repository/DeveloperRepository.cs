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
        static string connectionString = @"Data Source=ST-02\SQLEXPRESS;Initial Catalog = master; Integrated Security = True";

        public List<Developer> DeveloperList()
        {
            SqlConnection connection = new SqlConnection(connectionString);

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

                listOfDevelopers1.Add(developer);
            }
            connection.Close();
            return listOfDevelopers1;
        }




        public List<Developer> DevsOnProject(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
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

                listOfDevs.Add(developer);
            }
            connection.Close();
            return listOfDevs;
        }
    }
}