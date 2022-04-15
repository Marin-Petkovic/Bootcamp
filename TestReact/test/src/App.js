import logo from './logo.svg';
import './App.css';
import NavBar from './NavBar';
import GetDevelopers from './GetDevelopers';

function App() {


  return (
    <div className="App">
      <header className="App-header">
        <NavBar />
      </header>
      <section>
        <GetDevelopers /> 
      </section>
      
    </div>
  );
}

export default App;
