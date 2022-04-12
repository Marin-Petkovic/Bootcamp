import { Component } from 'react';
import './Table.css'

class Table extends Component{
    render(){
        return(
            <div>
                <table>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                    </tr>
                    <tr>
                        <td id="fnameToInsert"></td>
                        <td id="lnameToInsert"></td>
                    </tr>
                    
                </table>
            </div>
        );
    }
}

export default Table;