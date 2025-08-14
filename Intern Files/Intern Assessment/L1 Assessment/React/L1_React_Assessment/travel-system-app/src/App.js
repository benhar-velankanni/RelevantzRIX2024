import "./App.css";
import React, { useEffect } from "react";
import vid from "./media/Background2.mp4";
import Bookings from "./components/Bookings";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <video autoPlay muted loop className="background" src={vid} />
        <header className="App-header">
          <div className="form-container">
            <h1>Travel System</h1>
            <p>
              Welcome to te Travel System, your one-stop destination for all
              things travel. Whether you're planning a vacation, a business
              trip, or a family getaway, we've got you covered. Our
              user-friendly interface makes it easy to search for destinations,
              book flights, and manage your travel plans. With our secure and
              reliable platform, you can rest assured that your travel
              experience is safe and hassle-free.
            </p>
            <table>
              <tr>
                <td>
                  <Link to="/">
                    <button className="search-button" onClick={() => {document.title = "Z Travel";}}>Home</button>
                  </Link>
                </td>
                <td>
                  <Link to="/bookings">
                    <button className="search-button">Bookings</button>
                  </Link>
                </td>
              </tr>
            </table>
            <Routes>
              <Route path="/" element={<></>} />
              <Route path="/bookings" element={<Bookings />} />
            </Routes>
          </div>
        </header>
      </div>
    </BrowserRouter>
  );
}

export default App;
