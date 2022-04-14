import logo from './logo.svg';
import './App.css';
import NavBar from './NavBar';
import ContactInput from './ContactInput';
import LanguageForm from './LanguageForm';

function App() {
  return (
    <div className="App">
      <NavBar />
      <header className="App-header">
      <ContactInput />
      <LanguageForm />
     
        <img src={logo} className="App-logo" alt="logo" />
        
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        
      </header>
    </div>
  );
}

export default App;
