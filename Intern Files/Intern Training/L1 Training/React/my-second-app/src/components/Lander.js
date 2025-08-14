import "../App.css";
import Greeting from "./Greeting";
import Welcome from "./Welcome";

function Lander() {
  return (
    <div className="App">
      <header className="App-header">
        <Greeting />
        <Welcome />
      </header>
    </div>
  );
}

export default Lander;
