import "./App.css";
import Navbar from "./components/Navbar";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AddTranaction from "./components/AddTranaction";
import ViewTransactions from "./components/ViewTransactions";
import Home from "./components/Home";

function App() {
  document.addEventListener("DOMContentLoaded", () => {
    const app = document.getElementById("App");

    if (app) {
      setTimeout(() => {
        app.style.opacity = "1";
      }, 150);
    }
  });

  return (
    <BrowserRouter>
      <Navbar />
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
