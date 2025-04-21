import { Link, useLocation } from "react-router-dom";
import "./Navbar.css";

function Navbar() {
  const location = useLocation();

  return (
    <nav className="navbar navbar-expand-lg bg-body-tertiary" style={{ backgroundColor: "#48A6A7" }}>
      <div className="container-fluid">
        <Link className="navbar-brand" to="/">
          Transactions
        </Link>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <Link className={`nav-link ${location.pathname === "/" ? "active" : ""}`} aria-current="page" to="/">
                Home
              </Link>
            </li>
            <li className="nav-item">
              <Link className={`nav-link ${location.pathname === "/add-transaction" ? "active" : ""}`} aria-current="page" to="/add-transaction">
                Add Transaction
              </Link>
            </li>
            <li className="nav-item">
              <Link className={`nav-link ${location.pathname === "/view-transactions" ? "active" : ""}`} aria-current="page" to="/view-transactions">
                View Transactions
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;

