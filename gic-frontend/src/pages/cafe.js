import React from 'react';
import { useState } from 'react';
import { useNavigate } from "react-router-dom";
import Button from '@mui/material/Button';
import GenericGrid from '../components/grid'

const Cafe = () => {
    const [rowData, setRowData] = useState([
      { Logo: "A", Name: "Round Boy Roasters", Description: "", Employees: "", Location: "" },
      { Logo: "B", Name: "Yahava", Description: "", Employees: "", Location: "" },
      { Logo: "C", Name: "Starbucks", Description: "", Employees: "", Location: "" }
    ]);

    const OpenEmployeePageBtn = (props) => {
        let navigate = useNavigate(); 
        const routeChange = () =>{ 
          let path = `/Employee`; 
          let args = {state:{Name:props.data.Name}}
          navigate(path, args);
        }
        return <Button variant="outlined" onClick={routeChange}>Push Me!</Button>;
    };
  
    const [colDefs, setColDefs] = useState([
      { field: "Logo" },
      { field: "Name" },
      { field: "Description" },
      { field: "Location", filter: true },
      { field: "button", cellRenderer: OpenEmployeePageBtn }
    ]);
 
    return (
      <div>
        <GenericGrid rowData={rowData} colDefs={colDefs} />
      </div>
    );
 }

 export default Cafe;