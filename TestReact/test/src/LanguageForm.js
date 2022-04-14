import React from 'react';
import './LanguageForm.css';

class LanguageForm extends React.Component {
    constructor(props) {
        super(props);
        let languageInfo = {favoriteLang: "", leastFavoriteLang: "", id: 0};
        this.state = {
            list: [languageInfo]
        };
    }

    storeInput = (event) => {
        event.preventDefault()
        const favLangInput = document.forms["langForm"]["favLang"].value;
        const leastFavLangInput = document.forms["langForm"]["leastFavLang"].value;

        checkInput(favLangInput, "favLangMessage");
        checkInput(leastFavLangInput, "leastFavLangMessage");

        if (favLangInput != "" && leastFavLangInput != ""){
            const newInfo = {
                favoriteLang: favLangInput,
                leastFavoriteLang: leastFavLangInput,
                id: this.state.list.id + 1
            };
            const newState = {
                list: [...this.state.list, newInfo]
            } 
            this.setState(newState)
        }

        
    }

    render() {
        return (
            <div>
                <form name="langForm">

                    <label htmlFor='favLang'>Favorite programming language:</label><br></br>
                    <input type="text" id="favLang"></input>
                    <span id="favLangMessage" className='langInputMessage'></span>
                    <br></br>

                    <label htmlFor='leastFavLang'>Least favorite programming language:</label><br></br>
                    <input type="text" id="leastFavLang" ></input>
                    <span id="leastFavLangMessage" className="langInputMessage"></span>
                    <br></br>

                    <input onClick={this.storeInput} type="submit" id="langSubmit"></input>

                    
                    
                    <table id="langTable">
                        <tr>
                            <th className='langTh'>Best</th>
                            <th className='langTh'>Worst</th>
                        </tr>

                        {this.state.list.map(item => (
                            <tr>
                                <td key={item.id}>{item.favoriteLang}</td>
                                <td>{item.leastFavoriteLang}</td>
                            </tr>
                        ))}

                    </table>

                </form>
            </div>
        );
    }
}

export default LanguageForm;


/*
IncreaseCounter = () => {
        this.setState({counter: this.state.counter + 1});
    }


<button onClick={this.IncreaseCounter}>Click me</button>
                <h2>You clicked the button {this.state.counter} times</h2>
                */

function checkInput(x, elem){
    if(x == ""){
        document.getElementById(elem).textContent = "!!";
    }
    else{
        document.getElementById(elem).textContent = "";
    }
}