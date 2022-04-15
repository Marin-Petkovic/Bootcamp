import axios from 'axios';
import { useState } from 'react';
import './DeveloperForm.css';
import GetDevelopers from './GetDevelopers';


function DeveloperForm(){
    //const person = {firstName: "", lastName: ""};
    const [people, setPeople] = useState([]);
    let listOfPeople = people.map(person => <li>{person.firstName} {person.lastName}</li>);

    function validateForm(event){
        event.preventDefault();

 
        

        let firstNameInput = document.forms["mainForm"]["fname"].value;
        let lastNameInput = document.forms["mainForm"]["lname"].value;
        let projectIdInput = document.forms["mainForm"]["projectId"].value;
    
        checkInput(firstNameInput, "fnameMessage");
        checkInput(lastNameInput, "lnameMessage");
        checkInput(projectIdInput, "projectIdMessage");
    
        if (firstNameInput != "" && lastNameInput != "" && projectIdInput != null){
            const newPerson = {
                firstName: firstNameInput,
                lastName: lastNameInput,
                projectId: projectIdInput
            };

            
            let urlString = "https://localhost:44346/api/InsertDev";
            axios.post(urlString, newPerson).then((response) => {
                let insertedDev = response.data;
                console.log(insertedDev);
                if (insertedDev != null){
                    setPeople([...people, newPerson])
                }
                
            })

            //const newPeople = [...people, newPerson];
            //setPeople(newPeople);

            listOfPeople = people.map(person => <li>{person.firstName} {person.lastName}</li>);
            }

        
        }


    return (
        <div className="formDiv">
            <form name="mainForm">
                <label htmlFor="fname">First name:</label><br></br>
                <input type="text" id="fname" name="fname"></input>
                <span id="fnameMessage" className="inputMessage"></span>
                
                <br></br>
                <br></br>

                <label htmlFor="lname">Last name:</label><br></br>
                <input type="text" id="lname" name="lname"></input>
                <span id="lnameMessage" className="inputMessage"></span>

                <br></br>
                <br></br>

                <label htmlFor='projectId'>Project Id:</label><br></br>
                <input type="text" id="projectId" name="projectId"></input>
                <span id="projectIdMessage" className="inputMessage"></span>

                <br></br>
                <br></br>

                <input onClick={validateForm} id="submitBtn" type="submit" value="Submit"></input>

                <table>
                    <tr>
                    <ul>
                        {listOfPeople}
                    </ul>
                    </tr>
                    
                    
                </table>
            </form>

            <pre id="display"></pre>
        </div>
    );
}



function checkInput(x, elem){
    if(x == ""){
        document.getElementById(elem).textContent = "!!";
    }
    else{
        document.getElementById(elem).textContent = "";
    }
}

export default DeveloperForm;