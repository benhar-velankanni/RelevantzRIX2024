import React from "react";
import { BrowserRouter, Link, Routes, Route } from "react-router-dom";
import Contacts from "./components/Contacts";
import Bug from "./components/Bug";
import Transaction from "./components/Transaction";
import Ticket from "./components/Ticket";
import BackgroundVideo from "./media/BackgroundVideo.mp4";
import "./App.css";

function App() {
  let [headline, setHeadline] = React.useState("Select a Form to begin.");
  return (
    <BrowserRouter>
      <div className="App">
        <video
          autoPlay
          loop
          muted
          className="background-video"
          src={BackgroundVideo}
        ></video>
        <header className="App-header">
          <nav className="App-nav">
            <Link to="/">
              <button
                className="routes"
                onClick={() => {
                  document.title = "Z Home";
                  headline = "Select a Form to begin.";
                  setHeadline(headline);
                }}
              >
                Home
              </button>
            </Link>
            <Link to="/Contacts">
              <button
                className="routes"
                onClick={() => {
                  headline = "Selected Component: Contacts Form.";
                  setHeadline(headline);
                }}
              >
                Contacts
              </button>
            </Link>
            <Link to="/Bug">
              <button
                className="routes"
                onClick={() => {
                  headline = "Selected Component: Bug Report Form.";
                  setHeadline(headline);
                }}
              >
                Bug
              </button>
            </Link>
            <Link to="/Transaction">
              <button
                className="routes"
                onClick={() => {
                  headline = "Selected Component: Transaction Report Form.";
                  setHeadline(headline);
                }}
              >
                Transaction
              </button>
            </Link>
            <Link to="/Ticket">
              <button
                className="routes"
                onClick={() => {
                  headline = "Selected Component: Ticket Form.";
                  setHeadline(headline);
                }}
              >
                Ticket
              </button>
            </Link>
          </nav>
          <main>
            <div className="form-container">
              <p>
                <b>{headline}</b>
              </p>

              <Routes>
                <Route path="/Contacts" element={<Contacts />} />
                <Route path="/Bug" element={<Bug />} />
                <Route path="/Transaction" element={<Transaction />} />
                <Route path="/Ticket" element={<Ticket />} />
                <Route path="/" element={<></>} />
              </Routes>
            </div>
          </main>
        </header>
      </div>
    </BrowserRouter>
  );
}

export default App;
