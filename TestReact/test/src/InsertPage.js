import NavBar from './NavBar.js';
import './NavBar.css';
import DeveloperForm from './DeveloperForm';

function InsertPage(){
    return (
        <div>
            <header>
                <NavBar /> 
            </header>
            
            <section>
                <DeveloperForm />
            </section>
            
        </div>
    );
}

export default InsertPage;
