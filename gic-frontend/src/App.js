import { Routes, Route } from 'react-router-dom';
import Cafe from './pages/cafe';
import Employee from './pages/employee';
import Home from './pages/home';
import NavBar from './components/navBar';
import './App.css';

function App() {
  return (
    <div className="App">
      <NavBar/>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/cafe" element={<Cafe />} />
        <Route path="/employee" element={<Employee />} />
      </Routes>   
    </div>
  );
}

export default App;
