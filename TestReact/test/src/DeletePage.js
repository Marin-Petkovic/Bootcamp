import NavBar from './NavBar';
import DeleteForm from './DeleteForm';

function DeletePage(){
    return (
        <div>
            <header>
                <NavBar />
            </header>

            <section>
                <DeleteForm />
            </section>
        </div>
    );
}

export default DeletePage;