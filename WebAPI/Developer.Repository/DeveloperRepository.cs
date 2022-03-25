using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer.Repository;


namespace Developer.Repository
{
    
    public class DeveloperRepository
    {
        static string connectionString = @"Data Source=MARIN\SQLEXPRESS01;Initial Catalog = master; Integrated Security = True";

        public void DeveloperList()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM Developer;", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return;

        }
        

        
    }
}
