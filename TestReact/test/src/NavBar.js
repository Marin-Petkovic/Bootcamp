import './NavBar.css';
import { useState } from 'react';
import InsertPage from './InsertPage';
import {Link} from 'react-router-dom';
import React from 'react';
import App from './App';
import UpdatePage from './UpdatePage';
import DeletePage from './DeletePage';


function NavBar(){
    const rgb = {red: 75, green: 165, blue: 224};
    const [color, setColor] = useState(rgb);
    let rgbString = "rgb(" + color.red + "," + color.green + "," + color.blue + ")";
    let styleInline = {
        background: rgbString
    };
    
    
    function changeColorDark(){
        const newColorDark = {
            red: (color.red - 10),
            green: (color.green - 10),
            blue: (color.blue - 10)
        };
        setColor(newColorDark);
    }
    

    function changeColorBright(){
        console.log("Hello");
        const newColorBright = {
            red: (color.red + 10),
            green: (color.green + 10),
            blue: (color.blue + 10)
        };
        setColor(newColorBright);
        console.log(newColorBright); 
    }
    
    return (
        <div style={styleInline} id="navDiv">
            <ul>
                <li className="listElem"><Link to="/" component={<App />}>Retrieve Developers</Link></li>
                <li className="listElem"><Link to="/insert" component={<InsertPage />}>Insert new Developer</Link></li>
                <li className="listElem"><Link to="/update" component={<UpdatePage />}>Update a Developer</Link></li>
                <li className="listElem"><Link to="/delete" component={<DeletePage />}>Delete a developer</Link></li>
                <li><button onClick={changeColorDark} className="button">-</button></li>
                <li>Adjust brigtness of the navbar</li>
                <li><button onClick={changeColorBright} className="button">+</button></li>
            </ul>
        </div>
    );
}

export default NavBar;




