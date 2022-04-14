import './NavBar.css';
import { useState } from 'react';

function NavBar(){
    const rgb = {red: 75, green: 165, blue: 224};
    const [color, setColor] = useState(rgb);
    let rgbString = "rgb(" + color.red + "," + color.green + "," + color.blue + ")";
    let styleInline = {
        background: rgbString
    };
    
    
    function ChangeColorDark(){
        const newColorDark = {
            red: (color.red - 10),
            green: (color.green - 10),
            blue: (color.blue - 10)
        };
        setColor(newColorDark);
    }
    

    function ChangeColorBright(){
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
                <li className="listElem">Home</li>
                <li className="listElem">Contact</li>
                <li className="listElem">About</li>
                <li><button onClick={ChangeColorDark} className="button">-</button></li>
                <li>Adjust brigtness of the navbar</li>
                <li><button onClick={ChangeColorBright} className="button">+</button></li>
            </ul>
        </div>
    );
}

export default NavBar;




