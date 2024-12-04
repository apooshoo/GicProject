import { useState } from 'react';
import React from 'react';
import { useNavigate } from "react-router-dom";
import { AgGridReact } from 'ag-grid-react'; 
import "ag-grid-community/styles/ag-grid.css"; 
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid
import {useLocation} from 'react-router-dom';

function Employee() {
    const location = useLocation();
    console.log(location);

    // Row Data: The data to be displayed.
    const [rowData, setRowData] = useState([
        { Id: 1, Name: "A", EmailAddress: "", PhoneNumber: "", DaysWorked: "", CafeName: "" },
        { Id: 2, Name: "B", EmailAddress: "", PhoneNumber: "", DaysWorked: "", CafeName: "" },
        { Id: 3, Name: "C", EmailAddress: "", PhoneNumber: "", DaysWorked: "", CafeName: "" }
    ]);

    // Column Definitions: Defines the columns to be displayed.
    const [colDefs, setColDefs] = useState([
        { field: "Id" },
        { field: "Name" },
        { field: "EmailAddress" },
        { field: "PhoneNumber" },
        { field: "DaysWorked" },
        { field: "CafeName" },
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

export default Employee;
