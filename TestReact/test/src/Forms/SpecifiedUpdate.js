import {useParams} from 'react-router-dom';
import UpdateForm from './UpdateForm';

function SpecifiedUpdate(){
    const {id} = useParams();
    return (
        <UpdateForm idToUpdate={id}/>
    );
}

export default SpecifiedUpdate;