import axios from "axios";
import { useState } from "react";


export default function TestPage(){
    const [listOfRooms, setListOfRooms] = useState([]);

    const getRooms = (event) => {
        event.preventDefault();

        let fromInput = document.forms["freeRoomsForm"]["roomsFrom"].value;
        let toInput = document.forms["freeRoomsForm"]["roomsTo"].value;

        if (fromInput != null && toInput != null){
            let urlString = `https://localhost:44307/api/GetRooms?startDate=${fromInput}&endDate=${toInput}`;

            axios.get(urlString).then((response) => {
                let listOfRooms = response.data;
                setListOfRooms(listOfRooms);
                console.log(urlString);
                
            })
        }
    }


    return (
        <div>
            <form name="freeRoomsForm">
                <span>From:</span>
                <input type="text" id="roomsFrom"></input>
                <br></br>
                <span>To:</span>
                <input type="text" id="roomsTo"></input>
                <br></br>

                <input type="submit" id="roomsSubmit" onClick={getRooms}></input>

                <br></br>
                <br></br>
                <br></br>

                <table>
                    <thead>
                        <tr>
                            <th>Room number</th>
                            <th>Price</th>
                        </tr>
                    </thead>

                    <tbody>
                        {listOfRooms.map(room=>
                            <tr key={room.id}>
                                <td>{room.number}</td>
                                <td>{room.price}</td>
                            </tr>
                            )}
                    </tbody>
                </table>

            </form>
        </div>
    );
}

