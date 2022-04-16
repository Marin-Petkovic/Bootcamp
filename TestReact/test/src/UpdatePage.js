import NavBar from "./NavBar";
import './UpdatePage.css';
import UpdateForm from "./¸UpdateForm";


function UpdatePage(){
    return (
        <div>
            <header>
                <NavBar />
            </header>
            
            <section>
                <UpdateForm />
            </section>
        </div>
    );
}

export default UpdatePage;