import axios from 'axios';
import { useEffect, useState } from 'react';
import './RetrieveForm.css';
import {Link} from 'react-router-dom';


function RetrieveForm(){
    const [developers, setDevelopers] = useState([]);
    const linkStyle = {textDecoration: "none", color: "white"}
    if (developers.length > 0){
        var listOfDevs = developers.map(dev =>
            <tr key={dev.Id}>
                <td><button id="tableDeleteBtn" className="tableBtn"><Link to={`/delete/${dev.Id}`} style={linkStyle}>Delete</Link></button></td>
                <td><button id="tableUpdateBtn" className="tableBtn"><Link to={`/update/${dev.Id}`} style={linkStyle}>Update</Link></button></td>
                <td>{dev.FirstName}</td>
                <td>{dev.LastName}</td>
                <td>{dev.ProjectId}</td>
            </tr>)
    }    
        
    function writeData(){
        let sortByChecked = document.querySelector('input[name="sortByForm"]:checked');
        let sortOrderChecked = document.querySelector('input[name="sortOrderForm"]:checked');

        let urlString = "https://localhost:44346/api/RetrieveAllDevs";
        if (sortByChecked != null){
            urlString = urlString + "?SortBy=" + sortByChecked.value;
            if (sortOrderChecked != null){
                urlString = urlString + "&SortOrder=" + sortOrderChecked.value;
            }
        }

        axios.get(urlString).then((response) => {
            const retrievedData = response.data;
            
            //const newDevelopers = [...developers, retrievedData];
            setDevelopers(retrievedData);      
        })
    }

    return (
        <div id="searchDiv">
            <h1>Retrieve Developers</h1>
            <div id="sortDiv">

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
            <button id="clickBtn" onClick={writeData}>Click to show devs</button>
            
            <table id="table">
                <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Project Id</th>
                </tr>
                </thead>
                
                <tbody>
                {listOfDevs}
                </tbody>
                
            </table> 
        </div>
    );
}

export default RetrieveForm;
