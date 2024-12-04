import { useState } from 'react';
import React from 'react';
import { useNavigate } from "react-router-dom";
import { AgGridReact } from 'ag-grid-react'; 
import "ag-grid-community/styles/ag-grid.css"; 
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid

const GridExample = () => {
    // Row Data: The data to be displayed.
    const [rowData, setRowData] = useState([
      { Logo: "A", Name: "Round Boy Roasters", Description: "", Employees: "", Location: "" },
      { Logo: "B", Name: "Yahava", Description: "", Employees: "", Location: "" },
      { Logo: "C", Name: "Starbucks", Description: "", Employees: "", Location: "" }
    ]);

    const CustomButtonComponent = (props) => {
        let navigate = useNavigate(); 
        const routeChange = () =>{ 
          let path = `/Employee`; 
          let args = {state:{Name:props.data.Name}}
          navigate(path, args);
        }
    //   return <button onClick={() => window.alert(props.data.Name) }>Push Me!</button>;
        return <button onClick={routeChange}>Push Me!</button>;
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

 export default GridExample;