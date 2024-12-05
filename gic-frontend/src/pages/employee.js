import React from 'react';
import { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';
import GenericGrid from '../components/grid'
import axios from 'axios';

function Employee() {
    const location = useLocation();

    useEffect(() => {
        //Runs only on the first render
        console.log('received');
        console.log(location);
        
        var queryString = location.state && location.state.cafe_id 
            ? "?cafe=" + location.state.cafe_id 
            : "";
        axios.get('https://localhost:5000/employees' + queryString)
            .then(function (response) {
                console.log("employee response:")
                console.log(response);
                setRowData(response.data)
            })
            .catch(function (error) {
                console.log(error);
            });
      }, []);

    const [rowData, setRowData] = useState([]);

    const [colDefs, setColDefs] = useState([
        { field: "id" },
        { field: "name" },
        { field: "email_address" },
        { field: "phone_number" },
        { field: "days_worked" },
        { field: "cafe" },
    ]);

    return (
        <div>
            <GenericGrid rowData={rowData} colDefs={colDefs} />
        </div>
    );
}

export default Employee;
