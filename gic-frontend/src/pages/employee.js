import { useState } from 'react';
import React from 'react';
import { useNavigate } from "react-router-dom";
import GenericGrid from '../components/grid'
import {useLocation} from 'react-router-dom';

function Employee() {
    const location = useLocation();
    console.log(location);

    const [rowData, setRowData] = useState([
        { Id: 1, Name: "A", EmailAddress: "", PhoneNumber: "", DaysWorked: "", CafeName: "" },
        { Id: 2, Name: "B", EmailAddress: "", PhoneNumber: "", DaysWorked: "", CafeName: "" },
        { Id: 3, Name: "C", EmailAddress: "", PhoneNumber: "", DaysWorked: "", CafeName: "" }
    ]);

    const [colDefs, setColDefs] = useState([
        { field: "Id" },
        { field: "Name" },
        { field: "EmailAddress" },
        { field: "PhoneNumber" },
        { field: "DaysWorked" },
        { field: "CafeName" },
    ]);

    return (
        <div>
            <GenericGrid rowData={rowData} colDefs={colDefs} />
        </div>
    );
}

export default Employee;
