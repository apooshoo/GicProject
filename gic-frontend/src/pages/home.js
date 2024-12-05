import logo from '../logo.svg';
import '../App.css';

function Home() {
  return (
    <div>
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Hello, I'm Jon.
        </p>
        <p>
          Please click on "Cafe" or  
          <a 
            style={{marginLeft:'10px', marginRight:'10px'}}
            className="App-link"
            href="/cafes"
            target="_blank"
            rel="noopener noreferrer">
              here
          </a>
          to have a look.
        </p>
      </header>     
    </div>
  );
}

export default Home;
