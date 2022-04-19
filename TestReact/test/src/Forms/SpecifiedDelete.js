import {useParams} from 'react-router-dom';
import DeleteForm from './DeleteForm';

function SpecifiedDelete(){
    const {id} = useParams();
    return (
        <DeleteForm idToDelete={id}/>
    );
}

export default SpecifiedDelete;