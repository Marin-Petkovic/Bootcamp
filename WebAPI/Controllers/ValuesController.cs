using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // creates, retrieves, updates and deletes instances (or particular information) of developers in a company
        

        [HttpPost]
        [Route("api/AddDeveloper")]
        public string CreateDeveloper([FromBody] Developer developer)
        {
            ListOfDevelopers.Add(developer);
            return $"Developer added! Info: {developer.FirstName} {developer.LastName} (ID: {developer.DeveloperID}), Branch: {developer.Branch}";
        }        

        
        [HttpPut]
        [Route("api/UpdateDeveloper")]
        public string UpdateDeveloperBranchByID([FromBody] Developer developer)
        {
            Developer result = ListOfDevelopers.Find(x => x.DeveloperID == developer.DeveloperID);
            if (result != null)
            {
                result.Branch = developer.Branch;
                return $"Updated info: {result.FirstName} {result.LastName} (ID: {result.DeveloperID}), Branch: {result.Branch}";
            }
            else
            {
                return $"Developer not found";
            }     
        }

        
        [HttpDelete]
        [Route("api/DeleteDeveloper")]
        public string DeleteDeveloperByID([FromBody] Developer developer)
        {
            Developer result = ListOfDevelopers.Find(x => x.DeveloperID == developer.DeveloperID);
            
            if (result != null)
            {
                string DeletedDeveloper = $"{result.FirstName} {result.LastName}";
                ListOfDevelopers.Remove(result);
                return $"Developer {DeletedDeveloper} has been deleted";
            }
            else
            {
                return $"Developer not found";
            }            
        }

        static List<Developer> ListOfDevelopers = new List<Developer>();
        string DevelopersInfo; // used in order to gather (and, after that, return) all information about objects in a list

        [HttpGet]
        [Route("api/RetrieveList")]
        public string RetrieveList()
        {
            foreach (Developer developer in ListOfDevelopers)
            {
                DevelopersInfo += developer.InfoAboutEmployee();
            }
            return DevelopersInfo;
        }

        [HttpGet]
        [Route("api/RetrieveDeveloper")]
        public string RetrieveDeveloperInfoByID(int ID)
        {
            Developer result = ListOfDevelopers.Find(x => x.DeveloperID == ID.ToString());
            if (result != null)
            {
                return $"The requested developer info: {result.FirstName} {result.LastName} (ID: {result.DeveloperID}), Branch: {result.Branch}";
            }
            else
            {
                return $"Developer not found";
            }
        }
    }


    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeveloperID { get; set; }
        public string Branch { get; set; }
        public string InfoAboutEmployee()
        {
            return $"ID: {DeveloperID} {FirstName} {LastName}, Branch: {Branch} ";
        }
    }
}
