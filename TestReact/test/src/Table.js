import { Component } from 'react';
import './Table.css'
import InsertTableRow from './InsertTableRow';

class Table extends Component{
    render(){
        return(
            <div>
                <table>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                    </tr>
                    <InsertTableRow />


                </table>
            </div>
        );
    }
}

export default Table;