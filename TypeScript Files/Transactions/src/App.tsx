import "./App.css";
import Navbar from "./components/Navbar";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AddTranaction from "./components/AddTranaction";
import ViewTransactions from "./components/ViewTransactions";
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
            <Route path="/add-transaction" element={<AddTranaction />} />
            <Route path="/view-transactions" element={<ViewTransactions />} />
          </Routes>
        </header>
      </div>
    </BrowserRouter>
  );
}

export default App;
