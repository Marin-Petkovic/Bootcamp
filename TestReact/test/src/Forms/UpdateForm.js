import axios from 'axios';
import './UpdateForm.css';

function UpdateForm({idToUpdate}){

    function validateUpdateForm(event){
        event.preventDefault();

        let devIdInput = document.forms["updateForm"]["devId"].value;
        let newProjectIdInput = document.forms["updateForm"]["newProjectId"].value;
        	console.log(newProjectIdInput);
            console.log(devIdInput)
        checkInput(devIdInput, "devIdMessage");
        checkInput(newProjectIdInput, "newProjectIdMessage");

        if (devIdInput != null && newProjectIdInput != null){
            let urlString = "https://localhost:44346/api/UpdateDev?devId=" + devIdInput + "&newProjectId=" + newProjectIdInput;

            axios.put(urlString).then((response) => {
                document.getElementById("updateSubmitMessage").textContent = "Successfully submitted!";
            })
            
        }
        
    }


    return (
        <div>
            <form id="updateFormDiv" name="updateForm">
                <h1>Update a developer</h1>
                <label htmlFor="devId">Developer ID:</label><br></br>
                <input type="text" id="devId" value={idToUpdate} placeholder={idToUpdate}></input>
                <span id="devIdMessage" className="updateMessage"></span>

                <br></br>
                <br></br>

                <label htmlFor="newProjectId">New project ID:</label><br></br>
                <input type="text" id="newProjectId"></input>
                <span id="newProjectIdMessage" className="updateMessage"></span>

                <br></br>
                <br></br>

                <input onClick={validateUpdateForm} type="submit" id="updateSubmitBtn"></input>
                <p id="updateSubmitMessage"></p>

            </form>
        </div>
    );
}

export default UpdateForm;

function checkInput(x, elem){
    if(x == ""){
        document.getElementById(elem).textContent = "!!";
        document.getElementById("updateSubmitMessage").textContent = "";
    }
    else{
        document.getElementById(elem).textContent = "";  
    }
}