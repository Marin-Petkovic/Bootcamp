import axios from 'axios';
import { useState } from 'react';
import ContactInput from './ContactInput';
import './GetDevelopers.css';


function GetDevelopers(){
    const [developers, setDevelopers] = useState([{}]);
    const listOfDevs = developers.map(dev =>
    <tr key={dev.Id}>
        {/*<td>{dev.Id}</td>*/}
        <td>{dev.FirstName}</td>
        <td>{dev.LastName}</td>
        <td>{dev.ProjectId}</td>
    </tr>)

    function writeData(){
        
        let sortByChecked = document.querySelector('input[name="sortByForm"]:checked');
        let sortOrderChecked = document.querySelector('input[name="sortOrderForm"]:checked');
        let sortBy = sortByChecked.value;
        let sortOrder = sortOrderChecked.value;
        let urlString = "https://localhost:44346/api/RetrieveAllDevs";
        if (sortByChecked != null){
            urlString = urlString + "?SortBy=" + sortBy;
            if (sortOrderChecked != null){
                urlString = urlString + "&SortOrder=" + sortOrder;
            }
        }


        console.log(urlString);
        

        axios.get(urlString).then((response) => {
            const retrievedData = response.data;
            
            console.log(retrievedData);
            //const newDevelopers = [...developers, retrievedData];
            setDevelopers(retrievedData);
            
        })
        .catch(error => console.error('Error: ' + {error}));
    }




    return (
        <div id="searchDiv">
            <button id="clickBtn" onClick={writeData}>Click me to show devs</button>
            <div id="filterDiv">

                <form name="sortByForm">
                    <span>Sort by: </span>
                    <input type="radio" name="sortByForm" id="sortFirstName" value="FirstName"></input>
                    <label htmlFor='filterFirstName'>First Name</label>

                    <input type="radio" name="sortByForm" id="sortLastName" value="LastName"></input>
                    <label htmlFor="filterLastName">Last Name</label>

                    <input type="radio" name="sortByForm" id="sortProjectId" value="ProjectId"></input>
                    <label htmlFor="filterProjectId">Project Id</label>
                </form>

                <form name="sortOrderForm">
                    <span>Sort order: </span>
                    <input type="radio" name="sortOrderForm" id="sortAsc" value="Asc"></input>
                    <label htmlFor="sortAsc">ASC</label>

                    <input type="radio" name="sortOrderForm" id="sortDesc" value="Desc"></input>
                    <label htmlFor="sortDesc">DESC</label>

                </form>

                
            </div>
            

            <table id="table">
                <tr>
                    {/*<th>Id</th>*/}
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Project Id</th>
                </tr>
                {listOfDevs}
            </table>

            
        </div>
    );
}

export default GetDevelopers;
