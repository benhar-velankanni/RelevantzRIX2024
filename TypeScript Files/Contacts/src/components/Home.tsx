import "./Home.css";
import "../App.css";
import { useEffect } from "react";

function Home() {
  useEffect(() => {
    document.title = "Z Contacts - Home";
  });

  return (
    <div className="App">
      <header className="App-header">
        <div className="home-container">
          <h1 className="home-title">Welcome to Z - Contacts</h1>
          <p className="home-description">
            Welcome to the Z Contacts app! This app allows you to manage your
            contacts easily and efficiently. With Z Contacts, you can add, edit,
            and delete contacts, and view all your contacts in one place.
          </p>
        </div>
      </header>
    </div>
  );
}

export default Home;
