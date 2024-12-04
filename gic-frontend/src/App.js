import { Routes, Route } from 'react-router-dom';
import Cafe from './pages/cafe'
import logo from './logo.svg';
import './App.css';

function App() {

  

  return (
    <div className="App">

      <Routes>
        <Route path="/" element={<Cafe />} />
      </Routes>

      {/* <GridExample /> */}

      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://localhost:7099/WeatherForecast"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}
      
    </div>
  );
}

export default App;
