import "./App.css";
import Navbar from "./components/Navbar";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AddContact from "./components/AddContact";
import ViewContacts from "./components/ViewContacts";
import Home from "./components/Home";

function App() {
  return (
    <BrowserRouter>
      <Navbar />
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
