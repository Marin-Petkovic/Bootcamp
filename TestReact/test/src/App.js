import NavBar from "./NavBar";
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import InsertPage from './Pages/InsertPage';
import UpdatePage from './Pages/UpdatePage';
import DeletePage from './Pages/DeletePage';
import RetrievePage from './Pages/RetrievePage';

function App (){
    return (
        <Router>
            <div>
                <NavBar />
                <div>
                    <Routes>
                    <Route path="/" element={<RetrievePage />}/>
                    <Route path="/insert" element={<InsertPage />}/>
                    <Route path="/update" element={<UpdatePage />}/>
                    <Route path="/delete" element={<DeletePage />}/>
                    </Routes>
                </div>
            </div>
        </Router>
    );
}


export default App;