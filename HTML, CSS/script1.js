const person = {
    firstName: '',
    lastName: '',
    email: ""
};
const people = [];
function validateMainForm(){
    event.preventDefault();
    let firstNameInput = document.forms["mainForm"]["fname"].value;
    let lastNameInput = document.forms["mainForm"]["lname"].value;
    let emailInput = document.forms["mainForm"]["email"].value;

    checkInput(firstNameInput, "fnameMessage");
    checkInput(lastNameInput, "lnameMessage");
    checkInput(emailInput, "emailMessage" )

    if (firstNameInput != "" &&  lastNameInput != "" && emailInput != ""){
        person.firstName = document.getElementById("fname").value;
        person.lastName = document.getElementById("lname").value;
        person.email = document.getElementById("email").value;
        people[people.length] = person;
        document.getElementById("display").innerHTML = JSON.stringify(people, null, 2);
    }
}


function checkInput(x, elem){
    if (x == ""){
        document.getElementById(elem).textContent = "Invalid input";
    }
    else{
        document.getElementById(elem).textContent = "";
    }
}



function activateDropdown(){
    let x = document.getElementById("dropdown_content");
    x.style.display = "block";
}


function changeColor(){
    document.getElementById("submit_button").style.backgroundColor = "lightblue";
}






function setDate(){
    document.getElementById("date").innerHTML = "Date: " + new Date();
}



