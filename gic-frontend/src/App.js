import logo from './logo.svg';
import './App.css';
import { useState } from 'react';
import { AgGridReact } from 'ag-grid-react'; 
import "ag-grid-community/styles/ag-grid.css"; 
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid

function App() {

  const GridExample = () => {
      // Row Data: The data to be displayed.
      const [rowData, setRowData] = useState([
        { Logo: "A", Name: "Round Boy Roasters", Description: "", Employees: "", Location: "" },
        { Logo: "B", Name: "Yahava", Description: "", Employees: "", Location: "" },
        { Logo: "C", Name: "Starbucks", Description: "", Employees: "", Location: "" }
      ]);

      const CustomButtonComponent = (props) => {
        return <button onClick={() => window.alert('clicked') }>Push Me!</button>;
      };
    
      // Column Definitions: Defines the columns to be displayed.
      const [colDefs, setColDefs] = useState([
        { field: "Logo" },
        { field: "Name" },
        { field: "Description" },
        { field: "Location", filter: true },
        { field: "button", cellRenderer: CustomButtonComponent }
      ]);
   
      // ...
      const defaultColDef = {
          flex: 1,
      };

      // Container: Defines the grid's theme & dimensions.
      return (
        <div
            className={
                "ag-theme-quartz-dark"
            }
            style={{ 
              width: '100%', 
              // height: '100%' 
              height: '500px' 
            }}
        >
            <AgGridReact rowData={rowData} columnDefs={colDefs} defaultColDef={defaultColDef} />
        </div>
      );
   }

  return (
    <div className="App">

      <GridExample />

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
