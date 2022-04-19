import NavBar from "./NavBar";
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import InsertPage from './Pages/InsertPage';
import UpdatePage from './Pages/UpdatePage';
import DeletePage from './Pages/DeletePage';
import RetrievePage from './Pages/RetrievePage';
import SpecifiedUpdate from "./Forms/SpecifiedUpdate";
import SpecifiedDelete from "./Forms/SpecifiedDelete";

function App (){
    return (
        <Router>
                <NavBar />
                    <Routes>
                        <Route path="/" element={<RetrievePage />}/>
                        <Route path="/insert" element={<InsertPage />}/>
                        <Route path="/update" element={<UpdatePage />}/>
                        <Route path="/delete" element={<DeletePage />}/>
                        <Route path="/update/:id" element={<SpecifiedUpdate />}/>
                        <Route path="/delete/:id" element={<SpecifiedDelete />}/>
                    </Routes>
        </Router>
    );
}


export default App;