import axios from "axios";
import './DeleteForm.css';


function DeleteForm({idToDelete}){
    function validateDeleteForm(event){
        event.preventDefault();

        let devIdInput = document.forms["deleteForm"]["devId"].value;

        checkInput(devIdInput, "deleteInputMessage");

        if (devIdInput != null){
            let urlString = "https://localhost:44346/api/DeleteDev?devId=" + devIdInput;

            axios.delete(urlString).then((response) => {
                document.getElementById("deleteSubmitMessage").textContent = "Successfully submitted!";
            })
        }
    }


    return (
        <div id="deleteFormDiv">
            <form id="deleteForm" name="deleteForm">
                <h1>Delete a developer</h1>
                <label htmlFor="devId">Developer ID:</label><br></br>
                <input type="number" id="devId" value={idToDelete} placeholder={idToDelete}></input>
                <span id="deleteInputMessage" class="deleteMessage"></span>

                <br></br>
                <br></br>

                <input onClick={validateDeleteForm} type="submit" id="deleteSubmitBtn"></input>
                <p id="deleteSubmitMessage"></p>
            </form>
        </div>
    );
}

export default DeleteForm;


function checkInput(x, elem){
    if(x == ""){
        document.getElementById(elem).textContent = "!!";
        document.getElementById("deleteSubmitMessage").textContent = "";
    }
    else{
        document.getElementById(elem).textContent = "";  
    }
}