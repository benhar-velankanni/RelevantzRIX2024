import { Link, useLocation } from "react-router-dom";
import "./Navbar.css";

function Navbar() {
  const location = useLocation();

  return (
    <nav className="navbar navbar-expand-lg bg-body-tertiary" style={{ backgroundColor: "#48A6A7" }}>
      <div className="container-fluid">
        <Link className="navbar-brand" to="/">
          Contacts
        </Link>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <Link className={`nav-link ${location.pathname === "/" ? "active" : ""}`} aria-current="page" to="/">
                Home
              </Link>
            </li>
            <li className="nav-item">
              <Link className={`nav-link ${location.pathname === "/add-trancactions" ? "active" : ""}`} aria-current="page" to="/add-contact">
                Add Contact
              </Link>
            </li>
            <li className="nav-item">
              <Link className={`nav-link ${location.pathname === "/view-trancactions" ? "active" : ""}`} aria-current="page" to="/view-contacts">
                View Contacts
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

