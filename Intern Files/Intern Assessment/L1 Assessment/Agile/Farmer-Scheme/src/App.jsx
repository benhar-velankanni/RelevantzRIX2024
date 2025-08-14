import { Link, Routes, Route, BrowserRouter } from "react-router-dom";
import "./App.css";
import Login from "./Login.jsx";
import Register from "./Register.jsx";

function App() {
  return (
    <BrowserRouter>
      <div id="root">
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <div className="container-fluid">
            <Link className="navbar-brand" to="/">
              Farmer's App
            </Link>
            <button
              className="navbar-toggler"
              type="button"
              data-bs-toggle="collapse"
              data-bs-target="#navbarSupportedContent"
              aria-controls="navbarSupportedContent"
              aria-expanded="false"
              aria-label="Toggle navigation"
            >
              <span className="navbar-toggler-icon"></span>
            </button>
            <div
              className="collapse navbar-collapse"
              id="navbarSupportedContent"
            >
              <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                <li className="nav-item">
                  <Link className="nav-link" to="/login">
                    Log In
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/register">
                    Register
                  </Link>
                </li>
              </ul>
            </div>
          </div>
        </nav>

        <div className="hero container-fluid d-flex flex-column justify-content-center p-5">
          <h1 className="display-1">Farmer's App</h1>
          <p className="lead">
            A smart platform where farmers can easily add their crops and open
            them for bidding. Connect with buyers, get fair prices, and grow
            your market—right from your phone.
          </p>
          <p className="lead">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit
            amet nulla auctor, vestibulum magna sed, convallis ex. Cum sociis
            natoque penatibus et magnis dis parturient montes, nascetur
            ridiculus mus.
          </p>
          <br />
          <br />
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
