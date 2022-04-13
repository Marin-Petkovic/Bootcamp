import { useState } from 'react';
import './ContactInput.css';

function ContactInput(){
    const person = {firstName: "", lastName: ""};
    const [people, setPeople] = useState([person]);
    const listOfPeople = people.map(person => <li>{person.firstName} {person.lastName}</li>);

    function validateForm(event){
        event.preventDefault();

        let firstNameInput = "";
        let lastNameInput = "";

    
        firstNameInput = document.forms["mainForm"]["fname"].value;
        lastNameInput = document.forms["mainForm"]["lname"].value;
    
        checkInput(firstNameInput, "fnameMessage");
        checkInput(lastNameInput, "lnameMessage");
    
        if (firstNameInput != "" && lastNameInput != ""){
            const newPerson = {
                firstName: firstNameInput,
                lastName: lastNameInput
            };
            
            const newPeople = [...people, newPerson];
            setPeople(newPeople);

            listOfPeople = people.map(person => <li>{person.firstName} {person.lastName}</li>);
            }

        
        }


    return (
        <div className="contactDiv">
            <form name="mainForm">
                <lable htmlFor="fname">First name:</lable><br></br>
                <input type="text" id="fname" name="fname"></input>
                <span id="fnameMessage" className="inputMessage"></span>
                
                <br></br>
                <br></br>

                <label htmlFor="lname">Last name:</label><br></br>
                <input type="text" id="lname" name="lname"></input>
                <span id="lnameMessage" className="inputMessage"></span>

                <br></br>
                <br></br>

                <input onClick={validateForm} id="submitBtn" type="submit" value="Submit"></input>

                <table>
                    <tr>
                        <th>Names</th>
                        
                    </tr>
                    <ul>
                        {listOfPeople}
                    </ul>
                    
                </table>
            </form>

            <pre id="display"></pre>
        </div>
    );
}






        //document.getElementById("fnameData").innerHTML = person.firstName;
        //document.getElementById("lnameData").innerHTML = person.lastName;

        //document.getElementById("display").innerHTML = JSON.stringify(listOfPeople, null, 2);
    





function checkInput(x, elem){
    if(x == ""){
        document.getElementById(elem).textContent = "!!";
    }
    else{
        document.getElementById(elem).textContent = "";
    }
}

export default ContactInput;