import './ContactInput.css';
import './Table.js';
import './InsertTableRow.js';

function ContactInput(){
    return (
        <div class="contactDiv">
            <form name="mainForm">
                <lable for="fname">First name:</lable><br></br>
                <input type="text" id="fname" name="fname"></input>
                <span id="fnameMessage" class="inputMessage"></span>
                
                <br></br>
                <br></br>

                <label for="lname">Last name:</label><br></br>
                <input type="text" id="lname" name="lname"></input>
                <span id="lnameMessage" class="inputMessage"></span>

                <br></br>
                <br></br>

                <input onClick={validateForm} id="submitBtn" type="submit" value="Submit"></input>
            </form>

            <pre id="display"></pre>
        </div>
    );
}

let person = {
    firstName: "",
    lastName: ""
}
const listOfPeople = [];


function validateForm(event){
    event.preventDefault();
    let firstNameInput = document.forms["mainForm"]["fname"].value;
    let lastNameInput = document.forms["mainForm"]["lname"].value;

    checkInput(firstNameInput, "fnameMessage");
    checkInput(lastNameInput, "lnameMessage");

    if (firstNameInput != "" && lastNameInput != ""){
        person.firstName = document.getElementById("fname").value;
        person.lastName = document.getElementById("lname").value;

        listOfPeople.push(person);

        document.getElementById("fnameToInsert").innerHTML = person.firstName;
        document.getElementById("lnameToInsert").innerHTML = person.lastName;


        //document.getElementById("fnameData").innerHTML = person.firstName;
        //document.getElementById("lnameData").innerHTML = person.lastName;

        //document.getElementById("display").innerHTML = JSON.stringify(listOfPeople, null, 2);
    }

}


function checkInput(x, elem){
    if(x == ""){
        document.getElementById(elem).textContent = "!!";
    }
    else{
        document.getElementById(elem).textContent = "";
    }
}

export default ContactInput;