import './NavBar.css';
import { useState } from 'react';

function NavBar(){
    const rgb = {red: 75, green: 165, blue: 224};
    const [color, setColor] = useState(rgb);

    function ChangeColor(){
        
        const newColor = {
            red: (color.red - 10),
            green: (color.green - 10),
            blue: (color.blue - 10)
        };

        setColor(newColor);

        var inlineStyle = {
            backgroundColor: "rgb( {newColor.red} {newColor.green} {newColor.blue})"
        };
        
        console.log(newColor);

        document.getElementById("navDiv").style.backgroundColor = {color:"red"};


        
    }

    return (
        <div id="navDiv">
            <ul>
                <li className="listElem">Home</li>
                <li className="listElem">Contact</li>
                <li className="listElem">About</li>
                <li id="listButton"><button onClick={ChangeColor} id="button">Click to make the navbar darker</button></li>
            </ul>
        </div>
    );
}

export default NavBar;




