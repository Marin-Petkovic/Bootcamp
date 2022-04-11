function validateMainForm(){
    let x1 = document.forms["mainForm"]["fname"].value;
    let x2 = document.forms["mainForm"]["lname"].value;

    if (x1 == "" || x2 == ""){
        alert("All input fields must be filled out");
        return false;
    }
}


function activateDropdown(){
    let x = document.getElementById("dropdown_content");
    x.style.display = "block";
}


function changeColor(){
    document.getElementById("submit_button").style.backgroundColor = "lightblue";
}



document.getElementById("submit_button").onclick = function() {writeSubmitMessage()}

function writeSubmitMessage(){
    document.getElementById("submit_message").innerHTML = "Submitted!";
}



function setDate(){
    document.getElementById("date").innerHTML = "Date: " + new Date();
}



