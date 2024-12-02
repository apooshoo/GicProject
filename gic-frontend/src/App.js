import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

function App() {

  let seedCafes = [
    { Logo: "", Name: "Round Boy Roasters", Description: "", Employees: "", Location: "" },
    { Logo: "", Name: "Yahava", Description: "", Employees: "", Location: "" },
    { Logo: "", Name: "Starbucks", Description: "", Employees: "", Location: "" }
  ]

  const [cafes, setCafes] = useState({
    seedCafes
  });

  return (
    <div className="App">
      <header className="App-header">
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
      </header>
    </div>
  );
}

export default App;
