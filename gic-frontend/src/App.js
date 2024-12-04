import { Routes, Route } from 'react-router-dom';
import Cafe from './pages/cafe'
import Home from './pages/home'
import NavigationBar from './components/navBar';
import './App.css';

function App() {
  return (
    <div className="App">
      <NavigationBar/>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/cafe" element={<Cafe />} />
      </Routes>   
    </div>
  );
}

export default App;
