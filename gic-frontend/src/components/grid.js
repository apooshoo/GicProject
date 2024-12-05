import React from 'react';
import { AgGridReact } from 'ag-grid-react'; 
import "ag-grid-community/styles/ag-grid.css"; 
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid

const GenericGrid = ({rowData, colDefs}) => {
    const defaultColDef = {
        flex: 1,
    };
    var gridHeight = window.innerHeight - 60 + 'px';
    return (
      <div
          className={
              "ag-theme-quartz-dark"
          }
          style={{ 
            width: '100%', 
            height: gridHeight
          }}
      >
          <AgGridReact rowData={rowData} columnDefs={colDefs} defaultColDef={defaultColDef} />
      </div>
    );
 }

 export default GenericGrid;