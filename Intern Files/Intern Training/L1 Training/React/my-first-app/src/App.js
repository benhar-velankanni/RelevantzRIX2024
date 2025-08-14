import logo from "./logo.png";
import "./App.css";

function App() {
  let date = new Date();
  let today = date.toUTCString();
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          <b>Let the Z-Training begin.</b>
        </p>
        <p>Today is {today}</p>
      </header>
    </div>
  );
}

export default App;
