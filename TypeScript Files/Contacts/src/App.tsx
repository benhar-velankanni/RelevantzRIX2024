import "./App.css";
import Navbar from "./components/Navbar";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AddContact from "./components/AddContact";
import ViewContacts from "./components/ViewContacts";
import Home from "./components/Home";
import { useState, useEffect } from "react";

function App() {
  const [navbarKey, setNavbarKey] = useState(0);

  useEffect(() => {
    setNavbarKey((prevKey) => prevKey + 1);
  }, []);

  return (
    <BrowserRouter>
      <Navbar key={navbarKey} />
      <div className="App">
        <header className="App-header">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/add-contact" element={<AddContact />} />
            <Route path="/view-contacts" element={<ViewContacts />} />
          </Routes>
        </header>
      </div>
    </BrowserRouter>
  );
}

export default App;
